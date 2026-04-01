namespace FollowMeFree.API.Installer;

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

        pnlWelcome = new Panel();
        lblWelcomeTitle = new Label();
        lblWelcomeDesc = new Label();
        grpPrereqs = new GroupBox();
        lblIisStatus = new Label();
        lblHostingStatus = new Label();
        lblSdkStatus = new Label();
        btnRecheck = new Button();
        grpTips = new GroupBox();
        lblTips = new Label();

        pnlConfig = new Panel();
        lblInstallPathLabel = new Label();
        txtInstallPath = new TextBox();
        btnBrowse = new Button();
        chkCreateIisSite = new CheckBox();
        lblSiteNameLabel = new Label();
        txtSiteName = new TextBox();
        lblAppPoolLabel = new Label();
        txtAppPool = new TextBox();
        lblPortLabel = new Label();
        txtPort = new TextBox();
        lblConnStrLabel = new Label();
        txtConnectionString = new TextBox();
        lblConfigNote = new Label();

        pnlProgress = new Panel();
        lblProgressTitle = new Label();
        progressBar = new ProgressBar();
        txtLog = new TextBox();

        pnlBanner.SuspendLayout();
        pnlButtons.SuspendLayout();
        pnlWelcome.SuspendLayout();
        grpPrereqs.SuspendLayout();
        grpTips.SuspendLayout();
        pnlConfig.SuspendLayout();
        pnlProgress.SuspendLayout();
        SuspendLayout();

        // ── Banner ──────────────────────────────────────────────────
        pnlBanner.BackColor = Color.White;
        pnlBanner.Dock = DockStyle.Top;
        pnlBanner.Size = new Size(700, 70);
        pnlBanner.Controls.Add(lblBannerSubtitle);
        pnlBanner.Controls.Add(lblBannerTitle);

        lblBannerTitle.AutoSize = true;
        lblBannerTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblBannerTitle.Location = new Point(18, 10);
        lblBannerTitle.Text = "FollowMeFree API Installer";

        lblBannerSubtitle.AutoSize = true;
        lblBannerSubtitle.Font = new Font("Segoe UI", 9F);
        lblBannerSubtitle.ForeColor = Color.Gray;
        lblBannerSubtitle.Location = new Point(20, 42);
        lblBannerSubtitle.Text = "Deploy the API to IIS";

        // ── Separators ──────────────────────────────────────────────
        pnlSepTop.BackColor = SystemColors.ControlDark;
        pnlSepTop.Dock = DockStyle.Top;
        pnlSepTop.Size = new Size(700, 1);

        pnlSepBottom.BackColor = SystemColors.ControlDark;
        pnlSepBottom.Dock = DockStyle.Bottom;
        pnlSepBottom.Size = new Size(700, 1);

        // ── Buttons ─────────────────────────────────────────────────
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

        // ── Step 1 – Welcome ────────────────────────────────────────
        pnlWelcome.Location = new Point(15, 82);
        pnlWelcome.Size = new Size(670, 420);
        pnlWelcome.Controls.Add(grpTips);
        pnlWelcome.Controls.Add(grpPrereqs);
        pnlWelcome.Controls.Add(lblWelcomeDesc);
        pnlWelcome.Controls.Add(lblWelcomeTitle);

        lblWelcomeTitle.AutoSize = true;
        lblWelcomeTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblWelcomeTitle.Location = new Point(0, 0);
        lblWelcomeTitle.Text = "Welcome";

        lblWelcomeDesc.Location = new Point(0, 32);
        lblWelcomeDesc.Size = new Size(660, 36);
        lblWelcomeDesc.Text = "This wizard will deploy the FollowMeFree API and optionally " +
            "configure an IIS website to host it. Review the prerequisites below before continuing.";

        // Prerequisites group
        grpPrereqs.Location = new Point(0, 75);
        grpPrereqs.Size = new Size(660, 130);
        grpPrereqs.Text = "System Prerequisites";
        grpPrereqs.Controls.Add(btnRecheck);
        grpPrereqs.Controls.Add(lblSdkStatus);
        grpPrereqs.Controls.Add(lblHostingStatus);
        grpPrereqs.Controls.Add(lblIisStatus);

        lblIisStatus.AutoSize = true;
        lblIisStatus.Location = new Point(20, 30);
        lblIisStatus.Text = "Checking IIS...";

        lblHostingStatus.AutoSize = true;
        lblHostingStatus.Location = new Point(20, 55);
        lblHostingStatus.Text = "Checking Hosting Bundle...";

        lblSdkStatus.AutoSize = true;
        lblSdkStatus.Location = new Point(20, 80);
        lblSdkStatus.Text = "Checking privileges...";

        btnRecheck.Location = new Point(560, 95);
        btnRecheck.Size = new Size(82, 26);
        btnRecheck.Text = "Re-check";
        btnRecheck.UseVisualStyleBackColor = true;
        btnRecheck.Click += btnRecheck_Click;

        // Tips group
        grpTips.Location = new Point(0, 215);
        grpTips.Size = new Size(660, 200);
        grpTips.Text = "Important Tips";
        grpTips.Controls.Add(lblTips);

        lblTips.Location = new Point(15, 22);
        lblTips.Size = new Size(630, 170);
        lblTips.Text =
            "Before running this installer, please ensure:\r\n\r\n" +
            "1. Enable IIS via 'Turn Windows features on or off':\r\n" +
            "   - Internet Information Services > Web Management Tools > IIS Management Console\r\n" +
            "   - Internet Information Services > World Wide Web Services > Application Development Features\r\n\r\n" +
            "2. Install the ASP.NET Core 8.0 Hosting Bundle from:\r\n" +
            "   https://dotnet.microsoft.com/download/dotnet/8.0\r\n" +
            "   (Run 'iisreset' from an elevated command prompt after installation)\r\n\r\n" +
            "3. Run this installer as Administrator for IIS site creation.\r\n\r\n" +
            "The .NET SDK is NOT required on the target machine. The Hosting Bundle\r\n" +
            "provides everything needed to run ASP.NET Core apps behind IIS.";

        // ── Step 2 – Configuration ──────────────────────────────────
        pnlConfig.Location = new Point(15, 82);
        pnlConfig.Size = new Size(670, 420);
        pnlConfig.Visible = false;
        pnlConfig.Controls.Add(lblConfigNote);
        pnlConfig.Controls.Add(txtConnectionString);
        pnlConfig.Controls.Add(lblConnStrLabel);
        pnlConfig.Controls.Add(txtPort);
        pnlConfig.Controls.Add(lblPortLabel);
        pnlConfig.Controls.Add(txtAppPool);
        pnlConfig.Controls.Add(lblAppPoolLabel);
        pnlConfig.Controls.Add(txtSiteName);
        pnlConfig.Controls.Add(lblSiteNameLabel);
        pnlConfig.Controls.Add(chkCreateIisSite);
        pnlConfig.Controls.Add(btnBrowse);
        pnlConfig.Controls.Add(txtInstallPath);
        pnlConfig.Controls.Add(lblInstallPathLabel);

        lblInstallPathLabel.AutoSize = true;
        lblInstallPathLabel.Location = new Point(0, 0);
        lblInstallPathLabel.Text = "Installation Path:";

        txtInstallPath.Location = new Point(0, 22);
        txtInstallPath.Size = new Size(572, 23);
        txtInstallPath.Text = @"C:\inetpub\wwwroot\FollowMeFreeAPI";

        btnBrowse.Location = new Point(580, 21);
        btnBrowse.Size = new Size(80, 25);
        btnBrowse.Text = "Browse...";
        btnBrowse.UseVisualStyleBackColor = true;
        btnBrowse.Click += btnBrowse_Click;

        chkCreateIisSite.AutoSize = true;
        chkCreateIisSite.Checked = true;
        chkCreateIisSite.CheckState = CheckState.Checked;
        chkCreateIisSite.Location = new Point(0, 60);
        chkCreateIisSite.Text = "Create IIS Website and Application Pool";
        chkCreateIisSite.CheckedChanged += chkCreateIisSite_CheckedChanged;

        lblSiteNameLabel.AutoSize = true;
        lblSiteNameLabel.Location = new Point(20, 92);
        lblSiteNameLabel.Text = "Site Name:";

        txtSiteName.Location = new Point(20, 112);
        txtSiteName.Size = new Size(300, 23);
        txtSiteName.Text = "FollowMeFreeAPI";

        lblAppPoolLabel.AutoSize = true;
        lblAppPoolLabel.Location = new Point(340, 92);
        lblAppPoolLabel.Text = "Application Pool:";

        txtAppPool.Location = new Point(340, 112);
        txtAppPool.Size = new Size(320, 23);
        txtAppPool.Text = "FollowMeFreeAPIPool";

        lblPortLabel.AutoSize = true;
        lblPortLabel.Location = new Point(20, 148);
        lblPortLabel.Text = "Port:";

        txtPort.Location = new Point(20, 168);
        txtPort.Size = new Size(100, 23);
        txtPort.Text = "80";

        lblConnStrLabel.AutoSize = true;
        lblConnStrLabel.Location = new Point(0, 210);
        lblConnStrLabel.Text = "Database Connection String:";

        txtConnectionString.Location = new Point(0, 232);
        txtConnectionString.Size = new Size(660, 23);

        lblConfigNote.Location = new Point(0, 270);
        lblConfigNote.Size = new Size(660, 140);
        lblConfigNote.ForeColor = SystemColors.GrayText;
        lblConfigNote.Text =
            "Note: The connection string above will be written to appsettings.json in the\r\n" +
            "published output. You can also edit it manually after installation.\r\n\r\n" +
            "If 'Create IIS Website' is unchecked, files will only be published to the\r\n" +
            "specified directory and you can configure IIS manually afterwards.\r\n\r\n" +
            "If port 80 is already in use by the Default Web Site, either stop that site\r\n" +
            "first or choose a different port here (e.g. 8080).";

        // ── Step 3 – Progress ───────────────────────────────────────
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

        // ── Form ────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 560);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FollowMeFree API Installer";

        Controls.Add(pnlProgress);
        Controls.Add(pnlConfig);
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
        grpPrereqs.ResumeLayout(false);
        grpPrereqs.PerformLayout();
        grpTips.ResumeLayout(false);
        pnlConfig.ResumeLayout(false);
        pnlConfig.PerformLayout();
        pnlProgress.ResumeLayout(false);
        pnlProgress.PerformLayout();
        ResumeLayout(false);
    }

    // ── Banner ──────────────────────────────────────────────────────
    private Panel pnlBanner;
    private Label lblBannerTitle;
    private Label lblBannerSubtitle;
    private Panel pnlSepTop;
    private Panel pnlSepBottom;

    // ── Buttons ─────────────────────────────────────────────────────
    private Panel pnlButtons;
    private Button btnBack;
    private Button btnNext;
    private Button btnCancel;

    // ── Step 1 – Welcome ────────────────────────────────────────────
    private Panel pnlWelcome;
    private Label lblWelcomeTitle;
    private Label lblWelcomeDesc;
    private GroupBox grpPrereqs;
    private Label lblIisStatus;
    private Label lblHostingStatus;
    private Label lblSdkStatus;
    private Button btnRecheck;
    private GroupBox grpTips;
    private Label lblTips;

    // ── Step 2 – Configuration ──────────────────────────────────────
    private Panel pnlConfig;
    private Label lblInstallPathLabel;
    private TextBox txtInstallPath;
    private Button btnBrowse;
    private CheckBox chkCreateIisSite;
    private Label lblSiteNameLabel;
    private TextBox txtSiteName;
    private Label lblAppPoolLabel;
    private TextBox txtAppPool;
    private Label lblPortLabel;
    private TextBox txtPort;
    private Label lblConnStrLabel;
    private TextBox txtConnectionString;
    private Label lblConfigNote;

    // ── Step 3 – Progress ───────────────────────────────────────────
    private Panel pnlProgress;
    private Label lblProgressTitle;
    private ProgressBar progressBar;
    private TextBox txtLog;
}
