using Lesson7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lesson7.Dictionaries;
using Lesson7.Enums;

namespace Lesson7.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<OfficeWorkingHouse> officeWorkingHouse = new List<OfficeWorkingHouse>
            {
              new OfficeWorkingHouse { DayOfWeek = DaysOfWeek.Sunday, HoursOfWorking = HoursOfWorking.hoursOfWorking["Sunday"]},
              new OfficeWorkingHouse { DayOfWeek = DaysOfWeek.Monday, HoursOfWorking = HoursOfWorking.hoursOfWorking["OrdinaryDays"]},
              new OfficeWorkingHouse { DayOfWeek = DaysOfWeek.Tuesday, HoursOfWorking = HoursOfWorking.hoursOfWorking["OrdinaryDays"]},
              new OfficeWorkingHouse { DayOfWeek = DaysOfWeek.Wensday, HoursOfWorking = HoursOfWorking.hoursOfWorking["OrdinaryDays"]},
              new OfficeWorkingHouse { DayOfWeek = DaysOfWeek.Thursday, HoursOfWorking = HoursOfWorking.hoursOfWorking["OrdinaryDays"]},
              new OfficeWorkingHouse { DayOfWeek = DaysOfWeek.Friday, HoursOfWorking = HoursOfWorking.hoursOfWorking["Friday"]},
              new OfficeWorkingHouse { DayOfWeek = DaysOfWeek.Saturday, HoursOfWorking = HoursOfWorking.hoursOfWorking["Saturday"]}
            };
            return View(officeWorkingHouse);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
