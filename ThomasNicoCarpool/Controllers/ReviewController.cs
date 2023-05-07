using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewDAL _review;

        public ReviewController(IReviewDAL _review)
        {
            this._review = _review;
        }
        public IActionResult GiveAReview(int id)
        {
            string userSession = HttpContext.Session.GetString("User");
            User u = JsonConvert.DeserializeObject<User>(userSession);
            Registration reg= u.GetRegistrationsById(id);
            HttpContext.Session.SetString("Registration", JsonConvert.SerializeObject(reg));
            
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult GiveAReview(int rating, string comment)
        {
            if (ModelState.IsValid) {
                string userSession = HttpContext.Session.GetString("User");
                User u = JsonConvert.DeserializeObject<User>(userSession);
                string regSession = HttpContext.Session.GetString("Registration");
                Registration reg = JsonConvert.DeserializeObject<Registration>(regSession);

                Review r = new Review(rating, comment, u, reg.Carpool_);
                if(r.SaveReview(_review))
                    TempData["Message"] = "Review created successfully!";
                else
                    TempData["Message"] = "Error during the creation of the review !";

                return Redirect("/Carpool/SeeAllOffers");
            }
            return View();
        }
    }
}
