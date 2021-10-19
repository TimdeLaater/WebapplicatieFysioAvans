using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebapplicatieFysioAvans.Models;

namespace WebapplicatieFysioAvans.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<PatientModel> patients;
        public HomeController(ILogger<HomeController> logger)
        {
            patients = new List<PatientModel>()
            {
                new PatientModel()
                {
                Name = "Tim de Laater"
                },
                new PatientModel()
                {
                Name = "Test"
                },
                new PatientModel()
                {
                Name = "Test2"
                }
            };
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(patients);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PatientForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PatientForm(PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                patients.Add(patient);
                return View("Index",patients);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
