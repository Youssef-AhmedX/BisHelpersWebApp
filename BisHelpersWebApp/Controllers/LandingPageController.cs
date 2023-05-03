using Microsoft.AspNetCore.Mvc;

namespace BisHelpersWebApp.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WhatsBIS()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
