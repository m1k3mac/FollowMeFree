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
            this.txtJobFilePath = new DevExpress.XtraEditors.TextEdit();
            this.txtFMFPrinterName = new DevExpress.XtraEditors.TextEdit();
            this.btnClearLogs = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearPrintJobs = new DevExpress.XtraEditors.SimpleButton();
            this.btnResetDatabase = new DevExpress.XtraEditors.SimpleButton();
            this.lblSavedIndicator = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemJobFilePath = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemFMFPrinterName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemSavedIndicator = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemClearLogs = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemClearPrintJobs = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemResetDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMFPrinterName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemJobFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFMFPrinterName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSavedIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClearLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClearPrintJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemResetDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtJobFilePath);
            this.layoutControl1.Controls.Add(this.txtFMFPrinterName);
            this.layoutControl1.Controls.Add(this.btnClearLogs);
            this.layoutControl1.Controls.Add(this.btnClearPrintJobs);
            this.layoutControl1.Controls.Add(this.btnResetDatabase);
            this.layoutControl1.Controls.Add(this.lblSavedIndicator);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(490, 239);
            this.layoutControl1.TabIndex = 0;
            // 
            // txtJobFilePath
            // 
            this.txtJobFilePath.Location = new System.Drawing.Point(109, 12);
            this.txtJobFilePath.Name = "txtJobFilePath";
            this.txtJobFilePath.Size = new System.Drawing.Size(369, 20);
            this.txtJobFilePath.StyleController = this.layoutControl1;
            this.txtJobFilePath.TabIndex = 0;
            this.txtJobFilePath.EditValueChanged += new System.EventHandler(this.txtJobFilePath_EditValueChanged);
            // 
            // txtFMFPrinterName
            // 
            this.txtFMFPrinterName.Location = new System.Drawing.Point(109, 36);
            this.txtFMFPrinterName.Name = "txtFMFPrinterName";
            this.txtFMFPrinterName.Size = new System.Drawing.Size(369, 20);
            this.txtFMFPrinterName.StyleController = this.layoutControl1;
            this.txtFMFPrinterName.TabIndex = 1;
            this.txtFMFPrinterName.EditValueChanged += new System.EventHandler(this.txtFMFPrinterName_EditValueChanged);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(12, 99);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(466, 22);
            this.btnClearLogs.StyleController = this.layoutControl1;
            this.btnClearLogs.TabIndex = 3;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // btnClearPrintJobs
            // 
            this.btnClearPrintJobs.Location = new System.Drawing.Point(12, 125);
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
            this.btnResetDatabase.Location = new System.Drawing.Point(12, 151);
            this.btnResetDatabase.Name = "btnResetDatabase";
            this.btnResetDatabase.Size = new System.Drawing.Size(466, 22);
            this.btnResetDatabase.StyleController = this.layoutControl1;
            this.btnResetDatabase.TabIndex = 5;
            this.btnResetDatabase.Text = "Reset Database";
            this.btnResetDatabase.Click += new System.EventHandler(this.btnResetDatabase_Click);
            // 
            // lblSavedIndicator
            // 
            this.lblSavedIndicator.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblSavedIndicator.Appearance.Options.UseForeColor = true;
            this.lblSavedIndicator.Location = new System.Drawing.Point(12, 60);
            this.lblSavedIndicator.Name = "lblSavedIndicator";
            this.lblSavedIndicator.Size = new System.Drawing.Size(466, 13);
            this.lblSavedIndicator.StyleController = this.layoutControl1;
            this.lblSavedIndicator.TabIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemJobFilePath,
            this.layoutControlItemFMFPrinterName,
            this.layoutControlItemSavedIndicator,
            this.emptySpaceItem1,
            this.layoutControlItemClearLogs,
            this.layoutControlItemClearPrintJobs,
            this.layoutControlItemResetDatabase,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(490, 239);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemJobFilePath
            // 
            this.layoutControlItemJobFilePath.Control = this.txtJobFilePath;
            this.layoutControlItemJobFilePath.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemJobFilePath.Name = "layoutControlItemJobFilePath";
            this.layoutControlItemJobFilePath.Size = new System.Drawing.Size(470, 24);
            this.layoutControlItemJobFilePath.Text = "Job File Path";
            this.layoutControlItemJobFilePath.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItemFMFPrinterName
            // 
            this.layoutControlItemFMFPrinterName.Control = this.txtFMFPrinterName;
            this.layoutControlItemFMFPrinterName.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItemFMFPrinterName.Name = "layoutControlItemFMFPrinterName";
            this.layoutControlItemFMFPrinterName.Size = new System.Drawing.Size(470, 24);
            this.layoutControlItemFMFPrinterName.Text = "FMF Printer Name";
            this.layoutControlItemFMFPrinterName.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItemSavedIndicator
            // 
            this.layoutControlItemSavedIndicator.Control = this.lblSavedIndicator;
            this.layoutControlItemSavedIndicator.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItemSavedIndicator.Name = "layoutControlItemSavedIndicator";
            this.layoutControlItemSavedIndicator.Size = new System.Drawing.Size(470, 17);
            this.layoutControlItemSavedIndicator.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemSavedIndicator.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 65);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(470, 22);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItemClearLogs
            // 
            this.layoutControlItemClearLogs.Control = this.btnClearLogs;
            this.layoutControlItemClearLogs.Location = new System.Drawing.Point(0, 87);
            this.layoutControlItemClearLogs.Name = "layoutControlItemClearLogs";
            this.layoutControlItemClearLogs.Size = new System.Drawing.Size(470, 26);
            this.layoutControlItemClearLogs.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemClearLogs.TextVisible = false;
            // 
            // layoutControlItemClearPrintJobs
            // 
            this.layoutControlItemClearPrintJobs.Control = this.btnClearPrintJobs;
            this.layoutControlItemClearPrintJobs.Location = new System.Drawing.Point(0, 113);
            this.layoutControlItemClearPrintJobs.Name = "layoutControlItemClearPrintJobs";
            this.layoutControlItemClearPrintJobs.Size = new System.Drawing.Size(470, 26);
            this.layoutControlItemClearPrintJobs.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemClearPrintJobs.TextVisible = false;
            // 
            // layoutControlItemResetDatabase
            // 
            this.layoutControlItemResetDatabase.Control = this.btnResetDatabase;
            this.layoutControlItemResetDatabase.Location = new System.Drawing.Point(0, 139);
            this.layoutControlItemResetDatabase.Name = "layoutControlItemResetDatabase";
            this.layoutControlItemResetDatabase.Size = new System.Drawing.Size(470, 26);
            this.layoutControlItemResetDatabase.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemResetDatabase.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 165);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(470, 54);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // AdvancedSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 239);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtJobFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMFPrinterName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemJobFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFMFPrinterName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSavedIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClearLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClearPrintJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemResetDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtJobFilePath;
        private DevExpress.XtraEditors.TextEdit txtFMFPrinterName;
        private DevExpress.XtraEditors.SimpleButton btnClearLogs;
        private DevExpress.XtraEditors.SimpleButton btnClearPrintJobs;
        private DevExpress.XtraEditors.SimpleButton btnResetDatabase;
        private DevExpress.XtraEditors.LabelControl lblSavedIndicator;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemJobFilePath;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemFMFPrinterName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSavedIndicator;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemClearLogs;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemClearPrintJobs;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemResetDatabase;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}
