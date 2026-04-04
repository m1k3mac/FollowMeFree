using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FollowMeFree
{
    public partial class DepartmentManagementForm : DevExpress.XtraEditors.XtraForm
    {
        private FMFDataEntities _dbContext;

        public DepartmentManagementForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _dbContext = new FMFDataEntities();
            var departments = _dbContext.Departments.OrderBy(d => d.DepartmentName).ToList();
            departmentBindingSource.DataSource = departments;
        }

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var department = new Department();
            _dbContext.Departments.Add(department);
            departmentBindingSource.Add(department);
            gridViewDepartments.FocusedRowHandle = gridViewDepartments.RowCount - 1;
            gridViewDepartments.FocusedColumn = gridViewDepartments.Columns["DepartmentName"];
            gridViewDepartments.ShowEditor();
        }

        private void barButtonItem_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewDepartments.CloseEditor();
            gridViewDepartments.UpdateCurrentRow();

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
