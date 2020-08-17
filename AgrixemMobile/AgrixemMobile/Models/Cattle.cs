using System;
using System.Collections.Generic;
using System.Text;

namespace AgrixemMobile.Models
{
    public class Cattle
    {
        public long ID { get; set; }
        public long TagID { get; set; }
        public int FarmID { get; set; }
        public int CurrentValue { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Status { get; set; }
    }
}
