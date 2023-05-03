using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestDAL _request;

        public RequestController(IRequestDAL _request)
        {
            this._request = _request;
        }
        public IActionResult MakeARequest()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeARequest(string departure, string arrival, DateTime date)
        {
            string userSession = HttpContext.Session.GetString("User");
            User u = JsonConvert.DeserializeObject<User>(userSession);

            Request r = new Request(u, departure, arrival, date);
            r.SaveRequest(_request);
            u.AddRequest(r);
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(u));
            return Redirect("/Carpool/SeeAllOffers");
        }
    }
}
