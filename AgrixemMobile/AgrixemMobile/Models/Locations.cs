using System;
using System.Collections.Generic;
using System.Text;

namespace AgrixemMobile.Models
{
    public class Locations
    {
        public long ID { get; set; }
        public char AnimalType { get; set; }
        public int FarmID { get; set; }
        public long AnimalID { get; set; }
        public DateTime Time { get; set; }
        public int Temperature { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
}
