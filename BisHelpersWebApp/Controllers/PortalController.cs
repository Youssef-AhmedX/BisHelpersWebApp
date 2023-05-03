using BisHelpersWebApp.Areas.Identity.Data;
using BisHelpersWebApp.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SelectPdf;
using System.Composition;
using System.Security.Claims;





namespace BisHelpersWebApp.Controllers
{


    public class PortalController : Controller
    {

        private readonly ApplicationDbContext _db;


        public PortalController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            if (User.IsInRole("Administrator"))
            {
                return RedirectToRoute(new
                {
                    controller = "AdminPanel",
                    action = "Index"

                });
            }

            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }

        public IActionResult Tools()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }
        public IActionResult Careers()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }

        //GPA Analysis - Part


        // Gpa analysis 
        public IActionResult GpaAnalysis()
        {
            if (User.Identity.IsAuthenticated)
            {
                var report = _db.Reports.FirstOrDefault(_report => _report.StudentId == Convert.ToString(User.FindFirstValue(ClaimTypes.NameIdentifier)));


                return View(report);
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });


        }

        //Get
        public IActionResult CreateGpaAnalysisReport()
        {

            if (User.Identity.IsAuthenticated)
            {
                var report = _db.Reports.FirstOrDefault(_report => _report.StudentId == Convert.ToString(User.FindFirstValue(ClaimTypes.NameIdentifier)));

                if (report != null)
                {

                    return RedirectToAction("GpaAnalysisReportPayment");

                }


                return View();
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGpaAnalysisReport(Reports Report)
        {

            if (Report.ThreeHoursSubjectsNum + Report.TwoHoursSubjectsNum > 6 || Report.ThreeHoursSubjectsNum + Report.TwoHoursSubjectsNum < 3)
            {
                ModelState.AddModelError("CustomError", "You Enter More Than 6 courses or less than 3 courses !");

            }
            if (Report.ThreeHoursSubjectsNum < 0)
            {
                ModelState.AddModelError("ThreeHoursSubjectsNum", "You Enter Invalid 3 Hours courses number!");
            }
            if (Report.TwoHoursSubjectsNum < 0)
            {
                ModelState.AddModelError("TwoHoursSubjectsNum", "You Enter Invalid 2 Hours courses number!");
            }
            if (Report.HoursDone > 129 || Report.HoursDone <= 0)
            {
                ModelState.AddModelError("HoursDone", "You Enter Invalid Hours!");
            }
            if (Report.CurrentTotalGpa > 4 || Report.CurrentTotalGpa <= 0)
            {
                ModelState.AddModelError("CurrentTotalGpa", "You Enter Invalid GPA!");
            }


            var UsertFromDb = _db.Users.Find(User.Identity.GetUserId());
            if (UsertFromDb != null)
            {
                UsertFromDb.Gpa = Report.CurrentTotalGpa;

                Report.StudentId = Convert.ToString(UsertFromDb.Id);

                if (UsertFromDb.Gpa >= 3.4)
                {
                    UsertFromDb.ReportPaymentStat = 1;
                }

                if (ModelState.IsValid)
                {

                    _db.Users.Update(UsertFromDb);

                    _db.Reports.Add(Report);
                    _db.SaveChanges();



                    if (UsertFromDb.ReportPaymentStat == 1 || UsertFromDb.Gpa >= 3.4)
                    {
                        return RedirectToAction("GpaAnalysis");

                    }

                    return RedirectToAction("GpaAnalysisReportPayment");

                }
                return View(Report);



            }
            return RedirectToAction("GpaAnalysis");



        }

        public IActionResult GenerateGpaAnalysisReport()
        {
            var report = _db.Reports.FirstOrDefault(_report => _report.StudentId == Convert.ToString(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            var UsertFromDb = _db.Users.Find(User.Identity.GetUserId());

            if (report == null)
            {
                return RedirectToAction("Index");
            }
            if (UsertFromDb == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });
            }

            if (UsertFromDb.ReportPaymentStat != 1)
            {
                return RedirectToRoute(new
                {
                    controller = "Portal",
                    action = "GpaAnalysis"

                });
            }

            int TwoHoursSubjectsNum = report.TwoHoursSubjectsNum;
            int ThreeHoursSubjectsNum = report.ThreeHoursSubjectsNum;
            int HoursDone = report.HoursDone;
            double CurrentTotalGpa = report.CurrentTotalGpa;

            int SubjectsNum = TwoHoursSubjectsNum + ThreeHoursSubjectsNum;
            int SemesterHours = (TwoHoursSubjectsNum * 2) + (ThreeHoursSubjectsNum * 3);
            int TotalHours = HoursDone + SemesterHours;
            int MaxPoints = HoursDone * 4;
            double CurrentTotalPoints = CurrentTotalGpa * HoursDone;



            string _SemesterTargetExcellent = SemesterTargets(3.4, CurrentTotalGpa, TwoHoursSubjectsNum, ThreeHoursSubjectsNum, TotalHours, CurrentTotalPoints, SemesterHours);
            string _SemesterTargetVeryGood = SemesterTargets(2.8, CurrentTotalGpa, TwoHoursSubjectsNum, ThreeHoursSubjectsNum, TotalHours, CurrentTotalPoints, SemesterHours);
            string _SemesterTargetGood = SemesterTargets(2.4, CurrentTotalGpa, TwoHoursSubjectsNum, ThreeHoursSubjectsNum, TotalHours, CurrentTotalPoints, SemesterHours);
            string _SemesterTargetPass = SemesterTargets(2.0, CurrentTotalGpa, TwoHoursSubjectsNum, ThreeHoursSubjectsNum, TotalHours, CurrentTotalPoints, SemesterHours);
            string _SemesterTargetWeak = SemesterTargets(1.4, CurrentTotalGpa, TwoHoursSubjectsNum, ThreeHoursSubjectsNum, TotalHours, CurrentTotalPoints, SemesterHours);

            //to save your gpa

            string _SaveGpa = SubjectGrade(SubjectPoints(SemesterPointsCalculator(TotalHours, CurrentTotalPoints, CurrentTotalGpa), TwoHoursSubjectsNum, ThreeHoursSubjectsNum));

            ReportViewModel ReportData = new ReportViewModel
            {

                CurrentTotalPoints = String.Format("{0:0.0}", CurrentTotalPoints),
                MaxPoints = Convert.ToString(MaxPoints),
                SaveGpa = _SaveGpa,
                SemesterTargetExcellent = _SemesterTargetExcellent,
                SemesterTargetPass = _SemesterTargetPass,
                SemesterTargetWeak = _SemesterTargetWeak,
                SemesterTargetVeryGood = _SemesterTargetVeryGood,
                SemesterTargetGood = _SemesterTargetGood

            };

            ViewBag.Message = ReportData;

            return View(report);
        }
        public IActionResult GpaAnalysisReportPayment()
        {
            var UsertFromDb = _db.Users.Find(User.Identity.GetUserId());
            var report = _db.Reports.FirstOrDefault(_report => _report.StudentId == Convert.ToString(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            if (report == null)
            {

                return RedirectToAction("CreateGpaAnalysisReport");

            }
            if (UsertFromDb == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });
            }

            if (UsertFromDb.ReportPaymentStat == 1)
            {
                return RedirectToRoute(new
                {
                    controller = "Portal",
                    action = "GpaAnalysis"

                });
            }
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }

        //Weekly Updates - Part

        public IActionResult WeeklyUpdatesPayment()
        {
            var UsertFromDb = _db.Users.Find(User.Identity.GetUserId());
            if (UsertFromDb == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });
            }

            if (UsertFromDb.WeeklyPaymentStat == 1)
            {
                return RedirectToRoute(new
                {
                    controller = "Portal",
                    action = "ShowWeeklyUpdates"

                });
            }

            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });

        }
        public IActionResult WeeklyUpdates()
        {
            var UsertFromDb = _db.Users.Find(User.Identity.GetUserId());
            if (UsertFromDb == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });
            }
            if (UsertFromDb.WeeklyPaymentStat == 1)
            {
                return RedirectToRoute(new
                {
                    controller = "Portal",
                    action = "ShowWeeklyUpdates"

                });
            }
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });

        }
        public IActionResult ShowWeeklyUpdates()
        {
            IEnumerable<WeeklyUpdates> Weekly = _db.WeeklyUpdates;
            var UsertFromDb = _db.Users.Find(User.Identity.GetUserId());
            if (UsertFromDb == null)
            {
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });
            }
            if (UsertFromDb.WeeklyPaymentStat != 1)
            {
                return RedirectToRoute(new
                {
                    controller = "Portal",
                    action = "WeeklyUpdatesPayment"

                });
            }
            if (User.Identity.IsAuthenticated)
            {
                return View(Weekly);
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }

        //Student Library - Part

        public IActionResult StudentLibrary()
        {
            if (User.Identity.IsAuthenticated)
            {
                var _MultipleViewModel = new MultipleViewModel();

                _MultipleViewModel.objAssignmentSupportList = _db.AssignmentSupport.ToList();
                _MultipleViewModel.objSQsupportList = _db.SQsupport.ToList();


                return View(_MultipleViewModel);
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });

        }
       
        
        
        public IActionResult AddAssignmentSupportRequest()
        {

            if (User.Identity.IsAuthenticated)
            {
                var UsertFromDb = _db.Users.Find(User.Identity.GetUserId());

                if (UsertFromDb == null)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Landingpage",
                        action = "Index"

                    });
                }
                var _MultipleViewModel = new MultipleViewModel();

                _MultipleViewModel.objAssignmentSupportList = _db.AssignmentSupport.Where(A => A.StudentId == UsertFromDb.Id).OrderBy(S => S.PublishedDate).ThenBy(S => S.ProfName).Reverse().ToList();

                IEnumerable<AssignmentSupport> AssignmentSupportList = _MultipleViewModel.objAssignmentSupportList;

                ViewBag.Message = AssignmentSupportList;

                return View();
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAssignmentSupportRequest(AssignmentSupport assignment)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var UsertFromDb = _db.Users.Find(User.Identity.GetUserId());
                    if (UsertFromDb == null)
                    {
                        return RedirectToRoute(new
                        {
                            controller = "Landingpage",
                            action = "Index"

                        });
                    }
                    assignment.StudentId = UsertFromDb.Id;
                    _db.AssignmentSupport.Add(assignment);
                    _db.SaveChanges();
                    return RedirectToAction("AddAssignmentSupportRequest");
                }
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });

            }
            return View(assignment);
        }
        
        


        public IActionResult AddSqSupportRequest()
        {

            if (User.Identity.IsAuthenticated)
            {
                var UsertFromDb = _db.Users.Find(User.Identity.GetUserId());

                if (UsertFromDb == null)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Landingpage",
                        action = "Index"

                    });
                }
                var _MultipleViewModel = new MultipleViewModel();

                _MultipleViewModel.objSQsupportList = _db.SQsupport.Where(A => A.StudentId == UsertFromDb.Id).OrderBy(S => S.PublishedDate).ThenBy(S => S.SubjectName).Reverse();

                IEnumerable<SQsupport> SqSupportList = _MultipleViewModel.objSQsupportList;

                ViewBag.Message = SqSupportList;

                return View();
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSqSupportRequest(SQsupport SQ)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var UsertFromDb = _db.Users.Find(User.Identity.GetUserId());
                    if (UsertFromDb == null)
                    {
                        return RedirectToRoute(new
                        {
                            controller = "Landingpage",
                            action = "Index"

                        });
                    }
                    SQ.StudentId = UsertFromDb.Id;
                    _db.SQsupport.Add(SQ);
                    _db.SaveChanges();
                    return RedirectToAction("AddSqSupportRequest");
                }
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });

            }
            return View(SQ);
        }

        //GPA Analysis Functions

        public static string SemesterTargets(double TargetGpa, double CurrentTotalGpa, int TwoHoursSubjectsNum, int ThreeHoursSubjectsNum, int TotalHours, double CurrentTotalPoints, int SemesterHours)
        {
            if (CurrentTotalGpa < TargetGpa)
            {


                if (MaxPointsTest(TwoHoursSubjectsNum, ThreeHoursSubjectsNum, SemesterPointsCalculator(TotalHours, CurrentTotalPoints, TargetGpa), SemesterHours) == 1)
                {

                    return PrintSuccess(SubjectGrade(SubjectPoints(SemesterPointsCalculator(TotalHours, CurrentTotalPoints, TargetGpa), TwoHoursSubjectsNum, ThreeHoursSubjectsNum)));
                }
                else
                {
                    return "Failed";
                }
            }
            return "none";
        }
        public static int MaxPointsTest(int TwoHoursSubjectsNum, int ThreeHoursSubjectsNum, double SemesterPoints, int SemesterHours)
        {
            double MaxSemesterPoints = ((TwoHoursSubjectsNum * (2 * 4)) + (ThreeHoursSubjectsNum * (3 * 4)));
            if (SemesterPoints <= MaxSemesterPoints)
            {
                return 1;
            }

            return 0;

        }
        public static double SemesterPointsCalculator(int TotalHours, double CurrentTotalPoints, double TargetGpa)
        {
            double SemesterPoints = (TargetGpa * TotalHours) - CurrentTotalPoints;
            return SemesterPoints;


        }
        public static string SubjectGrade(double SubjectPoints)
        {

            if (SubjectPoints > 3.75 && SubjectPoints <= 4)
            {
                return "A+";
            }
            else if (SubjectPoints > 3.4 && SubjectPoints <= 3.75)
            {
                return "A";

            }
            else if (SubjectPoints > 3.1 && SubjectPoints <= 3.4)
            {
                return "B+";

            }
            else if (SubjectPoints > 2.8 && SubjectPoints <= 3.1)
            {
                return "B";

            }
            else if (SubjectPoints > 2.5 && SubjectPoints <= 2.8)
            {
                return "C+";

            }
            else if (SubjectPoints > 2.25 && SubjectPoints <= 2.5)
            {
                return "C";
            }
            else if (SubjectPoints > 2 && SubjectPoints <= 2.25)
            {
                return "D+";

            }
            else if (SubjectPoints > 0 && SubjectPoints <= 2)
            {
                return "D";

            }
            else
            {
                return "Error";
            }

        }
        public static double SubjectPoints(double SemesterPoints, int TwoHoursSubjectsNum, int ThreeHoursSubjectsNum)
        {
            double SubjectPoints = (SemesterPoints - (2 * 3.75 * TwoHoursSubjectsNum)) / (3 * ThreeHoursSubjectsNum);
            return SubjectPoints;

        }
        public static string PrintSuccess(string SubjectGrade)
        {

            return SubjectGrade;
        }

    }
}
