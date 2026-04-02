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
        grpTips = new GroupBox();
        lblTips = new Label();
        grpPrereqs = new GroupBox();
        btnRecheck = new Button();
        lblSdkStatus = new Label();
        lblHostingStatus = new Label();
        lblIisStatus = new Label();
        lblWelcomeDesc = new Label();
        lblWelcomeTitle = new Label();
        pnlConfig = new Panel();
        lblConfigNote = new Label();
        txtConnectionString = new TextBox();
        lblConnStrLabel = new Label();
        txtPort = new TextBox();
        lblPortLabel = new Label();
        txtAppPool = new TextBox();
        lblAppPoolLabel = new Label();
        txtSiteName = new TextBox();
        lblSiteNameLabel = new Label();
        chkCreateIisSite = new CheckBox();
        btnBrowse = new Button();
        txtInstallPath = new TextBox();
        lblInstallPathLabel = new Label();
        pnlProgress = new Panel();
        txtLog = new TextBox();
        progressBar = new ProgressBar();
        lblProgressTitle = new Label();
        pnlBanner.SuspendLayout();
        pnlButtons.SuspendLayout();
        pnlWelcome.SuspendLayout();
        grpTips.SuspendLayout();
        grpPrereqs.SuspendLayout();
        pnlConfig.SuspendLayout();
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
        lblBannerSubtitle.Size = new Size(114, 15);
        lblBannerSubtitle.TabIndex = 0;
        lblBannerSubtitle.Text = "Deploy the API to IIS";
        // 
        // lblBannerTitle
        // 
        lblBannerTitle.AutoSize = true;
        lblBannerTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblBannerTitle.Location = new Point(18, 10);
        lblBannerTitle.Name = "lblBannerTitle";
        lblBannerTitle.Size = new Size(289, 30);
        lblBannerTitle.TabIndex = 1;
        lblBannerTitle.Text = "FollowMeFree API Installer";
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
        pnlWelcome.Controls.Add(grpTips);
        pnlWelcome.Controls.Add(grpPrereqs);
        pnlWelcome.Controls.Add(lblWelcomeDesc);
        pnlWelcome.Controls.Add(lblWelcomeTitle);
        pnlWelcome.Location = new Point(15, 82);
        pnlWelcome.Name = "pnlWelcome";
        pnlWelcome.Size = new Size(670, 420);
        pnlWelcome.TabIndex = 2;
        // 
        // grpTips
        // 
        grpTips.Controls.Add(lblTips);
        grpTips.Location = new Point(0, 215);
        grpTips.Name = "grpTips";
        grpTips.Size = new Size(660, 200);
        grpTips.TabIndex = 0;
        grpTips.TabStop = false;
        grpTips.Text = "Important Tips";
        // 
        // lblTips
        // 
        lblTips.Location = new Point(15, 22);
        lblTips.Name = "lblTips";
        lblTips.Size = new Size(630, 170);
        lblTips.TabIndex = 0;
        lblTips.Text = resources.GetString("lblTips.Text");
        // 
        // grpPrereqs
        // 
        grpPrereqs.Controls.Add(btnRecheck);
        grpPrereqs.Controls.Add(lblSdkStatus);
        grpPrereqs.Controls.Add(lblHostingStatus);
        grpPrereqs.Controls.Add(lblIisStatus);
        grpPrereqs.Location = new Point(0, 75);
        grpPrereqs.Name = "grpPrereqs";
        grpPrereqs.Size = new Size(660, 130);
        grpPrereqs.TabIndex = 1;
        grpPrereqs.TabStop = false;
        grpPrereqs.Text = "System Prerequisites";
        // 
        // btnRecheck
        // 
        btnRecheck.Location = new Point(560, 95);
        btnRecheck.Name = "btnRecheck";
        btnRecheck.Size = new Size(82, 26);
        btnRecheck.TabIndex = 0;
        btnRecheck.Text = "Re-check";
        btnRecheck.UseVisualStyleBackColor = true;
        btnRecheck.Click += btnRecheck_Click;
        // 
        // lblSdkStatus
        // 
        lblSdkStatus.AutoSize = true;
        lblSdkStatus.Location = new Point(20, 80);
        lblSdkStatus.Name = "lblSdkStatus";
        lblSdkStatus.Size = new Size(119, 15);
        lblSdkStatus.TabIndex = 1;
        lblSdkStatus.Text = "Checking privileges...";
        // 
        // lblHostingStatus
        // 
        lblHostingStatus.AutoSize = true;
        lblHostingStatus.Location = new Point(20, 55);
        lblHostingStatus.Name = "lblHostingStatus";
        lblHostingStatus.Size = new Size(151, 15);
        lblHostingStatus.TabIndex = 2;
        lblHostingStatus.Text = "Checking Hosting Bundle...";
        // 
        // lblIisStatus
        // 
        lblIisStatus.AutoSize = true;
        lblIisStatus.Location = new Point(20, 30);
        lblIisStatus.Name = "lblIisStatus";
        lblIisStatus.Size = new Size(81, 15);
        lblIisStatus.TabIndex = 3;
        lblIisStatus.Text = "Checking IIS...";
        // 
        // lblWelcomeDesc
        // 
        lblWelcomeDesc.Location = new Point(0, 32);
        lblWelcomeDesc.Name = "lblWelcomeDesc";
        lblWelcomeDesc.Size = new Size(660, 36);
        lblWelcomeDesc.TabIndex = 2;
        lblWelcomeDesc.Text = "This wizard will deploy the FollowMeFree API and optionally configure an IIS website to host it. Review the prerequisites below before continuing.";
        // 
        // lblWelcomeTitle
        // 
        lblWelcomeTitle.AutoSize = true;
        lblWelcomeTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblWelcomeTitle.Location = new Point(0, 0);
        lblWelcomeTitle.Name = "lblWelcomeTitle";
        lblWelcomeTitle.Size = new Size(91, 25);
        lblWelcomeTitle.TabIndex = 3;
        lblWelcomeTitle.Text = "Welcome";
        // 
        // pnlConfig
        // 
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
        pnlConfig.Location = new Point(15, 82);
        pnlConfig.Name = "pnlConfig";
        pnlConfig.Size = new Size(670, 420);
        pnlConfig.TabIndex = 1;
        pnlConfig.Visible = false;
        // 
        // lblConfigNote
        // 
        lblConfigNote.ForeColor = SystemColors.GrayText;
        lblConfigNote.Location = new Point(0, 270);
        lblConfigNote.Name = "lblConfigNote";
        lblConfigNote.Size = new Size(660, 140);
        lblConfigNote.TabIndex = 0;
        lblConfigNote.Text = resources.GetString("lblConfigNote.Text");
        // 
        // txtConnectionString
        // 
        txtConnectionString.Location = new Point(0, 232);
        txtConnectionString.Name = "txtConnectionString";
        txtConnectionString.Size = new Size(660, 23);
        txtConnectionString.TabIndex = 1;
        // 
        // lblConnStrLabel
        // 
        lblConnStrLabel.AutoSize = true;
        lblConnStrLabel.Location = new Point(0, 210);
        lblConnStrLabel.Name = "lblConnStrLabel";
        lblConnStrLabel.Size = new Size(157, 15);
        lblConnStrLabel.TabIndex = 2;
        lblConnStrLabel.Text = "Database Connection String:";
        // 
        // txtPort
        // 
        txtPort.Location = new Point(20, 168);
        txtPort.Name = "txtPort";
        txtPort.Size = new Size(100, 23);
        txtPort.TabIndex = 3;
        txtPort.Text = "80";
        // 
        // lblPortLabel
        // 
        lblPortLabel.AutoSize = true;
        lblPortLabel.Location = new Point(20, 148);
        lblPortLabel.Name = "lblPortLabel";
        lblPortLabel.Size = new Size(32, 15);
        lblPortLabel.TabIndex = 4;
        lblPortLabel.Text = "Port:";
        // 
        // txtAppPool
        // 
        txtAppPool.Location = new Point(340, 112);
        txtAppPool.Name = "txtAppPool";
        txtAppPool.Size = new Size(320, 23);
        txtAppPool.TabIndex = 5;
        txtAppPool.Text = "FollowMeFreeAPIPool";
        // 
        // lblAppPoolLabel
        // 
        lblAppPoolLabel.AutoSize = true;
        lblAppPoolLabel.Location = new Point(340, 92);
        lblAppPoolLabel.Name = "lblAppPoolLabel";
        lblAppPoolLabel.Size = new Size(98, 15);
        lblAppPoolLabel.TabIndex = 6;
        lblAppPoolLabel.Text = "Application Pool:";
        // 
        // txtSiteName
        // 
        txtSiteName.Location = new Point(20, 112);
        txtSiteName.Name = "txtSiteName";
        txtSiteName.Size = new Size(300, 23);
        txtSiteName.TabIndex = 7;
        txtSiteName.Text = "FollowMeFreeAPI";
        // 
        // lblSiteNameLabel
        // 
        lblSiteNameLabel.AutoSize = true;
        lblSiteNameLabel.Location = new Point(20, 92);
        lblSiteNameLabel.Name = "lblSiteNameLabel";
        lblSiteNameLabel.Size = new Size(64, 15);
        lblSiteNameLabel.TabIndex = 8;
        lblSiteNameLabel.Text = "Site Name:";
        // 
        // chkCreateIisSite
        // 
        chkCreateIisSite.AutoSize = true;
        chkCreateIisSite.Checked = true;
        chkCreateIisSite.CheckState = CheckState.Checked;
        chkCreateIisSite.Location = new Point(0, 60);
        chkCreateIisSite.Name = "chkCreateIisSite";
        chkCreateIisSite.Size = new Size(234, 19);
        chkCreateIisSite.TabIndex = 9;
        chkCreateIisSite.Text = "Create IIS Website and Application Pool";
        chkCreateIisSite.CheckedChanged += chkCreateIisSite_CheckedChanged;
        // 
        // btnBrowse
        // 
        btnBrowse.Location = new Point(580, 21);
        btnBrowse.Name = "btnBrowse";
        btnBrowse.Size = new Size(80, 25);
        btnBrowse.TabIndex = 10;
        btnBrowse.Text = "Browse...";
        btnBrowse.UseVisualStyleBackColor = true;
        btnBrowse.Click += btnBrowse_Click;
        // 
        // txtInstallPath
        // 
        txtInstallPath.Location = new Point(0, 22);
        txtInstallPath.Name = "txtInstallPath";
        txtInstallPath.Size = new Size(572, 23);
        txtInstallPath.TabIndex = 11;
        txtInstallPath.Text = "C:\\inetpub\\wwwroot\\FollowMeFreeAPI";
        // 
        // lblInstallPathLabel
        // 
        lblInstallPathLabel.AutoSize = true;
        lblInstallPathLabel.Location = new Point(0, 0);
        lblInstallPathLabel.Name = "lblInstallPathLabel";
        lblInstallPathLabel.Size = new Size(95, 15);
        lblInstallPathLabel.TabIndex = 12;
        lblInstallPathLabel.Text = "Installation Path:";
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
        Controls.Add(pnlConfig);
        Controls.Add(pnlWelcome);
        Controls.Add(pnlSepBottom);
        Controls.Add(pnlButtons);
        Controls.Add(pnlSepTop);
        Controls.Add(pnlBanner);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "InstallerForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FollowMeFree API Installer";
        pnlBanner.ResumeLayout(false);
        pnlBanner.PerformLayout();
        pnlButtons.ResumeLayout(false);
        pnlWelcome.ResumeLayout(false);
        pnlWelcome.PerformLayout();
        grpTips.ResumeLayout(false);
        grpPrereqs.ResumeLayout(false);
        grpPrereqs.PerformLayout();
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
