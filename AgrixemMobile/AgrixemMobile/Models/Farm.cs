using System;

namespace AgrixemMobile.Models
{
    public class Farms
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int? InitialCost { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Owner { get; set; }
        public DateTime DoP { get; set; }
    }
}

