using System.Web.Mvc;

namespace EuroApi.Controllers
{
    [Authorize]
    public class KommentarController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
    }
}
