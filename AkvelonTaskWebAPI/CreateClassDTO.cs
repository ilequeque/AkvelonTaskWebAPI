namespace AkvelonTaskWebAPI
{
    public class CreateClassDTO
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty ;
        public Enums.TaskStatus Status { get; set; } = 0;
        public int Priority { get; set; } = 0;
        public int ProjectId { get; set; } = 1;
    }
}
