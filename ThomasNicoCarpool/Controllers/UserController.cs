using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;
using ThomasNicoCarpool.ViewModels;

namespace ThomasNicoCarpool.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserDAL _user;
        private readonly IVehicleDAL _vehicle;

        public UserController(IUserDAL _user, IVehicleDAL _vehicle)
        {
            this._user = _user;
            this._vehicle = _vehicle;
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(UserViewModel u)
        {
            if(ModelState.IsValid)
            {
                User user = new User(u);

                user.SaveAccount(_user);
                TempData["Message"] = "Account created successfully!";
                return RedirectToAction("Index", "Home");
            }
            return View(u);
        }
        public IActionResult Authenticate() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Authenticate(string nickname, string password)
        {
            User u = Models.User.Authenticate(nickname, password, _user);
            if (u is null)
            {
                return RedirectToAction("Authenticate", "User");
            }
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(u)); 
  
            return Redirect("/Carpool/SeeAllOffers");
        }
        public IActionResult AddVehicle()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                TempData["Message"] = "Please Authenticate in first";
                return RedirectToAction("Authenticate", "User");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddVehicle(AddVehicleViewModel vehicleVm)
        {
            string userSession = HttpContext.Session.GetString("User");
            if (userSession == null)
            {
                TempData["Message"] = "Please Authenticate in first";
                return RedirectToAction("Authenticate", "User");
            }
            User u = JsonConvert.DeserializeObject<User>(userSession);

            if (ModelState.IsValid)
            {
                Vehicle vehicle = new Vehicle(vehicleVm);
                vehicle.Owner = u;
                vehicle.SaveVehicle(_vehicle);

                TempData["Message"] = "Vehicle added successfully!";
                return RedirectToAction("SeeAllOffers", "Carpool");
            }
            return View(vehicleVm); 
        }
        public IActionResult Disconnect()
        {

            HttpContext.Session.Clear();

            TempData["Message"] = "Disconnected Successfully!";
            return RedirectToAction("Index", "Home");
        }
    }
}
