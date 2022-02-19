using System.ComponentModel.DataAnnotations;

namespace AkvelonTaskWebAPI
{
    public class ProjectClassDTO
    {
        public string Name { get; set; } = string.Empty;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
        [Range(typeof(DateTime), "2022-1-1", "2100-1-1", ErrorMessage = "Date should be between 2022 and 2100.")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
        [Range(typeof(DateTime), "2022-1-1", "2100-1-1", ErrorMessage = "Date should be between 2022 and 2100.")]
        public DateTime EndDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
    }
}
