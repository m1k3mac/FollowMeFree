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
        public UserManagementControl()
        {
            InitializeComponent();
            gridView1.BestFitColumns();
        }

        private void UserManagementControl_Load(object sender, EventArgs e)
        {
            _dbContext = new FMFDataEntities();
            var query = _dbContext.Users.Include(x => x.Department).OrderBy(u => u.UserName).ToList();            
            userBindingSource.DataSource = query;
            gridView1.BestFitColumns();
        }

        private void barButtonItem_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            using (var form = new NewUserForm())
            {
                form.ShowDialog();
            }

            Cursor = Cursors.Default;

            var query = _dbContext.Users.Include(x => x.Department).OrderBy(u => u.UserName).ToList();
            userBindingSource.DataSource = query;
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

            var query = _dbContext.Users.Include(x => x.Department).OrderBy(u => u.UserName).ToList();
            userBindingSource.DataSource = query;
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

            var query = _dbContext.Users.Include(x => x.Department).OrderBy(u => u.UserName).ToList();
            userBindingSource.DataSource = query;
            gridView1.BestFitColumns();
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
    }
}
