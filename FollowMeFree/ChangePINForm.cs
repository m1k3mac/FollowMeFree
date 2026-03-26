using System;
using System.Data.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FollowMeFree
{
    public partial class ChangePINForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly int _userId;

        public ChangePINForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void barButtonItem_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int pin;
            if (!int.TryParse(textEditPIN.Text, out pin))
            {
                XtraMessageBox.Show("PIN must be a valid number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textEditPIN.Text.Length < 4 || textEditPIN.Text.Length > 8)
            {
                XtraMessageBox.Show("PIN must be at least 4 digits and not greater than 8 digits", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new FMFDataEntities())
            {
                var user = db.Users.Find(_userId);
                if (user == null)
                {
                    XtraMessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                user.PIN = pin;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void barButtonItem_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
