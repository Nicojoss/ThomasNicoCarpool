using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;
using ThomasNicoCarpool.ViewModels;

namespace ThomasNicoCarpool.Controllers
{
    public class CarpoolController : Controller
    {
        private readonly ICarpoolDAL _carpool;
        private readonly IVehicleDAL _vehicle;
        private readonly IRequestDAL _request;
        public CarpoolController(ICarpoolDAL _carpool, IVehicleDAL _vehicle, IRequestDAL _request)
        {
            this._carpool = _carpool;
            this._vehicle = _vehicle;
            this._request = _request;
        }
        public IActionResult SeeAllOffers()
        {
            string? userSession = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(userSession))
            {
                TempData["Message"] = "Please Authenticate in first";
                return RedirectToAction("Authenticate", "User");
            }
            User u = JsonConvert.DeserializeObject<User>(userSession);

            ViewData["user"] = u.Nickname;

            return View(Carpool.GetOffers(_carpool));
        }
        public IActionResult OfferAEmptyCarpool()
        {
            string? userSession = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(userSession))
            {
                TempData["Message"] = "Please Authenticate in first";
                return RedirectToAction("Authenticate", "User");
            }
            User u = JsonConvert.DeserializeObject<User>(userSession);

            List<Vehicle> vehicles = Vehicle.GetVehiclesByUser(_vehicle, u);

            foreach (Vehicle vehicle in vehicles)
            {
                u.AddVehicle(vehicle);
            }

            AddAnOffersViewModel cvm = new AddAnOffersViewModel(u);
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(u, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            return View("OfferACarpool", cvm);
        }
        public IActionResult OfferACarpool(int id)
        {
            string? userSession = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(userSession))
            {
                TempData["Message"] = "Please Authenticate in first";
                return RedirectToAction("Authenticate", "User");
            }
            User u = JsonConvert.DeserializeObject<User>(userSession);

            List<Vehicle> vehicles = Vehicle.GetVehiclesByUser(_vehicle, u);

            foreach (Vehicle vehicle in vehicles)
            {
                u.AddVehicle(vehicle);
            }
            Request r = Models.Request.GetRequestById(id, _request);
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(u, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            AddAnOffersViewModel cvm = new AddAnOffersViewModel(r.Departure, r.Arrival, r.Date, u);
            r.RemoveRequestById(id, _request);
            return View(cvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OfferACarpool(AddAnOffersViewModel cvm)
        {
            string? userSession = HttpContext.Session.GetString("User");
            User u = JsonConvert.DeserializeObject<User>(userSession);

            ModelState.Remove("Driver");
            if (ModelState.IsValid)
            {
                Carpool carpool = new Carpool(cvm);
                carpool.Driver = u;
                carpool.Vehicle_ = u.GetVehicle(cvm.IdVehicle);
                carpool.Price = carpool.GetPrice();
                if (carpool.SaveCarpool(_carpool))
                {
                    TempData["Message"] = "Carpool created successfully!";
                }
                else
                {
                    TempData["Message"] = "Error during the creation of an offer!";
                }

                
                return RedirectToAction("SeeAllOffers", "Carpool");
            }
            cvm.Driver = u;
            return View(cvm);
        }
        public IActionResult ConsultMyOffers()
        {
            string? userSession = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(userSession))
            {
                TempData["Message"] = "Please Authenticate in first";
                return RedirectToAction("Authenticate", "User");
            }
            User u = JsonConvert.DeserializeObject<User>(userSession);

            return View(Carpool.GetOffersByDriver(_carpool, u));
        }
    }
}
