using System.Text.Json.Serialization;

namespace Lab5.Models
{
    public class FluentUserExtension
    {
        public int FluentUserID { get; set; } // FK to FluentUser
        public Title Title { get; set; }
        public string Biography { get; set; } = string.Empty;
    }
}
