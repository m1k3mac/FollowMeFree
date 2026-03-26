using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FollowMeFree
{
    public partial class EditUserForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly int _userId;

        public EditUserForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadDepartments();
            LoadPrinters();
            LoadUser();
        }

        private void LoadDepartments()
        {
            using (var db = new FMFDataEntities())
            {
                var departments = db.Departments.ToList();
                lookUpEditDepartment.Properties.DataSource = departments;
                lookUpEditDepartment.Properties.DisplayMember = "DepartmentName";
                lookUpEditDepartment.Properties.ValueMember = "Id";
                lookUpEditDepartment.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Department"));
            }
        }

        private void LoadPrinters()
        {
            using (var db = new FMFDataEntities())
            {
                var printers = db.Printers.ToList();
                checkedComboBoxEditPrinters.Properties.DataSource = printers;
                checkedComboBoxEditPrinters.Properties.DisplayMember = "Printer1";
                checkedComboBoxEditPrinters.Properties.ValueMember = "Id";
            }
        }

        private void LoadUser()
        {
            using (var db = new FMFDataEntities())
            {
                var user = db.Users.Find(_userId);
                if (user == null)
                {
                    XtraMessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                textEditUserName.Text = user.UserName;
                textEditFirstName.Text = user.FirstName;
                textEditSurname.Text = user.Surname;
                lookUpEditDepartment.EditValue = user.DepartmentId;

                if (!string.IsNullOrEmpty(user.AllowedPrinterIds))
                {
                    var allowedIds = user.AllowedPrinterIds.Split(',');
                    foreach (var item in checkedComboBoxEditPrinters.Properties.Items)
                    {
                        var listItem = item as DevExpress.XtraEditors.Controls.CheckedListBoxItem;
                        if (listItem != null && allowedIds.Contains(listItem.Value.ToString()))
                        {
                            listItem.CheckState = CheckState.Checked;
                        }
                    }
                }
            }
        }

        private string GetSelectedPrinterIds()
        {
            var checkedItems = checkedComboBoxEditPrinters.Properties.Items;
            var selectedIds = checkedItems
                .Cast<DevExpress.XtraEditors.Controls.CheckedListBoxItem>()
                .Where(item => item.CheckState == CheckState.Checked)
                .Select(item => item.Value.ToString());

            return string.Join(",", selectedIds);
        }

        private void barButtonItem_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textEditUserName.Text))
            {
                XtraMessageBox.Show("Username is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textEditFirstName.Text))
            {
                XtraMessageBox.Show("First Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textEditSurname.Text))
            {
                XtraMessageBox.Show("Surname is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lookUpEditDepartment.EditValue == null)
            {
                XtraMessageBox.Show("Department is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string allowedPrinterIds = GetSelectedPrinterIds();

            if (string.IsNullOrEmpty(allowedPrinterIds))
            {
                XtraMessageBox.Show("At least one printer must be selected.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                user.UserName = textEditUserName.Text.Trim();
                user.FirstName = textEditFirstName.Text.Trim();
                user.Surname = textEditSurname.Text.Trim();
                user.DepartmentId = (int)lookUpEditDepartment.EditValue;
                user.AllowedPrinterIds = allowedPrinterIds;

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
