using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lab5.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FluentTitle
    {
        Mr,
        Mrs,
        Ms,
        Dr,
        Fr,
        Rev,
        Snr,
        Jr,
        Pvt,
        Cpr,
        Sgt,
        Cpt,
        Cmnd,
        Prof,
        HRH
    }
    public class FluentUser
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Title title { get; set; }
        public string Biography { get; set; }
        public int Age { get; set; }

        public FluentUserExtension? Extension { get; set; }

    }
}
