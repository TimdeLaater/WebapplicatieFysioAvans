using DomainModel.Models;
using DomainServices;
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
        private readonly IPatientRepo _patientRepo;
        private List<PatientModel> patients;
        public HomeController(ILogger<HomeController> logger, IPatientRepo patientRepo)
        {
            patients = new List<PatientModel>()
            {
                new PatientModel()
                {
                Name = "Tim de Laater"
                },
            };
            _logger = logger;
            _patientRepo = patientRepo;
        }

        public IActionResult Index()
        {
            return View(_patientRepo.Get().ToList());
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
                patient.PatientDossier = new PatientFileModel();
                patient.PatientDossier.Comments = new List<CommentModel>();

                if (_patientRepo.Get().Exists(t => t?.Email == patient.Email))
                {
                    ModelState.AddModelError(String.Empty, "De email bestaat al.");
                    return View();
                }

                _patientRepo.Create(patient);
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
