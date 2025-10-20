using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        //Somehow, I missed all the new fields the lab requires. These are said new fields. Im not deleting the ones that shouldnt be there for now.
        public string? Summary { get; set; }
        public string? CoverPage { get; set; }
        public string? Publisher { get; set; }
        public int PublisherID { get; set; }
        public int AuthorID { get; set; }





    }
}
