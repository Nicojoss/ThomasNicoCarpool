using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestDAL _requestDAL;

        public RequestController(IRequestDAL _requestDAL)
        {
            this._requestDAL = _requestDAL;
        }
        public IActionResult MakeARequest()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeARequest(string departure, string arrival, DateTime date)
        {
            if (ModelState.IsValid)
            {
                string userSession = HttpContext.Session.GetString("User");
                User u = JsonConvert.DeserializeObject<User>(userSession);
                Request r = new Request(u, departure, arrival, date);

                if (r.SaveRequest(_requestDAL))
                    TempData["Message"] = "Request created successfully!";
                else
                    TempData["Message"] = "Error during the creation of the request !";

                //r.SaveRequest(_requestDAL);
                return Redirect("/Request/SeeAllRequests");
            }
            return View();
        }
        public IActionResult SeeAllRequests()
        {
            string? userSession = HttpContext.Session.GetString("User");
            User u = JsonConvert.DeserializeObject<User>(userSession);
            ViewData["user"] = u.Nickname;

            return View(Models.Request.GetRequests(_requestDAL));
        }
    }
}
