using AgrixemMobile.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

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

        //shared logic - I know, am supposed to use an interface, but...

        public static List<long> GetAnimalIDs(List<Locations> locations)
        {
            if (locations != null || locations.Count != 0)
            {
                //Get unqie IDs
                List<long> AnimalIDs = new List<long>();

                foreach (var id in locations)
                    if (!AnimalIDs.Contains(id.AnimalID))
                        AnimalIDs.Add(id.AnimalID);

                return AnimalIDs;
            }

            return null;


        }
        public static Dictionary<long, List<Locations>> AnimalLocationPairs(List<long> Ids, List<Locations> locations)
        {
            //Create animal lists
            if (Ids != null)
            {
                var LocationsForEachAnimal = new Dictionary<long, List<Locations>>();

                foreach (var ID in Ids)
                {
                    var SpecificAnimalList = locations.Where(x => x.AnimalID == ID).ToList();
                    LocationsForEachAnimal.Add(ID, SpecificAnimalList);
                };

                return LocationsForEachAnimal;
            }

            return null;

        }
        public static List<Locations> LatestLocations(Dictionary<long, List<Locations>> LocationsForEachAnimal)
        {
            Debug.WriteLine($"\n\n\n\nRecords Number:{LocationsForEachAnimal.Count}\n\n\n");
            if (LocationsForEachAnimal != null)
            {
                List<Locations> LastKnown = new List<Locations>();

                foreach (var ID in LocationsForEachAnimal.Keys)
                {

                    //get the last time stamp in that dictionary
                    var myCurrentPosition = LocationsForEachAnimal
                        .FirstOrDefault(e => e.Key == ID)
                        .Value
                        .OrderByDescending(e => e.Timestamp)
                        .FirstOrDefault();

                    LastKnown.Add(myCurrentPosition);
                }

                return LastKnown;
            }
                return null;
        }
        public static string AnimalStatus(Locations location, char animalType)
        {
            string CurrentStatus = "Ok";
            
            //based on speed
            if(animalType == 'C')
            {
                //if cattle is moving faster than 40 Km/h
                if (location.Speed > 11)
                    CurrentStatus = "Stolen";
                
            }
            else if (animalType =='G')
            {
                //if cattle is moving faster than 17 Km/h
                if (location.Speed > 5)
                    CurrentStatus = "Stolen";
            }

            //base on movement
            if (animalType == 'C')
            {
                if (HasNotMoved(location, 6))
                    CurrentStatus = "Sick";

            }
            else if (animalType == 'G')
            {
                if (HasNotMoved(location, 3))
                    CurrentStatus = "Sick";
            }

            return CurrentStatus;
        }
        private static bool HasNotMoved(Locations location, double maximum)
        {
            bool hasNotMoved = false;
            //get current time and location of the animal
            var timeNow = location.Timestamp;
            var position = new Position(location.Lat, location.Lon);
            var timeThen = timeNow.AddHours(-maximum);

            //TODO: find location this animals records at then time timeThen
            

            return hasNotMoved;
        }
    }
}
