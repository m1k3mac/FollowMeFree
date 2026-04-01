using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace FollowMeFree.API.Installer;

public partial class InstallerForm : Form
{
    private int _currentStep;
    private readonly Panel[] _steps;
    private CancellationTokenSource? _cts;
    private bool _installComplete;

    public InstallerForm()
    {
        InitializeComponent();
        _steps = [pnlWelcome, pnlConfig, pnlProgress];
        CheckPrerequisites();
        LoadDefaultConnectionString();
        ShowStep(0);
    }

    // ── Step navigation ─────────────────────────────────────────────

    private void ShowStep(int step)
    {
        _currentStep = step;
        for (int i = 0; i < _steps.Length; i++)
            _steps[i].Visible = i == step;

        btnBack.Enabled = step > 0 && !_installComplete;

        switch (step)
        {
            case 0:
                btnNext.Text = "&Next >";
                btnNext.Enabled = true;
                break;
            case 1:
                btnNext.Text = "&Install";
                btnNext.Enabled = true;
                break;
            case 2:
                if (_installComplete)
                {
                    btnNext.Text = "&Finish";
                    btnNext.Enabled = true;
                    btnBack.Enabled = false;
                }
                else
                {
                    btnNext.Text = "Installing...";
                    btnNext.Enabled = false;
                }
                break;
        }
    }

    // ── Prerequisite checks ─────────────────────────────────────────

    private void CheckPrerequisites()
    {
        bool iis = IsIisInstalled();
        bool hosting = IsHostingBundleInstalled();
        bool admin = IsRunningAsAdmin();

        SetPrereqLabel(lblIisStatus, iis,
            "IIS is installed",
            "IIS is not installed");

        SetPrereqLabel(lblHostingStatus, hosting,
            "ASP.NET Core Hosting Bundle detected",
            "ASP.NET Core Hosting Bundle not detected");

        SetPrereqLabel(lblSdkStatus, admin,
            "Running as Administrator",
            "Not running as Administrator (required for IIS configuration)");
    }

    private static void SetPrereqLabel(Label label, bool ok, string passText, string failText)
    {
        label.Text = ok ? $"\u2713  {passText}" : $"\u2717  {failText}";
        label.ForeColor = ok ? Color.DarkGreen : Color.DarkRed;
    }

