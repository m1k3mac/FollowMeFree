using DevExpress.XtraEditors;
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
        }

        private void UserManagementControl_Load(object sender, EventArgs e)
        {
            _dbContext = new FMFDataEntities();
            var query = _dbContext.Users.Include(x => x.Department).OrderBy(u => u.UserName).ToList();            
            userBindingSource.DataSource = query;
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

        }

        private void barButtonItem_ChangePIN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }        
    }
}
