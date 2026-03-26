using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FollowMeFree
{
    public partial class NewUserForm : DevExpress.XtraEditors.XtraForm
    {
        public NewUserForm()
        {
            InitializeComponent();
            LoadDepartments();
            LoadPrinters();
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

            int pin;
            if (!int.TryParse(textEditPIN.Text, out pin))
            {
                XtraMessageBox.Show("PIN must be a valid number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string allowedPrinterIds = GetSelectedPrinterIds();

            using (var db = new FMFDataEntities())
            {
                var user = new User
                {
                    UserName = textEditUserName.Text.Trim(),
                    FirstName = textEditFirstName.Text.Trim(),
                    Surname = textEditSurname.Text.Trim(),
                    DepartmentId = (int)lookUpEditDepartment.EditValue,
                    PIN = pin,
                    AllowedPrinterIds = allowedPrinterIds
                };

                db.Users.Add(user);
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
