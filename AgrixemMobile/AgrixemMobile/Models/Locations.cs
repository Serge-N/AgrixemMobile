using System;
using System.Collections.Generic;
using System.Text;

namespace AgrixemMobile.Models
{
    public class Locations
    {
        public long ID { get; set; }
        public int FarmID { get; set; }
        public long AnimalID { get; set; }
        public char AnimalType { get; set; }
        public DateTime Timestamp { get; set; }
        public double? Speed { get; set; }
        public double? VerticalAccuracy { get; set; }
        public double? Accuracy { get; set; }
        public double? Altitude { get; set; }
        public double? Course { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
