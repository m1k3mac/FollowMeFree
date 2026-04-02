using DevExpress.LookAndFeel;
using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FollowMeFree
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            InitializeComponent();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(SkinStyle.WXI);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (AdvancedSettingsForm.IsConfigurationRequired())
            {
                using (var form = new AdvancedSettingsForm())
                {
                    form.ShowDialog(this);
                }
            }

            ShowControl(new MainControl());
        }

        private void ShowControl(Control control)
        {
            Cursor = Cursors.WaitCursor;
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
            Cursor = Cursors.Default;
        }

        private void barButtonItem_UserManagement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            ShowControl(new UserManagementControl());            
        }        

        private void barButtonItem_PrinterManagement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var form = new PrinterManagementForm())
            {
                form.ShowDialog(this);
            }
            Cursor = Cursors.Default;
        }

        private void barButtonItem_DepartmentManagement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var form = new DepartmentManagementForm())
            {
                form.ShowDialog(this);
            }
            Cursor = Cursors.Default;
        }

        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem_Stats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowControl(new MainControl());
        }

        private void barButtonItem_Advanced_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var form = new AdvancedSettingsForm())
            {
                form.ShowDialog(this);
            }
            Cursor = Cursors.Default;
        }

        private void barButtonItem_Logs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowControl(new LogViewerControl());
        }        
    }
}