    private static bool IsIisInstalled()
    {
        string appcmd = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Windows),
            "System32", "inetsrv", "appcmd.exe");
        return File.Exists(appcmd);
    }

    private static bool IsHostingBundleInstalled()
    {
        // Check for ASP.NET Core Module V2 DLL
        string modulePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
            "IIS", "Asp.Net Core Module", "V2", "aspnetcorev2.dll");
        if (File.Exists(modulePath))
            return true;

        // Fallback: check the registry
        try
        {
            using var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Microsoft\ASP.NET Core\Shared Framework");
            return key != null;
        }
        catch { return false; }
    }

    private static bool IsRunningAsAdmin()
    {
        try
        {
            using var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }
        catch { return false; }
    }

    // ── Connection string auto-load ─────────────────────────────────

    private void LoadDefaultConnectionString()
    {
        try
        {
            // Try bundled api-publish folder first (distribution scenario)
            string? bundledDir = FindBundledApiFiles();
            if (bundledDir != null)
            {
                if (TryLoadConnectionStringFrom(Path.Combine(bundledDir, "appsettings.json")))
                    return;
            }

            // Fall back to source project (developer scenario)
            string? solutionDir = FindSolutionDirectory();
            if (solutionDir != null)
                TryLoadConnectionStringFrom(Path.Combine(solutionDir, "FollowMeFree.API", "appsettings.json"));
        }
        catch { /* non-critical */ }
    }

    private bool TryLoadConnectionStringFrom(string appsettingsPath)
    {
        if (!File.Exists(appsettingsPath)) return false;

        string json = File.ReadAllText(appsettingsPath);
        var doc = JsonNode.Parse(json, documentOptions: new JsonDocumentOptions
        {
            CommentHandling = JsonCommentHandling.Skip
        });
        string? connStr = doc?["ConnectionStrings"]?["DefaultConnection"]?.GetValue<string>();
        if (!string.IsNullOrEmpty(connStr))
        {
            txtConnectionString.Text = connStr;
            return true;
        }
        return false;
    }

    private static string? FindSolutionDirectory()
    {
        string? dir = AppContext.BaseDirectory;
        while (dir != null)
        {
            if (Directory.GetFiles(dir, "*.sln").Length > 0)
                return dir;
            dir = Directory.GetParent(dir)?.FullName;
        }
        return null;
    }

    private static string? FindBundledApiFiles()
    {
        string candidate = Path.Combine(AppContext.BaseDirectory, "api-publish");
        if (Directory.Exists(candidate) && Directory.GetFiles(candidate).Length > 0)
            return candidate;
        return null;
    }

    // ── UI event handlers ───────────────────────────────────────────

    private void btnBrowse_Click(object? sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = "Select the installation directory",
            SelectedPath = txtInstallPath.Text,
            ShowNewFolderButton = true
        };
        if (dialog.ShowDialog() == DialogResult.OK)
            txtInstallPath.Text = dialog.SelectedPath;
    }

    private void btnRecheck_Click(object? sender, EventArgs e) => CheckPrerequisites();

    private void chkCreateIisSite_CheckedChanged(object? sender, EventArgs e)
    {
        bool enabled = chkCreateIisSite.Checked;
        lblSiteNameLabel.Enabled = enabled;
        txtSiteName.Enabled = enabled;
        lblAppPoolLabel.Enabled = enabled;
        txtAppPool.Enabled = enabled;
        lblPortLabel.Enabled = enabled;
        txtPort.Enabled = enabled;
    }

    private async void btnNext_Click(object? sender, EventArgs e)
    {
        if (_installComplete)
        {
            Close();
            return;
        }

        if (_currentStep == 0)
        {
            ShowStep(1);
        }
        else if (_currentStep == 1)
        {
            if (!ValidateConfig())
                return;

            ShowStep(2);
            await RunInstallation();
        }
    }

    private void btnBack_Click(object? sender, EventArgs e)
    {
        if (_currentStep > 0)
            ShowStep(_currentStep - 1);
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        if (_cts != null)
        {
            _cts.Cancel();
            return;
        }
        Close();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (_cts != null)
        {
            var result = MessageBox.Show(
                "Installation is in progress. Are you sure you want to cancel?",
                "Cancel Installation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            _cts.Cancel();
        }
        base.OnFormClosing(e);
    }

    // ── Validation ──────────────────────────────────────────────────

    private bool ValidateConfig()
    {
        if (string.IsNullOrWhiteSpace(txtInstallPath.Text))
        {
            MessageBox.Show("Please specify an installation path.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (chkCreateIisSite.Checked)
        {
            if (string.IsNullOrWhiteSpace(txtSiteName.Text))
            {
                MessageBox.Show("Please specify an IIS site name.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAppPool.Text))
            {
                MessageBox.Show("Please specify an application pool name.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtPort.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Please specify a valid port number (1\u201365535).",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        return true;
    }

    // ── Installation logic ──────────────────────────────────────────

    private void AppendLog(string message)
    {
        if (InvokeRequired) { Invoke(() => AppendLog(message)); return; }
        txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
    }

    private void SetProgress(int percent)
    {
        if (InvokeRequired) { Invoke(() => SetProgress(percent)); return; }
        progressBar.Value = Math.Clamp(percent, 0, 100);
    }

    private async Task RunInstallation()
    {
        _cts = new CancellationTokenSource();
        btnNext.Enabled = false;
        btnBack.Enabled = false;
        btnCancel.Text = "&Stop";
        txtLog.Clear();
        progressBar.Value = 0;
        lblProgressTitle.Text = "Installing...";

        try
        {
            // 1 ── Locate bundled API files
            AppendLog("Locating bundled API files...");
            string? sourceDir = FindBundledApiFiles();
            if (sourceDir == null)
            {
                AppendLog("ERROR: Could not find the 'api-publish' folder next to this installer.");
                AppendLog("Run build-api-installer.ps1 to package the API files before distributing.");
                lblProgressTitle.Text = "Installation Failed";
                return;
            }
            AppendLog($"Source: {sourceDir}");
            SetProgress(10);

            _cts.Token.ThrowIfCancellationRequested();

            // 2 ── Copy files to install directory
            string installPath = txtInstallPath.Text.Trim();
            AppendLog($"Deploying API files to: {installPath}");
            int fileCount = await Task.Run(() => CopyDirectory(sourceDir, installPath), _cts.Token);
            AppendLog($"Copied {fileCount} file(s).");
            SetProgress(60);

            _cts.Token.ThrowIfCancellationRequested();

            // 3 ── Update connection string
            if (!string.IsNullOrWhiteSpace(txtConnectionString.Text))
            {
                AppendLog("Updating connection string in published appsettings.json...");
                UpdateConnectionString(installPath, txtConnectionString.Text.Trim());
            }
            SetProgress(70);

            // 4 ── Create IIS site (optional)
            if (chkCreateIisSite.Checked)
            {
                _cts.Token.ThrowIfCancellationRequested();
                int port = int.Parse(txtPort.Text);
                AppendLog("Configuring IIS...");
                bool iisOk = await ConfigureIisAsync(
                    txtSiteName.Text.Trim(),
                    txtAppPool.Text.Trim(),
                    installPath,
                    port,
                    _cts.Token);
                if (!iisOk)
                    AppendLog("WARNING: IIS configuration had errors. You may need to configure IIS manually.");
            }
            SetProgress(100);

            // 5 ── Done
            AppendLog("");
            AppendLog("============================================");
            AppendLog("   Installation completed successfully!");
            AppendLog("============================================");

            if (chkCreateIisSite.Checked)
            {
                AppendLog("");
                AppendLog($"Your API should be available at:  http://localhost:{txtPort.Text}");
                AppendLog("You can verify by browsing to the URL above.");
            }
            else
            {
                AppendLog("");
                AppendLog($"Published files are located at: {installPath}");
                AppendLog("Configure IIS to point to this directory to start serving the API.");
            }

            lblProgressTitle.Text = "Installation Complete";
            _installComplete = true;
        }
        catch (OperationCanceledException)
        {
            AppendLog("");
            AppendLog("Installation was cancelled by the user.");
            lblProgressTitle.Text = "Installation Cancelled";
        }
        catch (Exception ex)
        {
            AppendLog($"ERROR: {ex.Message}");
            lblProgressTitle.Text = "Installation Failed";
        }
        finally
        {
            _cts = null;
            btnCancel.Text = "&Close";
            ShowStep(2);
        }
    }

    // ── File copy helper ─────────────────────────────────────────────

    private static int CopyDirectory(string sourceDir, string targetDir)
    {
        Directory.CreateDirectory(targetDir);
        int count = 0;

        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string dest = Path.Combine(targetDir, Path.GetFileName(file));
            File.Copy(file, dest, overwrite: true);
            count++;
        }

        foreach (string subDir in Directory.GetDirectories(sourceDir))
        {
            string destSub = Path.Combine(targetDir, Path.GetFileName(subDir));
            count += CopyDirectory(subDir, destSub);
        }

        return count;
    }

    // ── Process helper ──────────────────────────────────────────────

    private async Task<bool> RunProcessAsync(string fileName, string arguments, CancellationToken ct)
    {
        var psi = new ProcessStartInfo(fileName, arguments)
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = psi };
        process.OutputDataReceived += (_, e) => { if (e.Data != null) AppendLog(e.Data); };
        process.ErrorDataReceived += (_, e) => { if (e.Data != null) AppendLog($"  {e.Data}"); };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        await process.WaitForExitAsync(ct);

        if (process.ExitCode != 0)
        {
            AppendLog($"Process exited with code {process.ExitCode}.");
            return false;
        }
        return true;
    }

    // ── Connection string update ────────────────────────────────────

    private void UpdateConnectionString(string publishDir, string connectionString)
    {
        string appsettings = Path.Combine(publishDir, "appsettings.json");
        if (!File.Exists(appsettings))
        {
            AppendLog("WARNING: appsettings.json not found in publish output. Skipping.");
            return;
        }

        try
        {
            string json = File.ReadAllText(appsettings);
            var doc = JsonNode.Parse(json, documentOptions: new JsonDocumentOptions
            {
                CommentHandling = JsonCommentHandling.Skip
            });
            if (doc == null)
            {
                AppendLog("WARNING: Could not parse appsettings.json.");
                return;
            }

            doc["ConnectionStrings"] ??= new JsonObject();
            doc["ConnectionStrings"]!["DefaultConnection"] = connectionString;

            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(appsettings, doc.ToJsonString(options));
            AppendLog("Connection string updated successfully.");
        }
        catch (Exception ex)
        {
            AppendLog($"WARNING: Failed to update connection string: {ex.Message}");
        }
    }

    // ── IIS configuration ───────────────────────────────────────────

    private async Task<bool> ConfigureIisAsync(
        string siteName, string appPoolName, string physicalPath, int port,
        CancellationToken ct)
    {
        string appcmd = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Windows),
            "System32", "inetsrv", "appcmd.exe");

        if (!File.Exists(appcmd))
        {
            AppendLog("ERROR: appcmd.exe not found. Is IIS installed?");
            return false;
        }

        bool allGood = true;

        // Create application pool (No Managed Code for .NET Core)
        AppendLog($"Creating application pool '{appPoolName}'...");
        bool poolOk = await RunProcessAsync(appcmd,
            $"add apppool /name:\"{appPoolName}\" /managedRuntimeVersion:\"\" /managedPipelineMode:\"Integrated\"",
            ct);
        if (!poolOk)
        {
            AppendLog("  (The app pool may already exist \u2013 continuing.)");
        }

        // Create website
        AppendLog($"Creating website '{siteName}' on port {port}...");
        bool siteOk = await RunProcessAsync(appcmd,
            $"add site /name:\"{siteName}\" /physicalPath:\"{physicalPath}\" /bindings:http/*:{port}:",
            ct);
        if (!siteOk)
        {
            AppendLog("  (The site may already exist or the port may be in use \u2013 continuing.)");
            allGood = false;
        }

        // Assign app pool to site
        AppendLog("Assigning application pool to site...");
        await RunProcessAsync(appcmd,
            $"set site /site.name:\"{siteName}\" /[path='/'].applicationPool:\"{appPoolName}\"",
            ct);

        // Start the site
        AppendLog("Starting the website...");
        await RunProcessAsync(appcmd,
            $"start site /site.name:\"{siteName}\"",
            ct);

        return allGood;
    }
}
