using System.ComponentModel.DataAnnotations;

namespace Lab4Part2
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }

    }
}