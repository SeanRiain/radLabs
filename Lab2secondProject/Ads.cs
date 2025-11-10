namespace Lab2secondProject
{
    
    public enum AdType
    {
        Free,
        Paid
    }
    public class Ads
    {
       public int ID { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

        public AdType Type { get; set; }
        public int SellerID { get; set; } //FK
        public int CategoryID { get; set; } //FK
    }
}
