namespace FollowMeFree
{
    partial class ServiceConfigProgressForm
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
            this.memoEditLog = new DevExpress.XtraEditors.MemoEdit();
            this.marqueeProgressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemLog = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemProgress = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.memoEditLog);
            this.layoutControl1.Controls.Add(this.marqueeProgressBar);
            this.layoutControl1.Controls.Add(this.simpleButtonClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(484, 331);
            this.layoutControl1.TabIndex = 0;
            // 
            // memoEditLog
            // 
            this.memoEditLog.Location = new System.Drawing.Point(12, 28);
            this.memoEditLog.Name = "memoEditLog";
            this.memoEditLog.Properties.ReadOnly = true;
            this.memoEditLog.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.memoEditLog.Size = new System.Drawing.Size(460, 239);
            this.memoEditLog.StyleController = this.layoutControl1;
            this.memoEditLog.TabIndex = 0;
            // 
            // marqueeProgressBar
            // 
            this.marqueeProgressBar.EditValue = 0;
            this.marqueeProgressBar.Location = new System.Drawing.Point(12, 271);
            this.marqueeProgressBar.Name = "marqueeProgressBar";
            this.marqueeProgressBar.Size = new System.Drawing.Size(460, 20);
            this.marqueeProgressBar.StyleController = this.layoutControl1;
            this.marqueeProgressBar.TabIndex = 1;
            // 
            // simpleButtonClose
            // 
            this.simpleButtonClose.Location = new System.Drawing.Point(387, 295);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new System.Drawing.Size(85, 24);
            this.simpleButtonClose.StyleController = this.layoutControl1;
            this.simpleButtonClose.TabIndex = 2;
            this.simpleButtonClose.Text = "Close";
            this.simpleButtonClose.Click += new System.EventHandler(this.simpleButtonClose_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemLog,
            this.layoutControlItemProgress,
            this.layoutControlItemClose,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(484, 331);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemLog
            // 
            this.layoutControlItemLog.Control = this.memoEditLog;
            this.layoutControlItemLog.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemLog.Name = "layoutControlItemLog";
            this.layoutControlItemLog.Size = new System.Drawing.Size(464, 259);
            this.layoutControlItemLog.Text = "Progress";
            this.layoutControlItemLog.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemLog.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItemProgress
            // 
            this.layoutControlItemProgress.Control = this.marqueeProgressBar;
            this.layoutControlItemProgress.Location = new System.Drawing.Point(0, 259);
            this.layoutControlItemProgress.Name = "layoutControlItemProgress";
            this.layoutControlItemProgress.Size = new System.Drawing.Size(464, 24);
            this.layoutControlItemProgress.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemProgress.TextVisible = false;
            // 
            // layoutControlItemClose
            // 
            this.layoutControlItemClose.Control = this.simpleButtonClose;
            this.layoutControlItemClose.Location = new System.Drawing.Point(375, 283);
            this.layoutControlItemClose.Name = "layoutControlItemClose";
            this.layoutControlItemClose.Size = new System.Drawing.Size(89, 28);
            this.layoutControlItemClose.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemClose.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 283);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(375, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ServiceConfigProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 331);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.Image = global::FollowMeFree.Properties.Resources.FMFappIcon1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceConfigProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Service Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEditLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.MemoEdit memoEditLog;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBar;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClose;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemLog;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemProgress;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemClose;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
