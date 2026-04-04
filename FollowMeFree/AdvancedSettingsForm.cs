using DevExpress.XtraEditors;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FollowMeFree
{
    public partial class AdvancedSettingsForm : DevExpress.XtraEditors.XtraForm
    {
        private FMFDataEntities _dbContext;
        private Config _config;        

        public AdvancedSettingsForm()
        {
            InitializeComponent();            
            LoadData();
        }

        private void LoadData()
        {
            _dbContext = new FMFDataEntities();
            _config = _dbContext.Configs.FirstOrDefault();
            if (_config == null)
            {
                _config = new Config();
                _dbContext.Configs.Add(_config);
                _dbContext.SaveChanges();
            }
            txtJobFilePath.Text = _config.JobFilePath ?? string.Empty;
            txtFMFPrinterName.Text = _config.FMFPrinterName ?? string.Empty;
            textEdit_APIAllowedNetwork.Text = _config.APIAllowedNetwork ?? string.Empty;
        }        

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "Are you sure you want to clear all logs? This action cannot be undone.",
                "Clear Logs",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _dbContext.Database.ExecuteSqlCommand("DELETE FROM [Logs]");
                XtraMessageBox.Show("All logs have been cleared.", "Clear Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error clearing logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearPrintJobs_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "Are you sure you want to clear all print jobs? This action cannot be undone.",
                "Clear Print Jobs",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _dbContext.Database.ExecuteSqlCommand("DELETE FROM [PrintJobs]");
                XtraMessageBox.Show("All print jobs have been cleared.", "Clear Print Jobs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error clearing print jobs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetDatabase_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "Are you sure you want to reset the database? This will delete all data except configuration settings. This action cannot be undone.",
                "Reset Database",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _dbContext.Database.ExecuteSqlCommand("DELETE FROM [PrintJobs]");
                _dbContext.Database.ExecuteSqlCommand("DELETE FROM [Users]");
                _dbContext.Database.ExecuteSqlCommand("DELETE FROM [Logs]");
                _dbContext.Database.ExecuteSqlCommand("DELETE FROM [Printers]");
                _dbContext.Database.ExecuteSqlCommand("DELETE FROM [Departments]");
                XtraMessageBox.Show("Database has been reset.", "Reset Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error resetting database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {            
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        private void simpleButton_Browse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select Job File Path folder";
                if (!string.IsNullOrWhiteSpace(txtJobFilePath.Text) && Directory.Exists(txtJobFilePath.Text))
                {
                    dialog.SelectedPath = txtJobFilePath.Text;
                }
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtJobFilePath.Text = dialog.SelectedPath;
                }
            }
        }

        private void simpleButton_Clear_Click(object sender, EventArgs e)
        {
            textEdit_APIAllowedNetwork.Text = string.Empty;
        }

        private void simpleButton_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobFilePath.Text))
            {
                XtraMessageBox.Show("Job File Path is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJobFilePath.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFMFPrinterName.Text))
            {
                XtraMessageBox.Show("FMF Printer Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFMFPrinterName.Focus();
                return;
            }

            var jobFilePath = txtJobFilePath.Text.Trim();

            try
            {
                if (!Directory.Exists(jobFilePath))
                {
                    Directory.CreateDirectory(jobFilePath);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to create the Job File Path directory: " + ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJobFilePath.Focus();
                return;
            }

            _config.JobFilePath = jobFilePath;
            _config.FMFPrinterName = txtFMFPrinterName.Text.Trim();
            var apiNetwork = textEdit_APIAllowedNetwork.Text.Trim();
            _config.APIAllowedNetwork = string.IsNullOrEmpty(apiNetwork) ? null : apiNetwork;

            try
            {
                _dbContext.SaveChanges();

                XtraMessageBox.Show("Configuration saved successfully.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error saving configuration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool IsConfigurationRequired()
        {
            using (var dbContext = new FMFDataEntities())
            {
                var config = dbContext.Configs.FirstOrDefault();
                if (config == null)
                    return true;

                if (string.IsNullOrWhiteSpace(config.JobFilePath) || string.IsNullOrWhiteSpace(config.FMFPrinterName))
                    return true;

                if (!Directory.Exists(config.JobFilePath))
                    return true;

                return false;
            }
        }

        private void simpleButtonServiceConfig_Click(object sender, EventArgs e)
        {
            using (var progressForm = new ServiceConfigProgressForm())
            {
                progressForm.ShowDialog(this);
            }
        }
    }
}
