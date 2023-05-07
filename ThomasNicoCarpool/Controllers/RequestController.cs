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
        public IActionResult SeeAllRequests()
        {
            string? userSession = HttpContext.Session.GetString("User");
            User u = JsonConvert.DeserializeObject<User>(userSession);
            ViewData["user"] = u.Nickname;
            
            return View(Models.Request.GetRequests(_requestDAL));
        }
    }
}
