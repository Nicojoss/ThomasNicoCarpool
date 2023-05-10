using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationDAL _registration;

        public RegistrationController(IRegistrationDAL _registration)
        {
            this._registration = _registration;
        }
        public IActionResult ConsultRegistrations()
        {
            string userSession = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(userSession))
            {
                TempData["Message"] = "Please Authenticate in first";
                return RedirectToAction("Authenticate", "User");
            }
            User u = JsonConvert.DeserializeObject<User>(userSession);
            List<Registration> registrations = Registration.GetRegistrationByUser(u, _registration);
            foreach (var registration in registrations)
            {
                u.AddRegistration(registration);
            }
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(u, new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
            
            return View(registrations);
        }
        public IActionResult RegisterForACarpool(string JsonCarpool)
        {
            string userSession = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(userSession))
            {
                TempData["Message"] = "Please Authenticate in first";
                return RedirectToAction("Authenticate", "User");
            }
            HttpContext.Session.SetString("Carpool", JsonCarpool);
            Carpool c = JsonConvert.DeserializeObject<Carpool>(JsonCarpool);
            Registration registrationModel = new Registration();
            registrationModel.Carpool_ = c;
            return View(registrationModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult RegisterForACarpool(int NbrPlaceTaken, int nbrLuggage)
        {
            if (ModelState.IsValid)
            {
                string carpool_session = HttpContext.Session.GetString("Carpool");
                Carpool carpool = JsonConvert.DeserializeObject<Carpool>(carpool_session);
                string user_session = HttpContext.Session.GetString("User");
                User? u = JsonConvert.DeserializeObject<User>(user_session);

                Registration reg = new Registration(NbrPlaceTaken, nbrLuggage, u, carpool);
                carpool.AddRegistration(reg);

                string JsonRegistration = JsonConvert.SerializeObject(reg, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                HttpContext.Session.SetString("Registration", JsonRegistration);

                return View("ConfirmRegistration", carpool);
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult ConfirmRegistration()
        {
            Registration reg = JsonConvert.DeserializeObject<Registration>(HttpContext.Session.GetString("Registration"));
            if (reg.SaveRegistration(_registration))
                TempData["Message"] = "Registration created successfully!";
            else
                TempData["Message"] = "Error during the creation of the registration !";

            return RedirectToAction("SeeAllOffers", "Carpool");
        }
    }
}
