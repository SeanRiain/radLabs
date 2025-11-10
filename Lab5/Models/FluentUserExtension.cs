using System.Text.Json.Serialization;

namespace Lab5.Models
{
    public class FluentUserExtension
    {
        public int FluentUserID { get; set; } // FK to FluentUser
        public FluentTitle Title { get; set; }
        public string Biography { get; set; } = string.Empty;
    }
}
