namespace AgrixemMobile.Models
{
    public class Goat
    {
        public long ID { get; set; }
        public int FarmID { get; set; }
        public int? EarTagNumber { get; set; }
        public int? LeftEarTatoo { get; set; }
        public int? RightEarTatoo { get; set; }
        public long RegisteredNumber { get; set; }
        public string RegisteredName { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public string Status { get; set; }
        public string Colour { get; set; }
    }
}