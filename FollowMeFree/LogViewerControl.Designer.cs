namespace FollowMeFree
{
    partial class LogViewerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.logBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colException = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.logBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(765, 585);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // logBindingSource
            // 
            this.logBindingSource.DataSource = typeof(FollowMeFree.Log);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FloralWhite;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colTimestamp,
            this.colLogLevel,
            this.colSource,
            this.colCategory,
            this.colMessage,
            this.colException});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 50;
            // 
            // colTimestamp
            // 
            this.colTimestamp.FieldName = "Timestamp";
            this.colTimestamp.Name = "colTimestamp";
            this.colTimestamp.Visible = true;
            this.colTimestamp.VisibleIndex = 1;
            this.colTimestamp.Width = 130;
            this.colTimestamp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimestamp.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            // 
            // colLogLevel
            // 
            this.colLogLevel.FieldName = "LogLevel";
            this.colLogLevel.Name = "colLogLevel";
            this.colLogLevel.Visible = true;
            this.colLogLevel.VisibleIndex = 2;
            this.colLogLevel.Width = 70;
            // 
            // colSource
            // 
            this.colSource.FieldName = "Source";
            this.colSource.Name = "colSource";
            this.colSource.Visible = true;
            this.colSource.VisibleIndex = 3;
            this.colSource.Width = 100;
            // 
            // colCategory
            // 
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 4;
            this.colCategory.Width = 100;
            // 
            // colMessage
            // 
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 5;
            this.colMessage.Width = 200;
            // 
            // colException
            // 
            this.colException.FieldName = "Exception";
            this.colException.Name = "colException";
            this.colException.Visible = true;
            this.colException.VisibleIndex = 6;
            this.colException.Width = 200;
            // 
            // LogViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "LogViewerControl";
            this.Size = new System.Drawing.Size(765, 585);
            this.Load += new System.EventHandler(this.LogViewerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource logBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn colLogLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colException;
    }
}
