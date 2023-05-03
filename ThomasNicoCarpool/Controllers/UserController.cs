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

        public UserController(IUserDAL _user)
        {
            this._user = _user;
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
            User u = _user.Authenticate(nickname, password);
            if(u is null)
            {
                return RedirectToAction("Authenticate", "User");
            }
            // Rajouter l'objet en Session à voir Mardi
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(u)); 
            string User_session = HttpContext.Session.GetString("User");

            return Redirect("/Carpool/SeeAllOffers");
        }
    }
}
