using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace FollowMeFree
{
    public partial class ServiceConfigProgressForm : DevExpress.XtraEditors.XtraForm
    {
        private const string ServiceName = "FollowMeFreeService";
        private readonly BackgroundWorker _worker;
        private bool _isRunning;

        public ServiceConfigProgressForm()
        {
            InitializeComponent();
            simpleButtonClose.Enabled = false;

            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += Worker_DoWork;
            _worker.ProgressChanged += Worker_ProgressChanged;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _isRunning = true;
            _worker.RunWorkerAsync();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isRunning && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void simpleButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;

            try
            {
                // Step 1 - Locate the service
                worker.ReportProgress(0, "Locating service installation...");
                string serviceExePath = GetServiceExecutablePath(ServiceName);
                if (string.IsNullOrEmpty(serviceExePath))
                {
                    worker.ReportProgress(0, $"ERROR: Could not find the installed path for service '{ServiceName}'.\nPlease ensure the FollowMeFree Service is installed.");
                    e.Result = false;
                    return;
                }
                worker.ReportProgress(0, $"Service found at: {serviceExePath}");

                string serviceDir = Path.GetDirectoryName(serviceExePath);
                string appSettingsPath = Path.Combine(serviceDir, "appsettings.json");

                if (!File.Exists(appSettingsPath))
                {
                    worker.ReportProgress(0, $"ERROR: appsettings.json not found at:\n{appSettingsPath}");
                    e.Result = false;
                    return;
                }
                worker.ReportProgress(0, "Found appsettings.json.");

                // Step 2 - Extract connection string
                worker.ReportProgress(0, "Reading connection string from App.config...");
                string efConnectionString = ConfigurationManager.ConnectionStrings["FMFDataEntities"]?.ConnectionString;
                if (string.IsNullOrEmpty(efConnectionString))
                {
                    worker.ReportProgress(0, "ERROR: Could not read the FMFDataEntities connection string from App.config.");
                    e.Result = false;
                    return;
                }

                string sqlConnectionString = ExtractSqlConnectionString(efConnectionString);
                if (string.IsNullOrEmpty(sqlConnectionString))
                {
                    worker.ReportProgress(0, "ERROR: Could not extract the SQL connection string from the Entity Framework connection string.");
                    e.Result = false;
                    return;
                }
                worker.ReportProgress(0, "Connection string extracted successfully.");

                // Remove EF-specific parameters
                sqlConnectionString = RemoveConnectionStringParameter(sqlConnectionString, "App");
                sqlConnectionString = RemoveConnectionStringParameter(sqlConnectionString, "Application Name");

                // Step 3 - Stop the service
                worker.ReportProgress(0, "Checking service status...");
                using (var sc = new ServiceController(ServiceName))
                {
                    if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
                    {
                        worker.ReportProgress(0, "Stopping the service...");
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                        worker.ReportProgress(0, "Service stopped.");
                    }
                    else
                    {
                        worker.ReportProgress(0, $"Service is currently {sc.Status}. No need to stop.");
                    }

                    // Step 4 - Update appsettings.json
                    worker.ReportProgress(0, "Updating appsettings.json with new connection string...");
                    UpdateAppSettingsConnectionString(appSettingsPath, sqlConnectionString);
                    worker.ReportProgress(0, "appsettings.json updated.");

                    // Step 5 - Grant database access to the Windows service account
                    worker.ReportProgress(0, "Granting database access to NT AUTHORITY\\SYSTEM...");
                    GrantServiceDatabaseAccess(sqlConnectionString, worker);

                    // Step 6 - Start the service
                    worker.ReportProgress(0, "Starting the service...");
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                    worker.ReportProgress(0, "Service started successfully.");
                }

                e.Result = true;
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                worker.ReportProgress(0, "ERROR: The service did not respond in time. Please check the service status manually in services.msc.");
                e.Result = false;
            }
            catch (InvalidOperationException ex)
            {
                worker.ReportProgress(0, $"ERROR: Service operation failed. Make sure you are running as Administrator.\n{ex.Message}");
                e.Result = false;
            }
            catch (Exception ex)
            {
                worker.ReportProgress(0, $"ERROR: {ex.Message}");
                e.Result = false;
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string message = e.UserState as string;
            if (message != null)
            {
                if (memoEditLog.Text.Length > 0)
                    memoEditLog.Text += Environment.NewLine;
                memoEditLog.Text += message;

                // Scroll to the end
                memoEditLog.SelectionStart = memoEditLog.Text.Length;
                memoEditLog.ScrollToCaret();
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _isRunning = false;
            marqueeProgressBar.Properties.Stopped = true;
            simpleButtonClose.Enabled = true;

            bool success = e.Result is bool && (bool)e.Result;

            if (memoEditLog.Text.Length > 0)
                memoEditLog.Text += Environment.NewLine;

            if (success)
            {
                memoEditLog.Text += Environment.NewLine + "Service configuration completed successfully.";
            }
            else
            {
                memoEditLog.Text += Environment.NewLine + "Service configuration finished with errors.";
            }

            memoEditLog.SelectionStart = memoEditLog.Text.Length;
            memoEditLog.ScrollToCaret();
        }

        #region Helper Methods

        private static string GetServiceExecutablePath(string serviceName)
        {
            using (var key = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}"))
            {
                if (key == null)
                    return null;

                string imagePath = key.GetValue("ImagePath") as string;
                if (string.IsNullOrEmpty(imagePath))
                    return null;

                imagePath = imagePath.Trim('"');
                return imagePath;
            }
        }

        private static string ExtractSqlConnectionString(string efConnectionString)
        {
            var match = Regex.Match(efConnectionString, @"provider connection string=""([^""]+)""");
            if (match.Success)
                return match.Groups[1].Value;

            return null;
        }

        private static string RemoveConnectionStringParameter(string connectionString, string parameterName)
        {
            var result = Regex.Replace(
                connectionString,
                $@"(^|;)\s*{Regex.Escape(parameterName)}\s*=[^;]*(;|$)",
                "$1",
                RegexOptions.IgnoreCase);
            return result.Trim(';').Trim();
        }

        private static void GrantServiceDatabaseAccess(string sqlConnectionString, BackgroundWorker worker)
        {
            string databaseName = ExtractDatabaseName(sqlConnectionString);
            if (string.IsNullOrEmpty(databaseName))
            {
                worker.ReportProgress(0, "WARNING: Could not determine database name from connection string. Skipping database access grant.");
                return;
            }

            // Build a connection string targeting 'master' for the server-level login
            var builder = new SqlConnectionStringBuilder(sqlConnectionString);
            builder.InitialCatalog = "master";

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                // Create login if it doesn't exist
                string createLoginSql = @"
                    IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = N'NT AUTHORITY\SYSTEM')
                    BEGIN
                        CREATE LOGIN [NT AUTHORITY\SYSTEM] FROM WINDOWS;
                    END";
                using (var cmd = new SqlCommand(createLoginSql, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                // Check if login was already present or just created
                string checkLoginSql = @"SELECT 1 FROM sys.server_principals WHERE name = N'NT AUTHORITY\SYSTEM'";
                using (var cmd = new SqlCommand(checkLoginSql, connection))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        worker.ReportProgress(0, "Login [NT AUTHORITY\\SYSTEM] is present on the server.");
                }

                // Switch to the application database
                connection.ChangeDatabase(databaseName);

                // Create database user if it doesn't exist
                string createUserSql = @"
                    IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = N'NT AUTHORITY\SYSTEM')
                    BEGIN
                        CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM];
                    END";
                using (var cmd = new SqlCommand(createUserSql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                worker.ReportProgress(0, $"User [NT AUTHORITY\\SYSTEM] is present in database [{databaseName}].");

                // Grant db_datareader and db_datawriter roles
                string grantReaderSql = @"ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\SYSTEM]";
                using (var cmd = new SqlCommand(grantReaderSql, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                string grantWriterSql = @"ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\SYSTEM]";
                using (var cmd = new SqlCommand(grantWriterSql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                worker.ReportProgress(0, "Roles db_datareader and db_datawriter granted to [NT AUTHORITY\\SYSTEM].");
            }

            worker.ReportProgress(0, "Database access granted successfully.");
        }

        private static string ExtractDatabaseName(string sqlConnectionString)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(sqlConnectionString);
                return builder.InitialCatalog;
            }
            catch
            {
                return null;
            }
        }

        private static void UpdateAppSettingsConnectionString(string appSettingsPath, string newConnectionString)
        {
            string json = File.ReadAllText(appSettingsPath);

            string escapedConnStr = newConnectionString
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"");

            string pattern = @"(""DefaultConnection""\s*:\s*"")([^""]*)("")";
            string updatedJson = Regex.Replace(
                json,
                pattern,
                $"$1{escapedConnStr}$3");

            File.WriteAllText(appSettingsPath, updatedJson);
        }

        #endregion
    }
}
