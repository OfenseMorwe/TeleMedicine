using Microsoft.AspNetCore.Mvc;
using MedServices.Repository;
using MedServices.Models.ClassDomain;
using MedServices.eServices;
using MedServices.DataAccess;
using System.Diagnostics;
using System;
using Microsoft.Identity.Client;
using System.Security.AccessControl;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Pdf;
using iText.Layout;
using System.IO;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using iText.IO.Image;
namespace TeleMedication.Controllers
{
    public class PatientController : Controller
    {
        private readonly ITeleMedication _repository;
        private readonly IEmailService _emailService;

        public PatientController(ITeleMedication repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PatientDashboard()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PatientDashboard(AppointmentDetail status)
        {
            if (status == null || string.IsNullOrEmpty(status.Status))
            {
                TempData["FailedMessage"] = "Failed to get the status please make sure passing correct data";
                return RedirectToAction("PatientDashboard");
            }

            // Retrieve the filtered appointment details based on the status
            var appointments = await _repository.AppointmentDetails(status.Status);

            // Ensure appointments are returned as expected (e.g., a View with a List of appointments)
            if (appointments == null || !appointments.Any())
            {
                TempData["FailedMessage"] = "Failed to get the appointment , please try again";
                return RedirectToAction("PatientDashboard"); // Optionally render a view if no appointments found
            }

            // Return the filtered list to the view
            return View("PatientDashboard", appointments);
        }
    }
}
