using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowMeFree
{
    public partial class UserManagementControl : DevExpress.XtraEditors.XtraUserControl
    {
        private FMFDataEntities _dbContext;
        private bool hasDepartments;
        private bool hasPrinters;
        private Dictionary<int, string> _userPrinterNames = new Dictionary<int, string>();
        public UserManagementControl()
        {
            InitializeComponent();
            gridView1.BestFitColumns();
        }

        private void UserManagementControl_Load(object sender, EventArgs e)
        {
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            RefreshData();
        }

        private void LoadUsers()
        {
            var allPrinters = _dbContext.Printers.AsNoTracking().ToList();
            var query = _dbContext.Users.AsNoTracking().Include(x => x.Department).OrderBy(u => u.UserName).ToList();

            _userPrinterNames.Clear();
            foreach (var user in query)
            {
                if (!string.IsNullOrEmpty(user.AllowedPrinterIds))
                {
                    var printerIds = user.AllowedPrinterIds
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(id => int.Parse(id))
                        .ToList();
                    var allowedPrinters = allPrinters.Where(p => printerIds.Contains(p.Id)).Select(p => p.Printer1).ToList();
                    _userPrinterNames[user.Id] = string.Join(", ", allowedPrinters);
                }
                else
                {
                    _userPrinterNames[user.Id] = string.Empty;
                }
            }

            userBindingSource.DataSource = query;
            gridView1.BestFitColumns();
        }

        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "colPrinters" && e.IsGetData)
            {
                var user = e.Row as User;
                if (user != null && _userPrinterNames.TryGetValue(user.Id, out var printerNames))
                {
                    e.Value = printerNames;
                }
            }
        }

        private void barButtonItem_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if(!ValidateDepartmentAndPrinterSetup())
            {
                Cursor = Cursors.Default;
                return;
            }

            using (var form = new NewUserForm())
            {
                form.ShowDialog();
            }

            Cursor = Cursors.Default;

            RefreshData();
        }

        private void barButtonItem_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var user = gridView1.GetFocusedRow() as User;
            if (user == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select a user to edit.", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;

            using (var form = new EditUserForm(user.Id))
            {
                form.ShowDialog();
            }

            Cursor = Cursors.Default;

            RefreshData();
        }

        private void barButtonItem_ChangePIN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var user = gridView1.GetFocusedRow() as User;
            if (user == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select a user.", "Change PIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;

            using (var form = new ChangePINForm(user.Id))
            {
                form.ShowDialog();
            }

            Cursor = Cursors.Default;

            RefreshData();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {            
            barButtonItem_Edit_ItemClick(sender, null);
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private bool ValidateDepartmentAndPrinterSetup()
        {
            if (hasDepartments && hasPrinters)
            {
                return true;
            }

            if (!hasDepartments && !hasPrinters)
            {
                XtraMessageBox.Show("No Departments or Printers were found. Please create at least one Department and one Printer, then come back to create a new user.", "Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!hasDepartments)
            {
                XtraMessageBox.Show("No Departments were found. Please create a Department first, then come back to create a new user.", "Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            XtraMessageBox.Show("No Printers were found. Please create a Printer first, then come back to create a new user.", "Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void LoadDepartments()
        {
            using (var db = new FMFDataEntities())
            {
                var departments = db.Departments.AsNoTracking().ToList();
                hasDepartments = departments.Any();                
            }
        }

        private void LoadPrinters()
        {
            using (var db = new FMFDataEntities())
            {
                var printers = db.Printers.AsNoTracking().ToList();
                hasPrinters = printers.Any();                
            }
        }

        private void barButtonItem_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            _dbContext = new FMFDataEntities();
            LoadUsers();
            LoadDepartments();
            LoadPrinters();
        }
    }
}
