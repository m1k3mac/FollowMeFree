using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FollowMeFree
{
    public partial class PrinterManagementForm : DevExpress.XtraEditors.XtraForm
    {
        private FMFDataEntities _dbContext;

        public PrinterManagementForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _dbContext = new FMFDataEntities();
            var printers = _dbContext.Printers.OrderBy(p => p.Printer1).ToList();
            printerBindingSource.DataSource = printers;
        }

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var printer = new Printer();
            _dbContext.Printers.Add(printer);
            printerBindingSource.Add(printer);
            gridViewPrinters.FocusedRowHandle = gridViewPrinters.RowCount - 1;
            gridViewPrinters.FocusedColumn = gridViewPrinters.Columns["Printer1"];
            gridViewPrinters.ShowEditor();
        }

        private void barButtonItem_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewPrinters.CloseEditor();
            gridViewPrinters.UpdateCurrentRow();

            try
            {
                _dbContext.SaveChanges();
                XtraMessageBox.Show("Changes saved successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
