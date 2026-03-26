using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FollowMeFree
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ShowControl(Control control)
        {
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
        }

        private void barButtonItem_UserManagement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowControl(new UserManagementControl());
        }
    }
}
