using System.Configuration;

namespace FollowMeFree.API.Services
{
    public class PrintJobFileSettings
    {
        public string JobFilePath { get; }

        public PrintJobFileSettings()
        {
            var appConfigPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "FollowMeFree", "App.config");
            var configMap = new ExeConfigurationFileMap { ExeConfigFilename = Path.GetFullPath(appConfigPath) };
            var config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var settingsGroup = config.GetSectionGroup("applicationSettings");
            var section = settingsGroup?.Sections["FollowMeFree.Properties.Settings"] as ClientSettingsSection;
            var setting = section?.Settings.Get("JobFilePath");
            JobFilePath = setting?.Value?.ValueXml?.InnerText ?? string.Empty;
        }
    }
}
