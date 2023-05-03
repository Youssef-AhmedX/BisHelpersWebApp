using BisHelpersWebApp.Areas.Identity.Data;
using BisHelpersWebApp.Models;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Dynamic;

namespace BisHelpersWebApp.Controllers
{
    public class AdminPanelController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AdminPanelController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                var _MultipleViewModel = new MultipleViewModel();

                _MultipleViewModel.objUsersList = _db.Users.ToList();
                _MultipleViewModel.objReportsList = _db.Reports.ToList();
                _MultipleViewModel.objWeeklyUpdatesList = _db.WeeklyUpdates.ToList();
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



        public IActionResult AddWeeklyUpdate()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
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
        public IActionResult AddWeeklyUpdate(WeeklyUpdates weekly)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
                {
                    _db.WeeklyUpdates.Add(weekly);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });

            }
            return View(weekly);
        }



        public IActionResult AddAssignmentSupportRequest()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
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
                if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
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
                    return RedirectToAction("Index");
                }
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });

            }
            return View(assignment);
        }




        public IActionResult AddSummariesAndQuizzesRequest()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
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
        public IActionResult AddSummariesAndQuizzesRequest(SQsupport SQ)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
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
                    return RedirectToAction("Index");
                }
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });

            }
            return View(SQ);
        }




        public IActionResult AddAssignmentSupportAction(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var AsRequestFromDb = _db.AssignmentSupport.Find(id);

                if (AsRequestFromDb == null)
                {
                    return RedirectToAction("Index");
                }


                if (AsRequestFromDb.RequestStat == 0 || AsRequestFromDb.RequestStat == 2 )
                {
                    AsRequestFromDb.RequestStat = 1;
                }
                else
                {
                    return RedirectToAction("Index");

                }

                _db.AssignmentSupport.Update(AsRequestFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }
        public IActionResult RejectAssignmentSupportAction(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var AsRequestFromDb = _db.AssignmentSupport.Find(id);

                if (AsRequestFromDb == null)
                {
                    return RedirectToAction("Index");
                }


                if (AsRequestFromDb.RequestStat == 0 || AsRequestFromDb.RequestStat == 1)
                {
                    AsRequestFromDb.RequestStat = 2;
                }
                else
                {
                    return RedirectToAction("Index");

                }

                _db.AssignmentSupport.Update(AsRequestFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }
        public IActionResult RemoveAssignmentSupportAction(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var AsRequestFromDb = _db.AssignmentSupport.Find(id);

                if (AsRequestFromDb == null)
                {
                    return RedirectToAction("Index");
                }

                _db.AssignmentSupport.Remove(AsRequestFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }


        public IActionResult AddSQsupportAction(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var SQRequestFromDb = _db.SQsupport.Find(id);

                if (SQRequestFromDb == null)
                {
                    return RedirectToAction("Index");
                }


                if (SQRequestFromDb.RequestStat == 0 || SQRequestFromDb.RequestStat == 2)
                {
                    SQRequestFromDb.RequestStat = 1;
                }
                else
                {
                    return RedirectToAction("Index");

                }

                _db.SQsupport.Update(SQRequestFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }
        public IActionResult RejectSQsupportAction(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var SQRequestFromDb = _db.SQsupport.Find(id);

                if (SQRequestFromDb == null)
                {
                    return RedirectToAction("Index");
                }


                if (SQRequestFromDb.RequestStat == 0 || SQRequestFromDb.RequestStat == 1)
                {
                    SQRequestFromDb.RequestStat = 2;
                }
                else
                {
                    return RedirectToAction("Index");

                }

                _db.SQsupport.Update(SQRequestFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }
        public IActionResult RemoveSQsupportAction(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var SQRequestFromDb = _db.SQsupport.Find(id);

                if (SQRequestFromDb == null)
                {
                    return RedirectToAction("Index");
                }


                _db.SQsupport.Remove(SQRequestFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });
        }



        
        public IActionResult PrintUsersAsExcel()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                IEnumerable<Student> objUsersList = _db.Users;

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Users Report " + DateTime.Now.ToString("hh'-'mm'-'tt"));
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "ID";
                    worksheet.Cell(currentRow, 2).Value = "Student Name";
                    worksheet.Cell(currentRow, 3).Value = "Email";
                    worksheet.Cell(currentRow, 4).Value = "Collage ID";
                    worksheet.Cell(currentRow, 5).Value = "Level";
                    worksheet.Cell(currentRow, 6).Value = "Gender ID";
                    worksheet.Cell(currentRow, 7).Value = "Payment State";


                    foreach (var user in objUsersList)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = user.Id;
                        worksheet.Cell(currentRow, 2).Value = user.StudentName;
                        worksheet.Cell(currentRow, 3).Value = user.Email;
                        worksheet.Cell(currentRow, 4).Value = user.StudentCollageId;
                        worksheet.Cell(currentRow, 5).Value = user.Level;
                        worksheet.Cell(currentRow, 6).Value = user.GenderId;
                        worksheet.Cell(currentRow, 7).Value = user.ReportPaymentStat;



                    }


                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Users Report " + DateTime.Now.ToString("yyyy'-'MM'-'dd'-'hh'-'mm'-'tt") + ".xlsx");
                    }

                }
            }
            else
            {
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });
            }
            

            
        }

        public IActionResult PrintReportsAsExcel()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                IEnumerable<Reports> objReportsList = _db.Reports;

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("GpaReports Report " + DateTime.Now.ToString("hh'-'mm'-'tt"));
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "Student ID";
                    worksheet.Cell(currentRow, 2).Value = "Report ID";



                    foreach (var obj in objReportsList)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = obj.StudentId;
                        worksheet.Cell(currentRow, 2).Value = obj.ReportId;

                    }

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "GpaReports Report " + DateTime.Now.ToString("yyyy'-'MM'-'dd'-'hh'-'mm'-'tt") + ".xlsx");
                    }

                }
            }
            else
            {
                return RedirectToRoute(new
                {
                    controller = "Landingpage",
                    action = "Index"

                });
            }

            
        }



        public IActionResult UserReportPayAction(string id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var UserFromDb = _db.Users.Find(id);

                if (UserFromDb == null)
                {
                    return RedirectToAction("Index");
                }


                if (UserFromDb.ReportPaymentStat == 0)
                {
                    UserFromDb.ReportPaymentStat = 1;
                }
                else
                {
                    UserFromDb.ReportPaymentStat = 0;
                }

                _db.Users.Update(UserFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });


        }

        public IActionResult UserWeeklyPayAction(string id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var UserFromDb = _db.Users.Find(id);

                if (UserFromDb == null)
                {
                    return RedirectToAction("Index");
                }


                if (UserFromDb.WeeklyPaymentStat == 0)
                {
                    if (UserFromDb.ReportPaymentStat == 0)
                    {
                        UserFromDb.ReportPaymentStat = 1;

                    }
                    UserFromDb.WeeklyPaymentStat = 1;
                }
                else
                {
                    UserFromDb.WeeklyPaymentStat = 0;
                }

                _db.Users.Update(UserFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });


            
        }

        public IActionResult UserRemoveAction(string id)
        {

            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var UserFromDb = _db.Users.Find(id);

                if (UserFromDb == null)
                {
                    return RedirectToAction("Index");
                }

                _db.Users.Remove(UserFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });


            
        }

        public IActionResult ReportRemoveAction(int? id)
        {

            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null || id == 0)
                {
                    return RedirectToAction("Index");
                }
                var ReportFromDb = _db.Reports.Find(id);

                if (ReportFromDb == null)
                {
                    return RedirectToAction("Index");
                }

                _db.Reports.Remove(ReportFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });

        }

        public IActionResult WeeklyUpdatesRemoveAction(int? id)
        {

            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                if (id == null || id == 0)
                {
                    return RedirectToAction("Index");
                }
                var WeeklyUpdateFromDb = _db.WeeklyUpdates.Find(id);

                if (WeeklyUpdateFromDb == null)
                {
                    return RedirectToAction("Index");
                }

                _db.WeeklyUpdates.Remove(WeeklyUpdateFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new
            {
                controller = "Landingpage",
                action = "Index"

            });

            
        }

    }
}
