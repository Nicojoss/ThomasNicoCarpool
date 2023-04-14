using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.Controllers
{
    public class CarpoolController : Controller
    {
        private readonly ICarpoolDAL _carpool;

        public CarpoolController(ICarpoolDAL _carpool)
        {
            this._carpool = _carpool;
        }
        public IActionResult SeeAllOffers()
        {
            string userSession = HttpContext.Session.GetString("User");
            User u = JsonConvert.DeserializeObject<User>(userSession);
            ViewData["user"] = u.Nickname;

            return View(Carpool.GetOffers(_carpool));
        }
    }
}
