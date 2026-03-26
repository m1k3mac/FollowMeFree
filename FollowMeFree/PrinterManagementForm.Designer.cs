namespace FollowMeFree
{
    partial class PrinterManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrinterManagementForm));
            this.gridControlPrinters = new DevExpress.XtraGrid.GridControl();
            this.printerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewPrinters = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrinterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem_Add = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Save = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrinters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPrinters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlPrinters
            // 
            this.gridControlPrinters.DataSource = this.printerBindingSource;
            this.gridControlPrinters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPrinters.Location = new System.Drawing.Point(0, 24);
            this.gridControlPrinters.MainView = this.gridViewPrinters;
            this.gridControlPrinters.Name = "gridControlPrinters";
            this.gridControlPrinters.Size = new System.Drawing.Size(514, 356);
            this.gridControlPrinters.TabIndex = 0;
            this.gridControlPrinters.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPrinters});
            // 
            // printerBindingSource
            // 
            this.printerBindingSource.DataSource = typeof(FollowMeFree.Printer);
            // 
            // gridViewPrinters
            // 
            this.gridViewPrinters.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPrinterName});
            this.gridViewPrinters.GridControl = this.gridControlPrinters;
            this.gridViewPrinters.Name = "gridViewPrinters";
            this.gridViewPrinters.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewPrinters.OptionsCustomization.AllowColumnResizing = false;
            this.gridViewPrinters.OptionsCustomization.AllowFilter = false;
            this.gridViewPrinters.OptionsCustomization.AllowGroup = false;
            this.gridViewPrinters.OptionsView.ShowGroupPanel = false;
            // 
            // colPrinterName
            // 
            this.colPrinterName.Caption = "Printer Name";
            this.colPrinterName.FieldName = "Printer1";
            this.colPrinterName.Name = "colPrinterName";
            this.colPrinterName.Visible = true;
            this.colPrinterName.VisibleIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem_Add,
            this.barButtonItem_Save,
            this.barButtonItem_Close});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Add),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Save),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Close, true)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // barButtonItem_Add
            // 
            this.barButtonItem_Add.Caption = "Add";
            this.barButtonItem_Add.Id = 0;
            this.barButtonItem_Add.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_Add.ImageOptions.SvgImage")));
            this.barButtonItem_Add.Name = "barButtonItem_Add";
            this.barButtonItem_Add.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Add_ItemClick);
            // 
            // barButtonItem_Save
            // 
            this.barButtonItem_Save.Caption = "Save";
            this.barButtonItem_Save.Id = 1;
            this.barButtonItem_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_Save.ImageOptions.SvgImage")));
            this.barButtonItem_Save.Name = "barButtonItem_Save";
            this.barButtonItem_Save.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Save_ItemClick);
            // 
            // barButtonItem_Close
            // 
            this.barButtonItem_Close.Caption = "Close";
            this.barButtonItem_Close.Id = 2;
            this.barButtonItem_Close.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_Close.ImageOptions.SvgImage")));
            this.barButtonItem_Close.Name = "barButtonItem_Close";
            this.barButtonItem_Close.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Close_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(514, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 380);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(514, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 356);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(514, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 356);
            // 
            // PrinterManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 380);
            this.Controls.Add(this.gridControlPrinters);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrinterManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Printer Management";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrinters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPrinters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPrinters;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPrinters;
        private DevExpress.XtraGrid.Columns.GridColumn colPrinterName;
        private System.Windows.Forms.BindingSource printerBindingSource;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Add;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Save;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
