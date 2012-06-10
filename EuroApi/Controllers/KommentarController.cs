using System.Web.Mvc;

namespace EuroApi.Controllers
{
    [Authorize]
    public class KommentarController : BaseController
    {
        public ActionResult Create()
        {
            return View();
        }
    }
}
