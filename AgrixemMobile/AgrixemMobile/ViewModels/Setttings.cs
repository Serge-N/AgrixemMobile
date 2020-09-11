using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Essentials;

namespace AgrixemMobile.ViewModels
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "token";
        private const string SettingsId = "farmId";
        private const string SettingName = "FirstName";
        private const string SettingSurName = "LastName";
        private const string SettingCattle = "CattleKey";
        private const string SettingGoats = "GoatsKey";
        private static readonly string SettingsDefault = string.Empty;
        private static readonly bool DefaultTracing = false;

        #endregion

        public static string ApiToken
        {
            get => AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(SettingsKey, value);
        }
        public static string FarmId
        {
            get => AppSettings.GetValueOrDefault(SettingsId, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(SettingsId, value);
        }
        public static string Name
        {
            get => AppSettings.GetValueOrDefault(SettingName, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(SettingName, value);
        }
        public static string Surname
        {
            get => AppSettings.GetValueOrDefault(SettingSurName, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(SettingSurName, value);
        }
        public static bool CattleTracing
        {
            get => AppSettings.GetValueOrDefault(SettingCattle, DefaultTracing);
            set => AppSettings.AddOrUpdateValue(SettingCattle, value);
        }
        public static bool GoatTracing
        {
            get => AppSettings.GetValueOrDefault(SettingGoats, DefaultTracing);
            set => AppSettings.AddOrUpdateValue(SettingGoats, value);
        }
        public static bool CheckInternetConnection()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.None)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
