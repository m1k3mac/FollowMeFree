using System.Configuration;

namespace FollowMeFree.WorkerService
{
    public class AppSettingsProvider
    {
        public string JobFilePath { get; }
        public string FMFPrinterName { get; }

        public AppSettingsProvider()
        {
            // Load settings from the App.config of the FollowMeFree project
            var appConfigPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "FollowMeFree", "App.config");
            var configMap = new ExeConfigurationFileMap { ExeConfigFilename = Path.GetFullPath(appConfigPath) };
            var config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var settingsGroup = config.GetSectionGroup("applicationSettings");
            var section = settingsGroup?.Sections["FollowMeFree.Properties.Settings"] as ClientSettingsSection;
            var setting = section?.Settings.Get("JobFilePath");
            JobFilePath = setting?.Value?.ValueXml?.InnerText ?? string.Empty;

            var printerSetting = section?.Settings.Get("FMFPrinterName");
            FMFPrinterName = printerSetting?.Value?.ValueXml?.InnerText ?? string.Empty;
        }
    }
}
