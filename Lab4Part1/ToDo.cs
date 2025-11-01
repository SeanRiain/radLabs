using System.Text.Json.Serialization;

namespace Rad301_2025_Week2_Lab2
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold
    }

    public class ToDo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Status Status { get; set; }

        public int Priority { get; set; }
    }
}
