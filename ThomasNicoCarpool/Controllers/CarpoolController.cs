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
            string? userSession = HttpContext.Session.GetString("User");
            User u = JsonConvert.DeserializeObject<User>(userSession);
            ViewData["user"] = u.Nickname;

            return View(Carpool.GetOffers(_carpool));
        }
        public IActionResult OfferACarpool()
        {
            return View();
        }
        /* Ici je dois recuperer les attributs de la requete que le driver a choisi et y ajouter le vehicule que je vais utiliser
         * pour mon offre de carpool
         * public IActionResult OfferACarpool(Request request)
        {
            string? userSession = HttpContext.Session.GetString("User");
            User u = JsonConvert.DeserializeObject<User>(userSession);
            u.GetVehicles();
            
            Carpool c = new Carpool();

            return View(c);
        }*/

    }
}
