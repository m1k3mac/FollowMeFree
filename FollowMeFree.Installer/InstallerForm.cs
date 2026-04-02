using System.Data.SqlClient;
using System.Xml;

namespace FollowMeFree.Installer;

public partial class InstallerForm : Form
{
    private int _currentStep;
    private readonly Panel[] _steps;
    private CancellationTokenSource? _cts;
    private bool _installComplete;
    private bool _connectionTested;

    public InstallerForm()
    {
        InitializeComponent();
        _steps = [pnlWelcome, pnlConnection, pnlProgress];
        ShowStep(0);
    }

    // ?? Step navigation ?????????????????????????????????????????????

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
                UpdateInstallButtonState();
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

    private void UpdateInstallButtonState()
    {
        if (_currentStep == 1)
        {
            btnNext.Enabled = _connectionTested;
        }
    }

    // ?? Connection string helpers ???????????????????????????????????

    private string BuildEntityConnectionString()
    {
        string sqlConnStr = BuildSqlConnectionString();
        return $"metadata=res://*/EFModel.csdl|res://*/EFModel.ssdl|res://*/EFModel.msl;" +
               $"provider=System.Data.SqlClient;" +
               $"provider connection string=\"{sqlConnStr}\"";
    }

    private string BuildSqlConnectionString()
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = txtServer.Text.Trim(),
            InitialCatalog = txtDatabase.Text.Trim(),
            MultipleActiveResultSets = true,
            TrustServerCertificate = true,
            ApplicationName = "EntityFramework"
        };

        if (chkWindowsAuth.Checked)
        {
            builder.IntegratedSecurity = true;
        }
        else
        {
            builder.UserID = txtUsername.Text.Trim();
            builder.Password = txtPassword.Text;
        }

        return builder.ConnectionString;
    }

    // ?? UI event handlers ???????????????????????????????????????????

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

    private void chkWindowsAuth_CheckedChanged(object? sender, EventArgs e)
    {
        bool sqlAuth = !chkWindowsAuth.Checked;
        lblUsername.Enabled = sqlAuth;
        txtUsername.Enabled = sqlAuth;
        lblPassword.Enabled = sqlAuth;
        txtPassword.Enabled = sqlAuth;
        _connectionTested = false;
        UpdateInstallButtonState();
        lblTestResult.Text = string.Empty;
    }

    private void ConnectionField_TextChanged(object? sender, EventArgs e)
    {
        _connectionTested = false;
        UpdateInstallButtonState();
        lblTestResult.Text = string.Empty;
    }

    private async void btnTestConnection_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtServer.Text))
        {
            MessageBox.Show("Please enter a server name.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtServer.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtDatabase.Text))
        {
            MessageBox.Show("Please enter a database name.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDatabase.Focus();
            return;
        }

        if (!chkWindowsAuth.Checked && string.IsNullOrWhiteSpace(txtUsername.Text))
        {
            MessageBox.Show("Please enter a username for SQL Server authentication.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        btnTestConnection.Enabled = false;
        lblTestResult.Text = "Testing connection...";
        lblTestResult.ForeColor = SystemColors.ControlText;

        try
        {
            string connStr = BuildSqlConnectionString();
            using var connection = new SqlConnection(connStr);
            await connection.OpenAsync();

            _connectionTested = true;
            lblTestResult.Text = "\u2713  Connection successful!";
            lblTestResult.ForeColor = Color.DarkGreen;
        }
        catch (Exception ex)
        {
            _connectionTested = false;
            lblTestResult.Text = $"\u2717  Connection failed: {ex.Message}";
            lblTestResult.ForeColor = Color.DarkRed;
        }
        finally
        {
            btnTestConnection.Enabled = true;
            UpdateInstallButtonState();
        }
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
            if (!ValidateWelcome())
                return;
            ShowStep(1);
        }
        else if (_currentStep == 1)
        {
            if (!_connectionTested)
            {
                MessageBox.Show("Please test the database connection before proceeding.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

    // ?? Validation ??????????????????????????????????????????????????

    private bool ValidateWelcome()
    {
        if (string.IsNullOrWhiteSpace(txtInstallPath.Text))
        {
            MessageBox.Show("Please specify an installation path.",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    // ?? Installation logic ??????????????????????????????????????????

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
            // 1 ?? Locate bundled app files
            AppendLog("Locating bundled application files...");
            string? sourceDir = FindBundledAppFiles();
            if (sourceDir == null)
            {
                AppendLog("ERROR: Could not find the 'app-publish' folder next to this installer.");
                AppendLog("Run build-app-installer.ps1 to package the application files before distributing.");
                lblProgressTitle.Text = "Installation Failed";
                return;
            }
            AppendLog($"Source: {sourceDir}");
            SetProgress(10);

            _cts.Token.ThrowIfCancellationRequested();

            // 2 ?? Copy files to install directory
            string installPath = txtInstallPath.Text.Trim();
            AppendLog($"Deploying application files to: {installPath}");
            int fileCount = await Task.Run(() => CopyDirectory(sourceDir, installPath), _cts.Token);
            AppendLog($"Copied {fileCount} file(s).");
            SetProgress(50);

            _cts.Token.ThrowIfCancellationRequested();

            // 3 ?? Update connection string in the deployed .exe.config
            AppendLog("Updating connection string in FollowMeFree.exe.config...");
            UpdateExeConfig(installPath);
            SetProgress(70);

            _cts.Token.ThrowIfCancellationRequested();

            // 4 ?? Create desktop shortcut (optional)
            if (chkDesktopShortcut.Checked)
            {
                AppendLog("Creating desktop shortcut...");
                CreateDesktopShortcut(installPath);
            }
            SetProgress(90);

            // 5 ?? Create Start Menu shortcut (optional)
            if (chkStartMenu.Checked)
            {
                AppendLog("Creating Start Menu shortcut...");
                CreateStartMenuShortcut(installPath);
            }
            SetProgress(100);

            // 6 ?? Done
            AppendLog("");
            AppendLog("============================================");
            AppendLog("   Installation completed successfully!");
            AppendLog("============================================");
            AppendLog("");
            AppendLog($"Application installed to: {installPath}");
            AppendLog("You can launch FollowMeFree from the desktop shortcut or the installation directory.");

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

    // ?? File copy helper ?????????????????????????????????????????????

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

    // ?? Bundled files ???????????????????????????????????????????????

    private static string? FindBundledAppFiles()
    {
        string candidate = Path.Combine(AppContext.BaseDirectory, "app-publish");
        if (Directory.Exists(candidate) && Directory.GetFiles(candidate).Length > 0)
            return candidate;
        return null;
    }

    // ?? Connection string update in .exe.config ?????????????????????

    private void UpdateExeConfig(string installPath)
    {
        string configPath = Path.Combine(installPath, "FollowMeFree.exe.config");
        if (!File.Exists(configPath))
        {
            AppendLog("WARNING: FollowMeFree.exe.config not found. Skipping connection string update.");
            return;
        }

        try
        {
            var doc = new XmlDocument();
            doc.Load(configPath);

            var connStrNode = doc.SelectSingleNode(
                "//connectionStrings/add[@name='FMFDataEntities']");

            if (connStrNode == null)
            {
                AppendLog("WARNING: FMFDataEntities connection string entry not found in config. Skipping.");
                return;
            }

            string entityConnStr = BuildEntityConnectionString();
            connStrNode.Attributes!["connectionString"]!.Value = entityConnStr;

            doc.Save(configPath);
            AppendLog("Connection string updated successfully.");
        }
        catch (Exception ex)
        {
            AppendLog($"WARNING: Failed to update connection string: {ex.Message}");
        }
    }

    // ?? Shortcut helpers ????????????????????????????????????????????

    private static void CreateDesktopShortcut(string installPath)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        CreateShortcut(desktopPath, installPath);
    }

    private static void CreateStartMenuShortcut(string installPath)
    {
        string startMenuPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu),
            "Programs", "FollowMeFree");
        Directory.CreateDirectory(startMenuPath);
        CreateShortcut(startMenuPath, installPath);
    }

    private static void CreateShortcut(string shortcutDir, string installPath)
    {
        string targetExe = Path.Combine(installPath, "FollowMeFree.exe");
        string shortcutPath = Path.Combine(shortcutDir, "FollowMeFree.lnk");

        // Use Windows Script Host COM object to create .lnk shortcut
        var shellType = Type.GetTypeFromProgID("WScript.Shell");
        if (shellType == null) return;

        dynamic? shell = Activator.CreateInstance(shellType);
        if (shell == null) return;

        try
        {
            dynamic shortcut = shell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = targetExe;
            shortcut.WorkingDirectory = installPath;
            shortcut.Description = "FollowMeFree";
            shortcut.Save();
        }
        finally
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(shell);
        }
    }
}
