using System.ComponentModel.DataAnnotations;

namespace Lab4Part2
{
    public class Sellers
    {
        [Key]
        public int SellerID { get; set; }
        public string? SellerName { get; set; }

    }
}
