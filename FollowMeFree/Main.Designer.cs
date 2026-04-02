namespace FollowMeFree
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelContent = new System.Windows.Forms.Panel();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem_UserManagement = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_PrinterManagement = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_DepartmentManagement = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Stats = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Advanced = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Logs = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem_Config = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(790, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 635);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(790, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 635);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(790, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 635);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 115);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(5);
            this.panelContent.Size = new System.Drawing.Size(790, 520);
            this.panelContent.TabIndex = 0;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.DrawGroupsBorderMode = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem_UserManagement,
            this.barButtonItem_Close,
            this.barButtonItem_PrinterManagement,
            this.barButtonItem_DepartmentManagement,
            this.barButtonItem_Stats,
            this.barButtonItem_Advanced,
            this.barButtonItem_Logs,
            this.barButtonItem_Config});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(790, 115);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // barButtonItem_UserManagement
            // 
            this.barButtonItem_UserManagement.Caption = "User Management";
            this.barButtonItem_UserManagement.Id = 1;
            this.barButtonItem_UserManagement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_UserManagement.ImageOptions.SvgImage")));
            this.barButtonItem_UserManagement.Name = "barButtonItem_UserManagement";
            this.barButtonItem_UserManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_UserManagement_ItemClick);
            // 
            // barButtonItem_Close
            // 
            this.barButtonItem_Close.Caption = "Close";
            this.barButtonItem_Close.Id = 2;
            this.barButtonItem_Close.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_Close.ImageOptions.SvgImage")));
            this.barButtonItem_Close.Name = "barButtonItem_Close";
            this.barButtonItem_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Close_ItemClick);
            // 
            // barButtonItem_PrinterManagement
            // 
            this.barButtonItem_PrinterManagement.Caption = "Printers";
            this.barButtonItem_PrinterManagement.Id = 3;
            this.barButtonItem_PrinterManagement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_PrinterManagement.ImageOptions.SvgImage")));
            this.barButtonItem_PrinterManagement.Name = "barButtonItem_PrinterManagement";
            this.barButtonItem_PrinterManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_PrinterManagement_ItemClick);
            // 
            // barButtonItem_DepartmentManagement
            // 
            this.barButtonItem_DepartmentManagement.Caption = "Departments";
            this.barButtonItem_DepartmentManagement.Id = 4;
            this.barButtonItem_DepartmentManagement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_DepartmentManagement.ImageOptions.SvgImage")));
            this.barButtonItem_DepartmentManagement.Name = "barButtonItem_DepartmentManagement";
            this.barButtonItem_DepartmentManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_DepartmentManagement_ItemClick);
            // 
            // barButtonItem_Stats
            // 
            this.barButtonItem_Stats.Caption = "Statistics";
            this.barButtonItem_Stats.Id = 6;
            this.barButtonItem_Stats.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_Stats.ImageOptions.SvgImage")));
            this.barButtonItem_Stats.Name = "barButtonItem_Stats";
            this.barButtonItem_Stats.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Stats_ItemClick);
            // 
            // barButtonItem_Advanced
            // 
            this.barButtonItem_Advanced.Caption = "Advanced";
            this.barButtonItem_Advanced.Id = 8;
            this.barButtonItem_Advanced.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_Advanced.ImageOptions.SvgImage")));
            this.barButtonItem_Advanced.Name = "barButtonItem_Advanced";
            this.barButtonItem_Advanced.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Advanced_ItemClick);
            // 
            // barButtonItem_Logs
            // 
            this.barButtonItem_Logs.Caption = "View Logs";
            this.barButtonItem_Logs.Id = 9;
            this.barButtonItem_Logs.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_Logs.ImageOptions.SvgImage")));
            this.barButtonItem_Logs.Name = "barButtonItem_Logs";
            this.barButtonItem_Logs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Logs_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_Close, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_UserManagement, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_PrinterManagement);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_DepartmentManagement);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_Stats, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_Logs, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_Config, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_Advanced, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // barButtonItem_Config
            // 
            this.barButtonItem_Config.Caption = "Config";
            this.barButtonItem_Config.Id = 10;
            this.barButtonItem_Config.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_Config.ImageOptions.Image")));
            this.barButtonItem_Config.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_Config.ImageOptions.LargeImage")));
            this.barButtonItem_Config.Name = "barButtonItem_Config";
            this.barButtonItem_Config.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Config_ItemClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 635);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Main";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FollowMeFree";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_UserManagement;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.Panel panelContent;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_PrinterManagement;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_DepartmentManagement;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Stats;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Advanced;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Logs;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Config;
    }
}

