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
    public class AccountController : Controller
    {
        private readonly ITeleMedication _repository;
        private readonly IEmailService _emailService;

        public AccountController(ITeleMedication repository, IEmailService emailService)
        {
            _repository = repository;
           

            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Home(User model)
        {
            var user = await _repository.ValidateUser(model.Email, model.PasswordHash);
            if (user.Role != null)
            {
                switch (user.Role.ToLower())
                {
                    
                    case "doctor":
                        return RedirectToAction("Doctorpage", "Doctor");
                    case "patient":
                        return RedirectToAction("patientpage", "Patient");
                    case "administrator":
                        return RedirectToAction("Admin", "Account");
                    default:
                        return RedirectToAction("Home", "Account");
                }
            }
            else
            {
                
                TempData["FailedMessage"] = "If the user is not found, add an error message";
            }


            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            int countPatients = await _repository.TotalPatients();
            int countUsers = await _repository.TotalnoUsers();
            int countMedication = await _repository.TotalMedication();



            AdminCount count = new AdminCount
            {
                TotalPatients = countPatients,
                TotalUsers = countUsers,
                TotalMedication = countMedication,

            };

            return View(count);
        }
        [HttpPost]
        public async Task<JsonResult> AdmissionDashboard()
        {
            List<AdminDashboard> admissionData = await _repository.UserCount();


            List<object> data = new List<object>();
            var NumberofUsers = admissionData.Select(x => x.UserCount).ToList();
            var admissionRoles = admissionData.Select(x => x.RoleCount).ToList();

            data.Add(NumberofUsers);
            data.Add(admissionRoles);

            return Json(data);
        }
    }
}
