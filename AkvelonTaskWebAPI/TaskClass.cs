using System.Text.Json.Serialization;

namespace AkvelonTaskWebAPI
{
    public class TaskClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public Enums.TaskStatus Status { get; set; }
        public int Priority { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
