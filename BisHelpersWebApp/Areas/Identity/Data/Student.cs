using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace BisHelpersWebApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Student class
public class Student : IdentityUser
{
    [Required]
    public string StudentName { get; set; }
    [Required]
    [Range(7, 7, ErrorMessage = "Please Make Sure That You Write Valid Your College")]
    public int StudentCollageId { get; set; }
    [Required]
    public int GenderId { get; set; }
    [Required]
    public int Level { get; set; }

    public int ReportPaymentStat { get; set; }
    public int WeeklyPaymentStat { get; set; }
    public double Gpa { get; set; }


}

