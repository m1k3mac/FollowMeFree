namespace FollowMeFree
{
    partial class ConfigurationForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtJobFilePath = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowseJobFilePath = new DevExpress.XtraEditors.SimpleButton();
            this.txtFMFPrinterName = new DevExpress.XtraEditors.TextEdit();
            this.txtAPIAllowedNetwork = new DevExpress.XtraEditors.TextEdit();
            this.btnClearAPIAllowedNetwork = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblAPINote = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemJobFilePath = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBrowseJobFilePath = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemFMFPrinterName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemAPIAllowedNetwork = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemClearAPIAllowedNetwork = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemAPINote = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemSave = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMFPrinterName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIAllowedNetwork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemJobFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBrowseJobFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFMFPrinterName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAPIAllowedNetwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClearAPIAllowedNetwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAPINote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSave)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtJobFilePath);
            this.layoutControl1.Controls.Add(this.btnBrowseJobFilePath);
            this.layoutControl1.Controls.Add(this.txtFMFPrinterName);
            this.layoutControl1.Controls.Add(this.txtAPIAllowedNetwork);
            this.layoutControl1.Controls.Add(this.btnClearAPIAllowedNetwork);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.lblAPINote);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(530, 230);
            this.layoutControl1.TabIndex = 0;
            // 
            // txtJobFilePath
            // 
            this.txtJobFilePath.Location = new System.Drawing.Point(137, 12);
            this.txtJobFilePath.Name = "txtJobFilePath";
            this.txtJobFilePath.Properties.NullValuePrompt = "e.g. C:\\FollowMeFree\\JobFiles";
            this.txtJobFilePath.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtJobFilePath.Size = new System.Drawing.Size(311, 20);
            this.txtJobFilePath.StyleController = this.layoutControl1;
            this.txtJobFilePath.TabIndex = 0;
            // 
            // btnBrowseJobFilePath
            // 
            this.btnBrowseJobFilePath.Location = new System.Drawing.Point(452, 12);
            this.btnBrowseJobFilePath.Name = "btnBrowseJobFilePath";
            this.btnBrowseJobFilePath.Size = new System.Drawing.Size(66, 20);
            this.btnBrowseJobFilePath.StyleController = this.layoutControl1;
            this.btnBrowseJobFilePath.TabIndex = 6;
            this.btnBrowseJobFilePath.Text = "Browse";
            this.btnBrowseJobFilePath.Click += new System.EventHandler(this.btnBrowseJobFilePath_Click);
            // 
            // txtFMFPrinterName
            // 
            this.txtFMFPrinterName.Location = new System.Drawing.Point(137, 36);
            this.txtFMFPrinterName.Name = "txtFMFPrinterName";
            this.txtFMFPrinterName.Size = new System.Drawing.Size(381, 20);
            this.txtFMFPrinterName.StyleController = this.layoutControl1;
            this.txtFMFPrinterName.TabIndex = 1;
            // 
            // txtAPIAllowedNetwork
            // 
            this.txtAPIAllowedNetwork.Location = new System.Drawing.Point(137, 60);
            this.txtAPIAllowedNetwork.Name = "txtAPIAllowedNetwork";
            this.txtAPIAllowedNetwork.Size = new System.Drawing.Size(325, 20);
            this.txtAPIAllowedNetwork.StyleController = this.layoutControl1;
            this.txtAPIAllowedNetwork.TabIndex = 2;
            // 
            // btnClearAPIAllowedNetwork
            // 
            this.btnClearAPIAllowedNetwork.Location = new System.Drawing.Point(466, 60);
            this.btnClearAPIAllowedNetwork.Name = "btnClearAPIAllowedNetwork";
            this.btnClearAPIAllowedNetwork.Size = new System.Drawing.Size(52, 20);
            this.btnClearAPIAllowedNetwork.StyleController = this.layoutControl1;
            this.btnClearAPIAllowedNetwork.TabIndex = 5;
            this.btnClearAPIAllowedNetwork.Text = "Clear";
            this.btnClearAPIAllowedNetwork.Click += new System.EventHandler(this.btnClearAPIAllowedNetwork_Click);
            // 
            // lblAPINote
            // 
            this.lblAPINote.AllowHtmlString = true;
            this.lblAPINote.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblAPINote.Appearance.Options.UseForeColor = true;
            this.lblAPINote.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblAPINote.Location = new System.Drawing.Point(12, 84);
            this.lblAPINote.Name = "lblAPINote";
            this.lblAPINote.Size = new System.Drawing.Size(506, 26);
            this.lblAPINote.StyleController = this.layoutControl1;
            this.lblAPINote.TabIndex = 3;
            this.lblAPINote.Text = "Note: It is recommended to use IIS IP address and port configuration instead. Ena" +
    "bling this adds a second layer of IP/port filtering. Leave blank to keep unconfigured.";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 140);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(506, 22);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemJobFilePath,
            this.layoutControlItemBrowseJobFilePath,
            this.layoutControlItemFMFPrinterName,
            this.layoutControlItemAPIAllowedNetwork,
            this.layoutControlItemClearAPIAllowedNetwork,
            this.layoutControlItemAPINote,
            this.emptySpaceItem1,
            this.layoutControlItemSave});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(530, 230);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemJobFilePath
            // 
            this.layoutControlItemJobFilePath.Control = this.txtJobFilePath;
            this.layoutControlItemJobFilePath.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemJobFilePath.Name = "layoutControlItemJobFilePath";
            this.layoutControlItemJobFilePath.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItemJobFilePath.Text = "Job File Path";
            this.layoutControlItemJobFilePath.TextSize = new System.Drawing.Size(113, 13);
            // 
            // layoutControlItemBrowseJobFilePath
            // 
            this.layoutControlItemBrowseJobFilePath.Control = this.btnBrowseJobFilePath;
            this.layoutControlItemBrowseJobFilePath.Location = new System.Drawing.Point(440, 0);
            this.layoutControlItemBrowseJobFilePath.Name = "layoutControlItemBrowseJobFilePath";
            this.layoutControlItemBrowseJobFilePath.Size = new System.Drawing.Size(70, 24);
            this.layoutControlItemBrowseJobFilePath.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBrowseJobFilePath.TextVisible = false;
            // 
            // layoutControlItemFMFPrinterName
            // 
            this.layoutControlItemFMFPrinterName.Control = this.txtFMFPrinterName;
            this.layoutControlItemFMFPrinterName.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItemFMFPrinterName.Name = "layoutControlItemFMFPrinterName";
            this.layoutControlItemFMFPrinterName.Size = new System.Drawing.Size(510, 24);
            this.layoutControlItemFMFPrinterName.Text = "FMF Printer Name";
            this.layoutControlItemFMFPrinterName.TextSize = new System.Drawing.Size(113, 13);
            // 
            // layoutControlItemAPIAllowedNetwork
            // 
            this.layoutControlItemAPIAllowedNetwork.Control = this.txtAPIAllowedNetwork;
            this.layoutControlItemAPIAllowedNetwork.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItemAPIAllowedNetwork.Name = "layoutControlItemAPIAllowedNetwork";
            this.layoutControlItemAPIAllowedNetwork.Size = new System.Drawing.Size(454, 24);
            this.layoutControlItemAPIAllowedNetwork.Text = "API Allowed Network";
            this.layoutControlItemAPIAllowedNetwork.TextSize = new System.Drawing.Size(113, 13);
            // 
            // layoutControlItemClearAPIAllowedNetwork
            // 
            this.layoutControlItemClearAPIAllowedNetwork.Control = this.btnClearAPIAllowedNetwork;
            this.layoutControlItemClearAPIAllowedNetwork.Location = new System.Drawing.Point(454, 48);
            this.layoutControlItemClearAPIAllowedNetwork.Name = "layoutControlItemClearAPIAllowedNetwork";
            this.layoutControlItemClearAPIAllowedNetwork.Size = new System.Drawing.Size(56, 24);
            this.layoutControlItemClearAPIAllowedNetwork.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemClearAPIAllowedNetwork.TextVisible = false;
            // 
            // layoutControlItemAPINote
            // 
            this.layoutControlItemAPINote.Control = this.lblAPINote;
            this.layoutControlItemAPINote.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItemAPINote.Name = "layoutControlItemAPINote";
            this.layoutControlItemAPINote.Size = new System.Drawing.Size(510, 30);
            this.layoutControlItemAPINote.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemAPINote.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 102);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(510, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItemSave
            // 
            this.layoutControlItemSave.Control = this.btnSave;
            this.layoutControlItemSave.Location = new System.Drawing.Point(0, 128);
            this.layoutControlItemSave.Name = "layoutControlItemSave";
            this.layoutControlItemSave.Size = new System.Drawing.Size(510, 82);
            this.layoutControlItemSave.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemSave.TextVisible = false;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 230);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtJobFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMFPrinterName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIAllowedNetwork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemJobFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBrowseJobFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFMFPrinterName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAPIAllowedNetwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClearAPIAllowedNetwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAPINote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtJobFilePath;
        private DevExpress.XtraEditors.SimpleButton btnBrowseJobFilePath;
        private DevExpress.XtraEditors.TextEdit txtFMFPrinterName;
        private DevExpress.XtraEditors.TextEdit txtAPIAllowedNetwork;
        private DevExpress.XtraEditors.SimpleButton btnClearAPIAllowedNetwork;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblAPINote;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemJobFilePath;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBrowseJobFilePath;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemFMFPrinterName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemAPIAllowedNetwork;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemClearAPIAllowedNetwork;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemAPINote;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSave;
    }
}
