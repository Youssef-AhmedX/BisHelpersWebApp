using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BisHelpersWebApp.Models
{
    public class WeeklyUpdates
    {

        [Key]
        [Required]
        public int WeeklyUpdatesId { get; set; }
        [Required]
        [DisplayName("Week Number")]
        public string WeekNumber { get; set; }
        [Required]
        [DisplayName("Subject Name")]
        public string SubjectName { get; set; }
        [Required]
        [DisplayName("Prof Name")]
        public string ProfName { get; set; }
        [Required]
        [DisplayName("Prof Progress")]
        public string ProfProgress { get; set; }
        [Required]
        [DisplayName("Prof Assignments")]
        public string ProfAssignments { get; set; }
        [Required]
        [DisplayName("Notes")]
        public string Note { get; set; }
    }
}
