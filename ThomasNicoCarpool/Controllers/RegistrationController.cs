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
            User u = JsonConvert.DeserializeObject<User>(userSession);
            List<Registration> registrations = Registration.GetRegistrationByUser(u, _registration);
            foreach (var registration in registrations)
            {
                u.AddRegistration(registration);
            }
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(u, new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
            
            return View(registrations);
        }
    }
}
