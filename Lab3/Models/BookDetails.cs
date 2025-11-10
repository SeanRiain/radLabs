using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models
{
    public class BookDetails
    {
        //fk of book, a book instances unique ID
        public int BookId { get; set; }
        public string? Summary { get; set; }
        public string? CoverPage { get; set; }
        public string? Publisher { get; set; }
        public int PublisherID { get; set; }
        public int AuthorID { get; set; }
    }
}
