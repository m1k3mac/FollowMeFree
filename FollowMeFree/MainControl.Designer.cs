namespace FollowMeFree
{
    partial class MainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.digitalGauge3 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.digitalBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.printJobBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPages = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateTimePrinted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.digitalGauge3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printJobBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gaugeControl1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(841, 553);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.digitalGauge3});
            this.gaugeControl1.Location = new System.Drawing.Point(12, 12);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(149, 529);
            this.gaugeControl1.TabIndex = 5;
            // 
            // digitalGauge3
            // 
            this.digitalGauge3.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#0D8097");
            this.digitalGauge3.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#02F0F7");
            this.digitalGauge3.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] {
            this.digitalBackgroundLayerComponent1});
            this.digitalGauge3.Bounds = new System.Drawing.Rectangle(6, 6, 137, 517);
            this.digitalGauge3.DigitCount = 5;
            this.digitalGauge3.Name = "digitalGauge3";
            this.digitalGauge3.Padding = new DevExpress.XtraGauges.Core.Base.TextSpacing(26, 20, 26, 20);
            this.digitalGauge3.Text = "00.000";
            // 
            // digitalBackgroundLayerComponent1
            // 
            this.digitalBackgroundLayerComponent1.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(265.8125F, 99.9625F);
            this.digitalBackgroundLayerComponent1.Name = "digitalBackgroundLayerComponent1";
            this.digitalBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style17;
            this.digitalBackgroundLayerComponent1.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(26F, 0F);
            this.digitalBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.printJobBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(165, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(664, 529);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // printJobBindingSource
            // 
            this.printJobBindingSource.DataSource = typeof(FollowMeFree.PrintJob);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.MintCream;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colJobId,
            this.colUserName,
            this.colDocumentName,
            this.colPages,
            this.colDataType,
            this.colDepartment,
            this.colDateTimePrinted});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            // 
            // colDocumentName
            // 
            this.colDocumentName.FieldName = "DocumentName";
            this.colDocumentName.Name = "colDocumentName";
            this.colDocumentName.Visible = true;
            this.colDocumentName.VisibleIndex = 2;
            // 
            // colJobId
            // 
            this.colJobId.FieldName = "JobId";
            this.colJobId.Name = "colJobId";
            this.colJobId.Visible = true;
            this.colJobId.VisibleIndex = 0;
            // 
            // colPages
            // 
            this.colPages.FieldName = "Pages";
            this.colPages.Name = "colPages";
            this.colPages.Visible = true;
            this.colPages.VisibleIndex = 3;
            // 
            // colDateTimePrinted
            // 
            this.colDateTimePrinted.FieldName = "DateTimePrinted";
            this.colDateTimePrinted.Name = "colDateTimePrinted";
            this.colDateTimePrinted.Visible = true;
            this.colDateTimePrinted.VisibleIndex = 6;
            // 
            // colDataType
            // 
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 4;
            // 
            // colDepartment
            // 
            this.colDepartment.Caption = "Department";
            this.colDepartment.FieldName = "Department.DepartmentName";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(841, 553);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(153, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(668, 533);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gaugeControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(153, 533);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem_Refresh});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Refresh)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem_Refresh
            // 
            this.barButtonItem_Refresh.Caption = "Refresh";
            this.barButtonItem_Refresh.Id = 0;
            this.barButtonItem_Refresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_Refresh.ImageOptions.SvgImage")));
            this.barButtonItem_Refresh.Name = "barButtonItem_Refresh";
            this.barButtonItem_Refresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem_Refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Refresh_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(841, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 577);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(841, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 553);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(841, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 553);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(841, 577);
            this.Load += new System.EventHandler(this.MainControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.digitalGauge3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printJobBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge digitalGauge3;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource printJobBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentName;
        private DevExpress.XtraGrid.Columns.GridColumn colJobId;
        private DevExpress.XtraGrid.Columns.GridColumn colPages;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTimePrinted;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Refresh;
    }
}
