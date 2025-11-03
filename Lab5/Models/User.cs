using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lab5
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Title
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
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Column("user_FirstName")]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Column("user_LastName")]
        [MaxLength(15)]
        public string LastName { get; set; }

        public Title title { get; set; }

        [Column("user_profile")]
        [MinLength(100)]
        public string Biography { get; set; }

        [Column("age_of_user")]
        [Range(0, 200)]
        public int Age { get; set; }
    }
}
