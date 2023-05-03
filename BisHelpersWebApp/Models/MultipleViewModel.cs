using BisHelpersWebApp.Areas.Identity.Data;

namespace BisHelpersWebApp.Models
{
    public class MultipleViewModel
    {

        public IEnumerable<Student> objUsersList { get; set; }
        public IEnumerable<Reports> objReportsList { get; set; }
        public IEnumerable<WeeklyUpdates> objWeeklyUpdatesList { get; set; }
        public IEnumerable<AssignmentSupport> objAssignmentSupportList { get; set; }
        public IEnumerable<SQsupport> objSQsupportList { get; set; }



    }
}
