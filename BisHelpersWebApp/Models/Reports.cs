using System.ComponentModel.DataAnnotations;

namespace BisHelpersWebApp.Models
{
    public class Reports
    {
        [Key]
        [Required]
        public int ReportId { get; set; }
        [Required]
        public string StudentId { get; set; } 
        [Required]
        public int TwoHoursSubjectsNum { get; set; }
        [Required]
        public int ThreeHoursSubjectsNum { get; set; }
        [Required]
        public int HoursDone { get; set; }
        [Required]
        public double CurrentTotalGpa { get; set; }



    }
}
