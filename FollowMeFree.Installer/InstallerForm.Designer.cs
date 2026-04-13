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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallerForm));
        pnlBanner = new Panel();
        lblBannerSubtitle = new Label();
        lblBannerTitle = new Label();
        pnlSepTop = new Panel();
        pnlSepBottom = new Panel();
        pnlButtons = new Panel();
        btnCancel = new Button();
        btnNext = new Button();
        btnBack = new Button();
        pnlWelcome = new Panel();
        grpWelcomeTips = new GroupBox();
        lblWelcomeTips = new Label();
        chkStartMenu = new CheckBox();
        chkDesktopShortcut = new CheckBox();
        btnBrowse = new Button();
        txtInstallPath = new TextBox();
        lblInstallPathLabel = new Label();
        lblWelcomeDesc = new Label();
        lblWelcomeTitle = new Label();
        pnlConnection = new Panel();
        lblConnNote = new Label();
        grpConnectionDetails = new GroupBox();
        lblTestResult = new Label();
        btnTestConnection = new Button();
        txtPassword = new TextBox();
        lblPassword = new Label();
        txtUsername = new TextBox();
        lblUsername = new Label();
        chkWindowsAuth = new CheckBox();
        txtDatabase = new TextBox();
        lblDatabase = new Label();
        txtServer = new TextBox();
        lblServer = new Label();
        lblConnDesc = new Label();
        lblConnTitle = new Label();
        pnlProgress = new Panel();
        txtLog = new TextBox();
        progressBar = new ProgressBar();
        lblProgressTitle = new Label();
        pnlBanner.SuspendLayout();
        pnlButtons.SuspendLayout();
        pnlWelcome.SuspendLayout();
        grpWelcomeTips.SuspendLayout();
        pnlConnection.SuspendLayout();
        grpConnectionDetails.SuspendLayout();
        pnlProgress.SuspendLayout();
        SuspendLayout();
        // 
        // pnlBanner
        // 
        pnlBanner.BackColor = Color.White;
        pnlBanner.Controls.Add(lblBannerSubtitle);
        pnlBanner.Controls.Add(lblBannerTitle);
        pnlBanner.Dock = DockStyle.Top;
        pnlBanner.Location = new Point(0, 0);
        pnlBanner.Name = "pnlBanner";
        pnlBanner.Size = new Size(700, 70);
        pnlBanner.TabIndex = 6;
        // 
        // lblBannerSubtitle
        // 
        lblBannerSubtitle.AutoSize = true;
        lblBannerSubtitle.Font = new Font("Segoe UI", 9F);
        lblBannerSubtitle.ForeColor = Color.Gray;
        lblBannerSubtitle.Location = new Point(20, 42);
        lblBannerSubtitle.Name = "lblBannerSubtitle";
        lblBannerSubtitle.Size = new Size(313, 15);
        lblBannerSubtitle.TabIndex = 0;
        lblBannerSubtitle.Text = "Install the FollowMeFree Commander Desktop application";
        // 
        // lblBannerTitle
        // 
        lblBannerTitle.AutoSize = true;
        lblBannerTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblBannerTitle.Location = new Point(18, 10);
        lblBannerTitle.Name = "lblBannerTitle";
        lblBannerTitle.Size = new Size(380, 30);
        lblBannerTitle.TabIndex = 1;
        lblBannerTitle.Text = "FollowMeFree Commander Installer";
        // 
        // pnlSepTop
        // 
        pnlSepTop.BackColor = SystemColors.ControlDark;
        pnlSepTop.Dock = DockStyle.Top;
        pnlSepTop.Location = new Point(0, 70);
        pnlSepTop.Name = "pnlSepTop";
        pnlSepTop.Size = new Size(700, 1);
        pnlSepTop.TabIndex = 5;
        // 
        // pnlSepBottom
        // 
        pnlSepBottom.BackColor = SystemColors.ControlDark;
        pnlSepBottom.Dock = DockStyle.Bottom;
        pnlSepBottom.Location = new Point(0, 509);
        pnlSepBottom.Name = "pnlSepBottom";
        pnlSepBottom.Size = new Size(700, 1);
        pnlSepBottom.TabIndex = 3;
        // 
        // pnlButtons
        // 
        pnlButtons.Controls.Add(btnCancel);
        pnlButtons.Controls.Add(btnNext);
        pnlButtons.Controls.Add(btnBack);
        pnlButtons.Dock = DockStyle.Bottom;
        pnlButtons.Location = new Point(0, 510);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(700, 50);
        pnlButtons.TabIndex = 4;
        // 
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCancel.Location = new Point(602, 12);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(85, 28);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnNext
        // 
        btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnNext.Location = new Point(510, 12);
        btnNext.Name = "btnNext";
        btnNext.Size = new Size(85, 28);
        btnNext.TabIndex = 1;
        btnNext.Text = "&Next >";
        btnNext.UseVisualStyleBackColor = true;
        btnNext.Click += btnNext_Click;
        // 
        // btnBack
        // 
        btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnBack.Location = new Point(420, 12);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(85, 28);
        btnBack.TabIndex = 2;
        btnBack.Text = "< &Back";
        btnBack.UseVisualStyleBackColor = true;
        btnBack.Click += btnBack_Click;
        // 
        // pnlWelcome
        // 
        pnlWelcome.Controls.Add(grpWelcomeTips);
        pnlWelcome.Controls.Add(chkStartMenu);
        pnlWelcome.Controls.Add(chkDesktopShortcut);
        pnlWelcome.Controls.Add(btnBrowse);
        pnlWelcome.Controls.Add(txtInstallPath);
        pnlWelcome.Controls.Add(lblInstallPathLabel);
        pnlWelcome.Controls.Add(lblWelcomeDesc);
        pnlWelcome.Controls.Add(lblWelcomeTitle);
        pnlWelcome.Location = new Point(15, 82);
        pnlWelcome.Name = "pnlWelcome";
        pnlWelcome.Size = new Size(670, 420);
        pnlWelcome.TabIndex = 2;
        // 
        // grpWelcomeTips
        // 
        grpWelcomeTips.Controls.Add(lblWelcomeTips);
        grpWelcomeTips.Location = new Point(0, 200);
        grpWelcomeTips.Name = "grpWelcomeTips";
        grpWelcomeTips.Size = new Size(660, 210);
        grpWelcomeTips.TabIndex = 0;
        grpWelcomeTips.TabStop = false;
        grpWelcomeTips.Text = "Important Information";
        // 
        // lblWelcomeTips
        // 
        lblWelcomeTips.Location = new Point(15, 22);
        lblWelcomeTips.Name = "lblWelcomeTips";
        lblWelcomeTips.Size = new Size(630, 180);
        lblWelcomeTips.TabIndex = 0;
        lblWelcomeTips.Text = resources.GetString("lblWelcomeTips.Text");
        // 
        // chkStartMenu
        // 
        chkStartMenu.AutoSize = true;
        chkStartMenu.Checked = true;
        chkStartMenu.CheckState = CheckState.Checked;
        chkStartMenu.Location = new Point(0, 165);
        chkStartMenu.Name = "chkStartMenu";
        chkStartMenu.Size = new Size(168, 19);
        chkStartMenu.TabIndex = 1;
        chkStartMenu.Text = "Create Start Menu shortcut";
        // 
        // chkDesktopShortcut
        // 
        chkDesktopShortcut.AutoSize = true;
        chkDesktopShortcut.Checked = true;
        chkDesktopShortcut.CheckState = CheckState.Checked;
        chkDesktopShortcut.Location = new Point(0, 140);
        chkDesktopShortcut.Name = "chkDesktopShortcut";
        chkDesktopShortcut.Size = new Size(153, 19);
        chkDesktopShortcut.TabIndex = 2;
        chkDesktopShortcut.Text = "Create Desktop shortcut";
        // 
        // btnBrowse
        // 
        btnBrowse.Location = new Point(580, 101);
        btnBrowse.Name = "btnBrowse";
        btnBrowse.Size = new Size(80, 25);
        btnBrowse.TabIndex = 3;
        btnBrowse.Text = "Browse...";
        btnBrowse.UseVisualStyleBackColor = true;
        btnBrowse.Click += btnBrowse_Click;
        // 
        // txtInstallPath
        // 
        txtInstallPath.Location = new Point(0, 102);
        txtInstallPath.Name = "txtInstallPath";
        txtInstallPath.Size = new Size(572, 23);
        txtInstallPath.TabIndex = 4;
        txtInstallPath.Text = "C:\\Program Files\\FollowMeFree";
        // 
        // lblInstallPathLabel
        // 
        lblInstallPathLabel.AutoSize = true;
        lblInstallPathLabel.Location = new Point(0, 80);
        lblInstallPathLabel.Name = "lblInstallPathLabel";
        lblInstallPathLabel.Size = new Size(95, 15);
        lblInstallPathLabel.TabIndex = 5;
        lblInstallPathLabel.Text = "Installation Path:";
        // 
        // lblWelcomeDesc
        // 
        lblWelcomeDesc.Location = new Point(0, 32);
        lblWelcomeDesc.Name = "lblWelcomeDesc";
        lblWelcomeDesc.Size = new Size(660, 36);
        lblWelcomeDesc.TabIndex = 6;
        lblWelcomeDesc.Text = "This wizard will install the FollowMeFree Commander application. Choose an installation directory and configure options below.";
        // 
        // lblWelcomeTitle
        // 
        lblWelcomeTitle.AutoSize = true;
        lblWelcomeTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblWelcomeTitle.Location = new Point(0, 0);
        lblWelcomeTitle.Name = "lblWelcomeTitle";
        lblWelcomeTitle.Size = new Size(91, 25);
        lblWelcomeTitle.TabIndex = 7;
        lblWelcomeTitle.Text = "Welcome";
        // 
        // pnlConnection
        // 
        pnlConnection.Controls.Add(lblConnNote);
        pnlConnection.Controls.Add(grpConnectionDetails);
        pnlConnection.Controls.Add(lblConnDesc);
        pnlConnection.Controls.Add(lblConnTitle);
        pnlConnection.Location = new Point(15, 82);
        pnlConnection.Name = "pnlConnection";
        pnlConnection.Size = new Size(670, 420);
        pnlConnection.TabIndex = 1;
        pnlConnection.Visible = false;
        // 
        // lblConnNote
        // 
        lblConnNote.ForeColor = SystemColors.GrayText;
        lblConnNote.Location = new Point(0, 310);
        lblConnNote.Name = "lblConnNote";
        lblConnNote.Size = new Size(660, 100);
        lblConnNote.TabIndex = 0;
        lblConnNote.Text = resources.GetString("lblConnNote.Text");
        // 
        // grpConnectionDetails
        // 
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
        grpConnectionDetails.Location = new Point(0, 75);
        grpConnectionDetails.Name = "grpConnectionDetails";
        grpConnectionDetails.Size = new Size(660, 220);
        grpConnectionDetails.TabIndex = 1;
        grpConnectionDetails.TabStop = false;
        grpConnectionDetails.Text = "SQL Server Connection";
        // 
        // lblTestResult
        // 
        lblTestResult.Location = new Point(160, 183);
        lblTestResult.Name = "lblTestResult";
        lblTestResult.Size = new Size(480, 20);
        lblTestResult.TabIndex = 0;
        // 
        // btnTestConnection
        // 
        btnTestConnection.Location = new Point(20, 178);
        btnTestConnection.Name = "btnTestConnection";
        btnTestConnection.Size = new Size(130, 30);
        btnTestConnection.TabIndex = 5;
        btnTestConnection.Text = "Test Connection";
        btnTestConnection.UseVisualStyleBackColor = true;
        btnTestConnection.Click += btnTestConnection_Click;
        // 
        // txtPassword
        // 
        txtPassword.Enabled = false;
        txtPassword.Location = new Point(340, 140);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(300, 23);
        txtPassword.TabIndex = 4;
        txtPassword.UseSystemPasswordChar = true;
        txtPassword.TextChanged += ConnectionField_TextChanged;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(340, 120);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(60, 15);
        lblPassword.TabIndex = 8;
        lblPassword.Text = "Password:";
        // 
        // txtUsername
        // 
        txtUsername.Enabled = false;
        txtUsername.Location = new Point(20, 140);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(300, 23);
        txtUsername.TabIndex = 3;
        txtUsername.TextChanged += ConnectionField_TextChanged;
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(20, 120);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(63, 15);
        lblUsername.TabIndex = 7;
        lblUsername.Text = "Username:";
        // 
        // chkWindowsAuth
        // 
        chkWindowsAuth.AutoSize = true;
        chkWindowsAuth.Checked = true;
        chkWindowsAuth.CheckState = CheckState.Checked;
        chkWindowsAuth.Location = new Point(20, 88);
        chkWindowsAuth.Name = "chkWindowsAuth";
        chkWindowsAuth.Size = new Size(179, 19);
        chkWindowsAuth.TabIndex = 6;
        chkWindowsAuth.Text = "Use Windows Authentication";
        chkWindowsAuth.CheckedChanged += chkWindowsAuth_CheckedChanged;
        // 
        // txtDatabase
        // 
        txtDatabase.Location = new Point(340, 50);
        txtDatabase.Name = "txtDatabase";
        txtDatabase.Size = new Size(300, 23);
        txtDatabase.TabIndex = 2;
        txtDatabase.Text = "FMFData";
        txtDatabase.TextChanged += ConnectionField_TextChanged;
        // 
        // lblDatabase
        // 
        lblDatabase.AutoSize = true;
        lblDatabase.Location = new Point(340, 30);
        lblDatabase.Name = "lblDatabase";
        lblDatabase.Size = new Size(58, 15);
        lblDatabase.TabIndex = 9;
        lblDatabase.Text = "Database:";
        // 
        // txtServer
        // 
        txtServer.Location = new Point(20, 50);
        txtServer.Name = "txtServer";
        txtServer.Size = new Size(300, 23);
        txtServer.TabIndex = 1;
        txtServer.Text = "localhost\\sqlexpress";
        txtServer.TextChanged += ConnectionField_TextChanged;
        // 
        // lblServer
        // 
        lblServer.AutoSize = true;
        lblServer.Location = new Point(20, 30);
        lblServer.Name = "lblServer";
        lblServer.Size = new Size(42, 15);
        lblServer.TabIndex = 10;
        lblServer.Text = "Server:";
        // 
        // lblConnDesc
        // 
        lblConnDesc.Location = new Point(0, 32);
        lblConnDesc.Name = "lblConnDesc";
        lblConnDesc.Size = new Size(660, 36);
        lblConnDesc.TabIndex = 2;
        lblConnDesc.Text = "Enter the SQL Server connection details for the FMFData database. You must test the connection before proceeding with the installation.";
        // 
        // lblConnTitle
        // 
        lblConnTitle.AutoSize = true;
        lblConnTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblConnTitle.Location = new Point(0, 0);
        lblConnTitle.Name = "lblConnTitle";
        lblConnTitle.Size = new Size(193, 25);
        lblConnTitle.TabIndex = 3;
        lblConnTitle.Text = "Database Connection";
        // 
        // pnlProgress
        // 
        pnlProgress.Controls.Add(txtLog);
        pnlProgress.Controls.Add(progressBar);
        pnlProgress.Controls.Add(lblProgressTitle);
        pnlProgress.Location = new Point(15, 82);
        pnlProgress.Name = "pnlProgress";
        pnlProgress.Size = new Size(670, 420);
        pnlProgress.TabIndex = 0;
        pnlProgress.Visible = false;
        // 
        // txtLog
        // 
        txtLog.BackColor = SystemColors.Window;
        txtLog.Font = new Font("Consolas", 9F);
        txtLog.Location = new Point(0, 72);
        txtLog.Multiline = true;
        txtLog.Name = "txtLog";
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = ScrollBars.Vertical;
        txtLog.Size = new Size(660, 342);
        txtLog.TabIndex = 0;
        txtLog.WordWrap = false;
        // 
        // progressBar
        // 
        progressBar.Location = new Point(0, 35);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(660, 25);
        progressBar.TabIndex = 1;
        // 
        // lblProgressTitle
        // 
        lblProgressTitle.AutoSize = true;
        lblProgressTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblProgressTitle.Location = new Point(0, 0);
        lblProgressTitle.Name = "lblProgressTitle";
        lblProgressTitle.Size = new Size(89, 20);
        lblProgressTitle.TabIndex = 2;
        lblProgressTitle.Text = "Preparing...";
        // 
        // InstallerForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 560);
        Controls.Add(pnlProgress);
        Controls.Add(pnlConnection);
        Controls.Add(pnlWelcome);
        Controls.Add(pnlSepBottom);
        Controls.Add(pnlButtons);
        Controls.Add(pnlSepTop);
        Controls.Add(pnlBanner);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "InstallerForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FollowMeFree Installer";
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
