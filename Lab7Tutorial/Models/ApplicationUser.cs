using Microsoft.AspNetCore.Identity;

namespace Lab7Tutorial.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
    }
}
