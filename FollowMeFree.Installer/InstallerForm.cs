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
        _steps = [pnlWelcome, pnlLicense, pnlConnection, pnlProgress];
        LoadLicense();
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
                btnNext.Text = "&Next >";
                btnNext.Enabled = chkAcceptLicense.Checked;
                break;
            case 2:
                btnNext.Text = "&Install";
                UpdateInstallButtonState();
                break;
            case 3:
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
        if (_currentStep == 2)
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

    // ?? License loading ??????????????????????????????????????????????

    private void LoadLicense()
    {
        try
        {
            string licensePath = Path.Combine(AppContext.BaseDirectory, "License.rtf");
            if (File.Exists(licensePath))
            {
                rtfLicense.LoadFile(licensePath);
            }
            else
            {
                rtfLicense.Text = "License file not found. Please ensure License.rtf is present in the installer directory.";
            }
        }
        catch (Exception ex)
        {
            rtfLicense.Text = $"Unable to load license file: {ex.Message}";
        }
    }

    // ?? UI event handlers ???????????????????????????????????????????

    private void chkAcceptLicense_CheckedChanged(object? sender, EventArgs e)
    {
        if (_currentStep == 1)
            btnNext.Enabled = chkAcceptLicense.Checked;
    }

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
            // Connect to 'master' to test server connectivity and credentials.
            // The target database does not exist yet — it will be created during installation.
            var builder = new SqlConnectionStringBuilder(BuildSqlConnectionString());
            builder.InitialCatalog = "master";
            using var connection = new SqlConnection(builder.ConnectionString);
            await connection.OpenAsync();

            _connectionTested = true;
            lblTestResult.Text = "\u2713  Connection to server successful!";
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
            if (!chkAcceptLicense.Checked)
            {
                MessageBox.Show("You must accept the license agreement to continue.",
                    "License Agreement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowStep(2);
        }
        else if (_currentStep == 2)
        {
            if (!_connectionTested)
            {
                MessageBox.Show("Please test the database connection before proceeding.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowStep(3);
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
            SetProgress(75);

            // 5 ?? Create Start Menu shortcut (optional)
            if (chkStartMenu.Checked)
            {
                AppendLog("Creating Start Menu shortcut...");
                CreateStartMenuShortcut(installPath);
            }
            SetProgress(80);

            _cts.Token.ThrowIfCancellationRequested();

            // 6 ?? Create the database (last step)
            AppendLog("");
            AppendLog("Creating database...");
            string sqlConnStr = BuildSqlConnectionString();
            await Task.Run(() => CreateDatabase(sqlConnStr), _cts.Token);
            SetProgress(95);

            _cts.Token.ThrowIfCancellationRequested();

            // 7 ?? Verify the database was created successfully
            AppendLog("Verifying database...");
            bool dbVerified = await Task.Run(() => VerifyDatabase(sqlConnStr), _cts.Token);
            SetProgress(100);

            if (!dbVerified)
            {
                AppendLog("");
                AppendLog("WARNING: Database verification found issues. Please check the log above.");
                AppendLog("The application may not function correctly until the database is fixed.");
                lblProgressTitle.Text = "Installation Complete (with warnings)";
                _installComplete = true;
                return;
            }

            // 8 ?? Done
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
            ShowStep(3);
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

        // Ensure the icon file is present in the install directory
        string icoPath = Path.Combine(installPath, "FMFappIcon.ico");
        if (!File.Exists(icoPath))
        {
            string installerIco = Path.Combine(AppContext.BaseDirectory, "FMFappIcon.ico");
            if (File.Exists(installerIco))
                File.Copy(installerIco, icoPath, overwrite: false);
        }

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
            if (File.Exists(icoPath))
                shortcut.IconLocation = $"{icoPath},0";
            shortcut.Save();
        }
        finally
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(shell);
        }
    }

    // ══ Database creation ═════════════════════════════════════════════════════════

    private void CreateDatabase(string sqlConnectionString)
    {
        var builder = new SqlConnectionStringBuilder(sqlConnectionString);
        string databaseName = builder.InitialCatalog;

        // Connect to 'master' to check/create the database
        builder.InitialCatalog = "master";
        string masterConnStr = builder.ConnectionString;

        bool isNewDatabase = false;

        using var masterConn = new SqlConnection(masterConnStr);
        masterConn.Open();

        // Check if the database already exists
        using (var checkCmd = new SqlCommand(
            "SELECT COUNT(*) FROM sys.databases WHERE name = @name", masterConn))
        {
            checkCmd.Parameters.AddWithValue("@name", databaseName);
            int exists = (int)checkCmd.ExecuteScalar();
            if (exists > 0)
            {
                AppendLog($"Database '{databaseName}' already exists. Ensuring schema is up to date...");
            }
            else
            {
                AppendLog($"Creating database '{databaseName}'...");
                using var createCmd = new SqlCommand(
                    $"CREATE DATABASE [{databaseName}]", masterConn);
                createCmd.ExecuteNonQuery();
                AppendLog($"Database '{databaseName}' created.");
                isNewDatabase = true;
            }
        }

        masterConn.Close();

        // Connect to the target database and create tables if they don't exist
        builder.InitialCatalog = databaseName;
        using var conn = new SqlConnection(builder.ConnectionString);
        conn.Open();

        string createTablesSql = GetCreateTablesSql();
        using var cmd = new SqlCommand(createTablesSql, conn);
        cmd.ExecuteNonQuery();

        AppendLog("Database schema created/verified successfully.");

        // Seed default data only for a newly created database
        if (isNewDatabase)
        {
            AppendLog("Seeding default data...");
            SeedDatabase(conn);
        }
        else
        {
            AppendLog("Skipping data seed (database already existed).");
        }
    }

    private void SeedDatabase(SqlConnection conn)
    {
        string seedSql = @"
INSERT INTO [dbo].[Config] ([FMFPrinterName])
VALUES ('FMF Print Queue');

INSERT INTO [dbo].[Departments] ([DepartmentName])
VALUES ('IT');

INSERT INTO [dbo].[Users] ([UserName], [FirstName], [Surname], [DepartmentId], [PIN], [AllowedPrinterIds])
VALUES ('joesoap', 'Joe', 'Soap', 1, 12345, NULL);
";
        using var cmd = new SqlCommand(seedSql, conn);
        cmd.ExecuteNonQuery();

        AppendLog("  Seeded Config: FMFPrinterName = 'FMF Print Queue'");
        AppendLog("  Seeded Department: 'IT'");
        AppendLog("  Seeded User: 'joesoap' (Joe Soap, Department: IT)");
    }

    private static string GetCreateTablesSql()
    {
        return @"
-- Departments table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Departments' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE [dbo].[Departments] (
        [Id]             INT           IDENTITY(1,1) NOT NULL,
        [DepartmentName] VARCHAR(100)  NOT NULL,
        CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END;

-- Config table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Config' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE [dbo].[Config] (
        [Id]                INT            IDENTITY(1,1) NOT NULL,
        [JobFilePath]       VARCHAR(MAX)   NULL,
        [FMFPrinterName]    VARCHAR(MAX)   NOT NULL,
        [APIAllowedNetwork] VARCHAR(MAX)   NULL,
        CONSTRAINT [PK_Config] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END;

-- Logs table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Logs' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE [dbo].[Logs] (
        [Id]        INT            IDENTITY(1,1) NOT NULL,
        [Timestamp] DATETIME2(7)   NOT NULL,
        [LogLevel]  NVARCHAR(20)   NOT NULL,
        [Source]    NVARCHAR(50)   NOT NULL,
        [Category]  NVARCHAR(256)  NOT NULL,
        [Message]   NVARCHAR(MAX)  NOT NULL,
        [Exception] NVARCHAR(MAX)  NULL,
        CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END;

-- Printers table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Printers' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE [dbo].[Printers] (
        [Id]      INT           IDENTITY(1,1) NOT NULL,
        [Printer] VARCHAR(MAX)  NOT NULL,
        CONSTRAINT [PK_Printers] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END;

-- PrintJobs table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PrintJobs' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE [dbo].[PrintJobs] (
        [Id]               INT           IDENTITY(1,1) NOT NULL,
        [UserName]         VARCHAR(100)  NOT NULL,
        [DocumentName]     VARCHAR(MAX)  NOT NULL,
        [JobId]            INT           NOT NULL,
        [Pages]            INT           NOT NULL,
        [DateTimePrinted]  DATETIME2(0)  NOT NULL,
        [DataType]         VARCHAR(MAX)  NOT NULL,
        [DepartmentId]     INT           NULL,
        [PrinterId]        INT           NULL,
        CONSTRAINT [PK_PrintJobs] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_PrintJobs_Departments] FOREIGN KEY ([DepartmentId])
            REFERENCES [dbo].[Departments] ([Id]),
        CONSTRAINT [FK_PrintJobs_Printers] FOREIGN KEY ([PrinterId])
            REFERENCES [dbo].[Printers] ([Id])
    );
