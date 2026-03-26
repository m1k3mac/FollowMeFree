using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FollowMeFree
{
    public partial class AdvancedSettingsForm : DevExpress.XtraEditors.XtraForm
    {
        private FMFDataEntities _dbContext;
        private Config _config;
        private Timer _savedIndicatorTimer;

        public AdvancedSettingsForm()
        {
            InitializeComponent();
            _savedIndicatorTimer = new Timer { Interval = 2000 };
            _savedIndicatorTimer.Tick += (s, e) =>
            {
                lblSavedIndicator.Text = string.Empty;
                _savedIndicatorTimer.Stop();
            };
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
        }

        private void SaveConfig()
        {
            try
            {
                _dbContext.SaveChanges();
                lblSavedIndicator.Text = "? Saved";
                _savedIndicatorTimer.Stop();
                _savedIndicatorTimer.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtJobFilePath_EditValueChanged(object sender, EventArgs e)
        {
            _config.JobFilePath = txtJobFilePath.Text;
            SaveConfig();
        }

        private void txtFMFPrinterName_EditValueChanged(object sender, EventArgs e)
        {
            _config.FMFPrinterName = txtFMFPrinterName.Text;
            SaveConfig();
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
            base.OnFormClosed(e);
            if (_savedIndicatorTimer != null)
            {
                _savedIndicatorTimer.Stop();
                _savedIndicatorTimer.Dispose();
            }
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
