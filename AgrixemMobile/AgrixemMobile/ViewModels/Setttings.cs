using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

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
        private static readonly string SettingsDefault = string.Empty;
        

        #endregion


        public static string ApiToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }
        public static string FarmId
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsId, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsId, value);
            }
        }
        public static string Name
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingName, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingName, value);
            }
        }
        public static string Surname
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingSurName, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingSurName, value);
            }
        }


    }
}
