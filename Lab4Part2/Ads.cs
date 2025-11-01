using System.ComponentModel.DataAnnotations;

namespace Lab4Part2
{
    public class Ads
    {
        [Key]
        public int ID { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

        public int SellerID { get; set; } //FK
        public int CategoryID { get; set; } //FK
    }
}
