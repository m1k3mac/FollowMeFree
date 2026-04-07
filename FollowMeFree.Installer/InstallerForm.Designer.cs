namespace FollowMeFree.Installer;

partial class InstallerForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlBanner = new Panel();
        lblBannerTitle = new Label();
        lblBannerSubtitle = new Label();
        pnlSepTop = new Panel();
        pnlSepBottom = new Panel();
        pnlButtons = new Panel();
        btnBack = new Button();
        btnNext = new Button();
        btnCancel = new Button();

        // Step 1 - Welcome / Install Path
        pnlWelcome = new Panel();
        lblWelcomeTitle = new Label();
        lblWelcomeDesc = new Label();
        lblInstallPathLabel = new Label();
        txtInstallPath = new TextBox();
        btnBrowse = new Button();
        chkDesktopShortcut = new CheckBox();
        chkStartMenu = new CheckBox();
        grpWelcomeTips = new GroupBox();
        lblWelcomeTips = new Label();

        // Step 2 - Connection String
        pnlConnection = new Panel();
        lblConnTitle = new Label();
        lblConnDesc = new Label();
        grpConnectionDetails = new GroupBox();
        lblServer = new Label();
        txtServer = new TextBox();
        lblDatabase = new Label();
        txtDatabase = new TextBox();
        chkWindowsAuth = new CheckBox();
        lblUsername = new Label();
        txtUsername = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        btnTestConnection = new Button();
        lblTestResult = new Label();
        lblConnNote = new Label();

        // Step 3 - Progress
        pnlProgress = new Panel();
        lblProgressTitle = new Label();
        progressBar = new ProgressBar();
        txtLog = new TextBox();

        pnlBanner.SuspendLayout();
        pnlButtons.SuspendLayout();
        pnlWelcome.SuspendLayout();
        grpWelcomeTips.SuspendLayout();
        pnlConnection.SuspendLayout();
        grpConnectionDetails.SuspendLayout();
        pnlProgress.SuspendLayout();
        SuspendLayout();

        // ?? Banner ??????????????????????????????????????????????????
        pnlBanner.BackColor = Color.White;
        pnlBanner.Dock = DockStyle.Top;
        pnlBanner.Size = new Size(700, 70);
        pnlBanner.Controls.Add(lblBannerSubtitle);
        pnlBanner.Controls.Add(lblBannerTitle);

        lblBannerTitle.AutoSize = true;
        lblBannerTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblBannerTitle.Location = new Point(18, 10);
        lblBannerTitle.Text = "FollowMeFree Installer";

        lblBannerSubtitle.AutoSize = true;
        lblBannerSubtitle.Font = new Font("Segoe UI", 9F);
        lblBannerSubtitle.ForeColor = Color.Gray;
        lblBannerSubtitle.Location = new Point(20, 42);
        lblBannerSubtitle.Text = "Install the FollowMeFree application";

        // ?? Separators ??????????????????????????????????????????????
        pnlSepTop.BackColor = SystemColors.ControlDark;
        pnlSepTop.Dock = DockStyle.Top;
        pnlSepTop.Size = new Size(700, 1);

        pnlSepBottom.BackColor = SystemColors.ControlDark;
        pnlSepBottom.Dock = DockStyle.Bottom;
        pnlSepBottom.Size = new Size(700, 1);

        // ?? Buttons ?????????????????????????????????????????????????
        pnlButtons.Dock = DockStyle.Bottom;
        pnlButtons.Size = new Size(700, 50);
        pnlButtons.Controls.Add(btnCancel);
        pnlButtons.Controls.Add(btnNext);
        pnlButtons.Controls.Add(btnBack);

        btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnBack.Location = new Point(420, 12);
        btnBack.Size = new Size(85, 28);
        btnBack.Text = "< &Back";
        btnBack.UseVisualStyleBackColor = true;
        btnBack.Click += btnBack_Click;

        btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnNext.Location = new Point(510, 12);
        btnNext.Size = new Size(85, 28);
        btnNext.Text = "&Next >";
        btnNext.UseVisualStyleBackColor = true;
        btnNext.Click += btnNext_Click;

        btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCancel.Location = new Point(602, 12);
        btnCancel.Size = new Size(85, 28);
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;

        // ?? Step 1 – Welcome / Install Path ?????????????????????????
        pnlWelcome.Location = new Point(15, 82);
        pnlWelcome.Size = new Size(670, 420);
        pnlWelcome.Controls.Add(grpWelcomeTips);
        pnlWelcome.Controls.Add(chkStartMenu);
        pnlWelcome.Controls.Add(chkDesktopShortcut);
        pnlWelcome.Controls.Add(btnBrowse);
        pnlWelcome.Controls.Add(txtInstallPath);
        pnlWelcome.Controls.Add(lblInstallPathLabel);
        pnlWelcome.Controls.Add(lblWelcomeDesc);
        pnlWelcome.Controls.Add(lblWelcomeTitle);

        lblWelcomeTitle.AutoSize = true;
        lblWelcomeTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblWelcomeTitle.Location = new Point(0, 0);
        lblWelcomeTitle.Text = "Welcome";

        lblWelcomeDesc.Location = new Point(0, 32);
        lblWelcomeDesc.Size = new Size(660, 36);
        lblWelcomeDesc.Text = "This wizard will install the FollowMeFree application. " +
            "Choose an installation directory and configure options below.";

        lblInstallPathLabel.AutoSize = true;
        lblInstallPathLabel.Location = new Point(0, 80);
        lblInstallPathLabel.Text = "Installation Path:";

        txtInstallPath.Location = new Point(0, 102);
        txtInstallPath.Size = new Size(572, 23);
        txtInstallPath.Text = @"C:\Program Files\FollowMeFree";

        btnBrowse.Location = new Point(580, 101);
        btnBrowse.Size = new Size(80, 25);
        btnBrowse.Text = "Browse...";
        btnBrowse.UseVisualStyleBackColor = true;
        btnBrowse.Click += btnBrowse_Click;

        chkDesktopShortcut.AutoSize = true;
        chkDesktopShortcut.Checked = true;
        chkDesktopShortcut.CheckState = CheckState.Checked;
        chkDesktopShortcut.Location = new Point(0, 140);
        chkDesktopShortcut.Text = "Create Desktop shortcut";

        chkStartMenu.AutoSize = true;
        chkStartMenu.Checked = true;
        chkStartMenu.CheckState = CheckState.Checked;
        chkStartMenu.Location = new Point(0, 165);
        chkStartMenu.Text = "Create Start Menu shortcut";

        // Tips group
        grpWelcomeTips.Location = new Point(0, 200);
        grpWelcomeTips.Size = new Size(660, 210);
        grpWelcomeTips.Text = "Important Information";
        grpWelcomeTips.Controls.Add(lblWelcomeTips);

        lblWelcomeTips.Location = new Point(15, 22);
        lblWelcomeTips.Size = new Size(630, 180);
        lblWelcomeTips.Text =
            "Before running this installer, please ensure:\r\n\r\n" +
            "1. A SQL Server instance is available and accessible from this machine.\r\n\r\n" +
            "2. You have valid credentials (SQL Server or Windows Authentication)\r\n" +
            "   with permission to create databases on the server.\r\n\r\n" +
            "3. Run this installer as Administrator if installing to Program Files.\r\n\r\n" +
            "On the next step you will configure and test the database connection.\r\n" +
            "The installer will automatically create the FMFData database and schema.";

        // ?? Step 2 – Database Connection ????????????????????????????
        pnlConnection.Location = new Point(15, 82);
        pnlConnection.Size = new Size(670, 420);
        pnlConnection.Visible = false;
        pnlConnection.Controls.Add(lblConnNote);
        pnlConnection.Controls.Add(grpConnectionDetails);
        pnlConnection.Controls.Add(lblConnDesc);
        pnlConnection.Controls.Add(lblConnTitle);

        lblConnTitle.AutoSize = true;
        lblConnTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblConnTitle.Location = new Point(0, 0);
        lblConnTitle.Text = "Database Connection";

        lblConnDesc.Location = new Point(0, 32);
        lblConnDesc.Size = new Size(660, 36);
        lblConnDesc.Text = "Enter the SQL Server connection details for the FMFData database. " +
            "You must test the connection before proceeding with the installation.";

        // Connection details group
        grpConnectionDetails.Location = new Point(0, 75);
        grpConnectionDetails.Size = new Size(660, 220);
        grpConnectionDetails.Text = "SQL Server Connection";
        grpConnectionDetails.Controls.Add(lblTestResult);
        grpConnectionDetails.Controls.Add(btnTestConnection);
        grpConnectionDetails.Controls.Add(txtPassword);
        grpConnectionDetails.Controls.Add(lblPassword);
        grpConnectionDetails.Controls.Add(txtUsername);
        grpConnectionDetails.Controls.Add(lblUsername);
        grpConnectionDetails.Controls.Add(chkWindowsAuth);
        grpConnectionDetails.Controls.Add(txtDatabase);
        grpConnectionDetails.Controls.Add(lblDatabase);
        grpConnectionDetails.Controls.Add(txtServer);
        grpConnectionDetails.Controls.Add(lblServer);

        lblServer.AutoSize = true;
        lblServer.Location = new Point(20, 30);
        lblServer.Text = "Server:";

        txtServer.Location = new Point(20, 50);
        txtServer.Size = new Size(300, 23);
        txtServer.Text = "localhost\\sqlexpress";
        txtServer.TextChanged += ConnectionField_TextChanged;

        lblDatabase.AutoSize = true;
        lblDatabase.Location = new Point(340, 30);
        lblDatabase.Text = "Database:";

        txtDatabase.Location = new Point(340, 50);
        txtDatabase.Size = new Size(300, 23);
        txtDatabase.Text = "FMFData";
        txtDatabase.TextChanged += ConnectionField_TextChanged;

        chkWindowsAuth.AutoSize = true;
        chkWindowsAuth.Location = new Point(20, 88);
        chkWindowsAuth.Text = "Use Windows Authentication";
        chkWindowsAuth.CheckState = CheckState.Checked;
        chkWindowsAuth.CheckedChanged += chkWindowsAuth_CheckedChanged;

        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(20, 120);
        lblUsername.Text = "Username:";

        txtUsername.Location = new Point(20, 140);
        txtUsername.Size = new Size(300, 23);
        txtUsername.Enabled = false;
        txtUsername.TextChanged += ConnectionField_TextChanged;

        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(340, 120);
        lblPassword.Text = "Password:";

        txtPassword.Location = new Point(340, 140);
        txtPassword.Size = new Size(300, 23);
        txtPassword.Enabled = false;
        txtPassword.UseSystemPasswordChar = true;
        txtPassword.TextChanged += ConnectionField_TextChanged;

        btnTestConnection.Location = new Point(20, 178);
        btnTestConnection.Size = new Size(130, 30);
        btnTestConnection.Text = "Test Connection";
        btnTestConnection.UseVisualStyleBackColor = true;
        btnTestConnection.Click += btnTestConnection_Click;

        lblTestResult.Location = new Point(160, 183);
        lblTestResult.Size = new Size(480, 20);
        lblTestResult.Text = "";

        // Connection note
        lblConnNote.Location = new Point(0, 310);
        lblConnNote.Size = new Size(660, 100);
        lblConnNote.ForeColor = SystemColors.GrayText;
        lblConnNote.Text =
            "Note: The connection string will be written to the application's configuration file\r\n" +
            "(FollowMeFree.exe.config) in the installation directory.\r\n\r\n" +
            "The Install button will be enabled only after a successful connection test.\r\n" +
            "You can change the connection string later by editing the config file manually.";

        // ?? Step 3 – Progress ???????????????????????????????????????
        pnlProgress.Location = new Point(15, 82);
        pnlProgress.Size = new Size(670, 420);
        pnlProgress.Visible = false;
        pnlProgress.Controls.Add(txtLog);
        pnlProgress.Controls.Add(progressBar);
        pnlProgress.Controls.Add(lblProgressTitle);

        lblProgressTitle.AutoSize = true;
        lblProgressTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblProgressTitle.Location = new Point(0, 0);
        lblProgressTitle.Text = "Preparing...";

        progressBar.Location = new Point(0, 35);
        progressBar.Size = new Size(660, 25);

        txtLog.Location = new Point(0, 72);
        txtLog.Size = new Size(660, 342);
        txtLog.Font = new Font("Consolas", 9F);
        txtLog.Multiline = true;
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = ScrollBars.Vertical;
        txtLog.BackColor = SystemColors.Window;
        txtLog.WordWrap = false;

        // ?? Form ????????????????????????????????????????????????????
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 560);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = new Icon(Path.Combine(AppContext.BaseDirectory, "FMFappIcon.ico"));
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FollowMeFree Installer";

        Controls.Add(pnlProgress);
        Controls.Add(pnlConnection);
        Controls.Add(pnlWelcome);
        Controls.Add(pnlSepBottom);
        Controls.Add(pnlButtons);
        Controls.Add(pnlSepTop);
        Controls.Add(pnlBanner);

        pnlBanner.ResumeLayout(false);
        pnlBanner.PerformLayout();
        pnlButtons.ResumeLayout(false);
        pnlWelcome.ResumeLayout(false);
        pnlWelcome.PerformLayout();
        grpWelcomeTips.ResumeLayout(false);
        pnlConnection.ResumeLayout(false);
        pnlConnection.PerformLayout();
        grpConnectionDetails.ResumeLayout(false);
        grpConnectionDetails.PerformLayout();
        pnlProgress.ResumeLayout(false);
        pnlProgress.PerformLayout();
        ResumeLayout(false);
    }

    // ?? Banner ??????????????????????????????????????????????????????
    private Panel pnlBanner;
    private Label lblBannerTitle;
    private Label lblBannerSubtitle;
    private Panel pnlSepTop;
    private Panel pnlSepBottom;

    // ?? Buttons ?????????????????????????????????????????????????????
    private Panel pnlButtons;
    private Button btnBack;
    private Button btnNext;
    private Button btnCancel;

    // ?? Step 1 – Welcome / Install Path ?????????????????????????????
    private Panel pnlWelcome;
    private Label lblWelcomeTitle;
    private Label lblWelcomeDesc;
    private Label lblInstallPathLabel;
    private TextBox txtInstallPath;
    private Button btnBrowse;
    private CheckBox chkDesktopShortcut;
    private CheckBox chkStartMenu;
    private GroupBox grpWelcomeTips;
    private Label lblWelcomeTips;

    // ?? Step 2 – Database Connection ????????????????????????????????
    private Panel pnlConnection;
    private Label lblConnTitle;
    private Label lblConnDesc;
    private GroupBox grpConnectionDetails;
    private Label lblServer;
    private TextBox txtServer;
    private Label lblDatabase;
    private TextBox txtDatabase;
    private CheckBox chkWindowsAuth;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblPassword;
    private TextBox txtPassword;
    private Button btnTestConnection;
    private Label lblTestResult;
    private Label lblConnNote;

    // ?? Step 3 – Progress ???????????????????????????????????????????
    private Panel pnlProgress;
    private Label lblProgressTitle;
    private ProgressBar progressBar;
    private TextBox txtLog;
}
