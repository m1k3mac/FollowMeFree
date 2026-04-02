using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FollowMeFree
{
    public partial class ConfigurationForm : DevExpress.XtraEditors.XtraForm
    {
        private FMFDataEntities _dbContext;
        private Config _config;

        public ConfigurationForm()
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
            txtAPIAllowedNetwork.Text = _config.APIAllowedNetwork ?? string.Empty;
        }

        private void btnBrowseJobFilePath_Click(object sender, EventArgs e)
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

        private void btnClearAPIAllowedNetwork_Click(object sender, EventArgs e)
        {
            txtAPIAllowedNetwork.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            var apiNetwork = txtAPIAllowedNetwork.Text.Trim();
            _config.APIAllowedNetwork = string.IsNullOrEmpty(apiNetwork) ? null : apiNetwork;

            try
            {
                _dbContext.SaveChanges();

                XtraMessageBox.Show("Configuration saved successfully.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
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
    }
}
