namespace FollowMeFree
{
    partial class AdvancedSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedSettingsForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton_Save = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Clear = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_APIAllowedNetwork = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_Browse = new DevExpress.XtraEditors.SimpleButton();
            this.txtJobFilePath = new DevExpress.XtraEditors.TextEdit();
            this.txtFMFPrinterName = new DevExpress.XtraEditors.TextEdit();
            this.btnClearLogs = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearPrintJobs = new DevExpress.XtraEditors.SimpleButton();
            this.btnResetDatabase = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemJobFilePath = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemFMFPrinterName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemClearLogs = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemClearPrintJobs = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemResetDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_APIAllowedNetwork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMFPrinterName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemJobFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFMFPrinterName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClearLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClearPrintJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemResetDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.simpleButton_Save);
            this.layoutControl1.Controls.Add(this.simpleButton_Clear);
            this.layoutControl1.Controls.Add(this.textEdit_APIAllowedNetwork);
            this.layoutControl1.Controls.Add(this.simpleButton_Browse);
            this.layoutControl1.Controls.Add(this.txtJobFilePath);
            this.layoutControl1.Controls.Add(this.txtFMFPrinterName);
            this.layoutControl1.Controls.Add(this.btnClearLogs);
            this.layoutControl1.Controls.Add(this.btnClearPrintJobs);
            this.layoutControl1.Controls.Add(this.btnResetDatabase);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(490, 388);
            this.layoutControl1.TabIndex = 0;
            // 
            // simpleButton_Save
            // 
            this.simpleButton_Save.Location = new System.Drawing.Point(12, 354);
            this.simpleButton_Save.Name = "simpleButton_Save";
            this.simpleButton_Save.Size = new System.Drawing.Size(466, 22);
            this.simpleButton_Save.StyleController = this.layoutControl1;
            this.simpleButton_Save.TabIndex = 9;
            this.simpleButton_Save.Text = "Save";
            this.simpleButton_Save.Click += new System.EventHandler(this.simpleButton_Save_Click);
            // 
            // simpleButton_Clear
            // 
            this.simpleButton_Clear.Location = new System.Drawing.Point(420, 62);
            this.simpleButton_Clear.Name = "simpleButton_Clear";
            this.simpleButton_Clear.Size = new System.Drawing.Size(58, 22);
            this.simpleButton_Clear.StyleController = this.layoutControl1;
            this.simpleButton_Clear.TabIndex = 8;
            this.simpleButton_Clear.Text = "Clear";
            this.simpleButton_Clear.Click += new System.EventHandler(this.simpleButton_Clear_Click);
            // 
            // textEdit_APIAllowedNetwork
            // 
            this.textEdit_APIAllowedNetwork.Location = new System.Drawing.Point(124, 62);
            this.textEdit_APIAllowedNetwork.Name = "textEdit_APIAllowedNetwork";
            this.textEdit_APIAllowedNetwork.Size = new System.Drawing.Size(292, 20);
            this.textEdit_APIAllowedNetwork.StyleController = this.layoutControl1;
            this.textEdit_APIAllowedNetwork.TabIndex = 7;
            // 
            // simpleButton_Browse
            // 
            this.simpleButton_Browse.Location = new System.Drawing.Point(420, 12);
            this.simpleButton_Browse.Name = "simpleButton_Browse";
            this.simpleButton_Browse.Size = new System.Drawing.Size(58, 22);
            this.simpleButton_Browse.StyleController = this.layoutControl1;
            this.simpleButton_Browse.TabIndex = 6;
            this.simpleButton_Browse.Text = "Browse";
            this.simpleButton_Browse.Click += new System.EventHandler(this.simpleButton_Browse_Click);
            // 
            // txtJobFilePath
            // 
            this.txtJobFilePath.Location = new System.Drawing.Point(124, 12);
            this.txtJobFilePath.Name = "txtJobFilePath";
            this.txtJobFilePath.Properties.ReadOnly = true;
            this.txtJobFilePath.Size = new System.Drawing.Size(292, 20);
            this.txtJobFilePath.StyleController = this.layoutControl1;
            this.txtJobFilePath.TabIndex = 0;
            // 
            // txtFMFPrinterName
            // 
            this.txtFMFPrinterName.Location = new System.Drawing.Point(124, 38);
            this.txtFMFPrinterName.Name = "txtFMFPrinterName";
            this.txtFMFPrinterName.Size = new System.Drawing.Size(354, 20);
            this.txtFMFPrinterName.StyleController = this.layoutControl1;
            this.txtFMFPrinterName.TabIndex = 1;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(12, 255);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(466, 22);
            this.btnClearLogs.StyleController = this.layoutControl1;
            this.btnClearLogs.TabIndex = 3;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // btnClearPrintJobs
            // 
            this.btnClearPrintJobs.Location = new System.Drawing.Point(12, 281);
            this.btnClearPrintJobs.Name = "btnClearPrintJobs";
            this.btnClearPrintJobs.Size = new System.Drawing.Size(466, 22);
            this.btnClearPrintJobs.StyleController = this.layoutControl1;
            this.btnClearPrintJobs.TabIndex = 4;
            this.btnClearPrintJobs.Text = "Clear Print Jobs";
            this.btnClearPrintJobs.Click += new System.EventHandler(this.btnClearPrintJobs_Click);
            // 
            // btnResetDatabase
            // 
            this.btnResetDatabase.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnResetDatabase.Appearance.Options.UseForeColor = true;
            this.btnResetDatabase.Location = new System.Drawing.Point(12, 307);
            this.btnResetDatabase.Name = "btnResetDatabase";
            this.btnResetDatabase.Size = new System.Drawing.Size(466, 22);
            this.btnResetDatabase.StyleController = this.layoutControl1;
            this.btnResetDatabase.TabIndex = 5;
            this.btnResetDatabase.Text = "Reset Database";
            this.btnResetDatabase.Click += new System.EventHandler(this.btnResetDatabase_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemJobFilePath,
            this.layoutControlItemFMFPrinterName,
            this.emptySpaceItem1,
            this.layoutControlItemClearLogs,
            this.layoutControlItemClearPrintJobs,
            this.layoutControlItemResetDatabase,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(490, 388);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemJobFilePath
            // 
            this.layoutControlItemJobFilePath.Control = this.txtJobFilePath;
            this.layoutControlItemJobFilePath.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemJobFilePath.Name = "layoutControlItemJobFilePath";
            this.layoutControlItemJobFilePath.Size = new System.Drawing.Size(408, 26);
            this.layoutControlItemJobFilePath.Text = "Job File Path";
            this.layoutControlItemJobFilePath.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutControlItemFMFPrinterName
            // 
            this.layoutControlItemFMFPrinterName.Control = this.txtFMFPrinterName;
            this.layoutControlItemFMFPrinterName.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItemFMFPrinterName.Name = "layoutControlItemFMFPrinterName";
            this.layoutControlItemFMFPrinterName.Size = new System.Drawing.Size(470, 24);
            this.layoutControlItemFMFPrinterName.Text = "FMF Printer Name";
            this.layoutControlItemFMFPrinterName.TextSize = new System.Drawing.Size(100, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 106);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(470, 137);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItemClearLogs
            // 
            this.layoutControlItemClearLogs.Control = this.btnClearLogs;
            this.layoutControlItemClearLogs.Location = new System.Drawing.Point(0, 243);
            this.layoutControlItemClearLogs.Name = "layoutControlItemClearLogs";
            this.layoutControlItemClearLogs.Size = new System.Drawing.Size(470, 26);
            this.layoutControlItemClearLogs.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemClearLogs.TextVisible = false;
            // 
            // layoutControlItemClearPrintJobs
            // 
            this.layoutControlItemClearPrintJobs.Control = this.btnClearPrintJobs;
            this.layoutControlItemClearPrintJobs.Location = new System.Drawing.Point(0, 269);
            this.layoutControlItemClearPrintJobs.Name = "layoutControlItemClearPrintJobs";
            this.layoutControlItemClearPrintJobs.Size = new System.Drawing.Size(470, 26);
            this.layoutControlItemClearPrintJobs.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemClearPrintJobs.TextVisible = false;
            // 
            // layoutControlItemResetDatabase
            // 
            this.layoutControlItemResetDatabase.Control = this.btnResetDatabase;
            this.layoutControlItemResetDatabase.Location = new System.Drawing.Point(0, 295);
            this.layoutControlItemResetDatabase.Name = "layoutControlItemResetDatabase";
            this.layoutControlItemResetDatabase.Size = new System.Drawing.Size(470, 26);
            this.layoutControlItemResetDatabase.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemResetDatabase.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 321);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(470, 21);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButton_Browse;
            this.layoutControlItem1.Location = new System.Drawing.Point(408, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(62, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(62, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(62, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit_APIAllowedNetwork;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(408, 26);
            this.layoutControlItem2.Text = "API Allowed Network";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton_Clear;
            this.layoutControlItem3.Location = new System.Drawing.Point(408, 50);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(62, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(62, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(62, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButton_Save;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 342);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(470, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(12, 88);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(466, 26);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Note: It is recommended to use IIS IP address and port configuration instead. Ena" +
    "bling this adds a second layer of IP/port filtering. Leave blank to keep unconfi" +
    "gured.";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.labelControl1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(470, 30);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // AdvancedSettingsForm
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 388);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("AdvancedSettingsForm.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Advanced Settings";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_APIAllowedNetwork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMFPrinterName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemJobFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFMFPrinterName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClearLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClearPrintJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemResetDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtJobFilePath;
        private DevExpress.XtraEditors.TextEdit txtFMFPrinterName;
        private DevExpress.XtraEditors.SimpleButton btnClearLogs;
        private DevExpress.XtraEditors.SimpleButton btnClearPrintJobs;
        private DevExpress.XtraEditors.SimpleButton btnResetDatabase;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemJobFilePath;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemFMFPrinterName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemClearLogs;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemClearPrintJobs;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemResetDatabase;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Browse;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit textEdit_APIAllowedNetwork;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Clear;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Save;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