END;

-- Users table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE [dbo].[Users] (
        [Id]                INT           IDENTITY(1,1) NOT NULL,
        [UserName]          VARCHAR(100)  NOT NULL,
        [FirstName]         VARCHAR(100)  NOT NULL,
        [Surname]           VARCHAR(100)  NOT NULL,
        [DepartmentId]      INT           NOT NULL,
        [PIN]               INT           NOT NULL,
        [AllowedPrinterIds] VARCHAR(MAX)  NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_Users_Departments] FOREIGN KEY ([DepartmentId])
            REFERENCES [dbo].[Departments] ([Id])
    );
END;
";
    }

    private bool VerifyDatabase(string sqlConnectionString)
    {
        string[] expectedTables = ["Config", "Departments", "Logs", "Printers", "PrintJobs", "Users"];
        bool allGood = true;

        try
        {
            using var conn = new SqlConnection(sqlConnectionString);
            conn.Open();

            foreach (string table in expectedTables)
            {
                using var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM sys.tables WHERE name = @name AND schema_id = SCHEMA_ID('dbo')",
                    conn);
                cmd.Parameters.AddWithValue("@name", table);
                int exists = (int)cmd.ExecuteScalar();

                if (exists > 0)
                {
                    AppendLog($"  \u2713 Table [dbo].[{table}] exists.");
                }
                else
                {
                    AppendLog($"  \u2717 Table [dbo].[{table}] is MISSING!");
                    allGood = false;
                }
            }

            if (allGood)
                AppendLog("Database verification passed. All tables are present.");
        }
        catch (Exception ex)
        {
            AppendLog($"Database verification failed: {ex.Message}");
            allGood = false;
        }

        return allGood;
    }
}
