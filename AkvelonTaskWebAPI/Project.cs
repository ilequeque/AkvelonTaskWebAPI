global using AkvelonTaskWebAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace AkvelonTaskWebAPI
{
    public class Project
    {
        private DateTime endDate;

        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
        [Range(typeof(DateTime), "2022-1-1", "2100-1-1", ErrorMessage = "Date should be between 2022 and 2100.")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
        [Range(typeof(DateTime), "2022-1-1", "2100-1-1", ErrorMessage = "Date should be between 2022 and 2100.")]
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value < StartDate)
                {
                    var exception = new ArgumentException("EndDate Should be after StartDate");
                    exception.Data["StatusCode"] = 400;
                    throw exception;
                }
                endDate = value;
            }
        }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public List<TaskClass> Tasks { get; set; }
    }
}
