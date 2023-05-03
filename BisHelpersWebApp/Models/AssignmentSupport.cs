using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BisHelpersWebApp.Models
{
    public class AssignmentSupport
    {
        [Key]
        [Required]
        public int AssignmentSupportId { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        [DisplayName("Author Name")]
        public string AuthorName { get; set; }
        [Required]
        [DisplayName("Subject Name")]
        public string SubjectName { get; set; }
        [Required]
        [DisplayName("Prof Name")]
        public string ProfName { get; set; }
        [Required]
        [DisplayName("Url Description")]
        public string UrlDescription { get; set; }
        [Required]
        [DisplayName("Url Type")]
        public string UrlType { get; set; }
        [Required]
        [DisplayName("Url Content")]
        public string UrlContent { get; set; }
        public int RequestStat { get; set; } = 0;
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        

    }
}
