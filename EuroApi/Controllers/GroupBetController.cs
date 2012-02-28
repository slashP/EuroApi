using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroApi.DAL;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    public class GroupBetController : Controller
    {
        private IRepository<Team> _repository = new TeamRepository();

        [Authorize]
        public ActionResult Index()
        {
            if (User != null)
            {
                var user = User.Identity.Name;

            }
            return View();
        }

        [Authorize]
        public JsonResult BetOnMatch(int matchId, int homeTeamGoals, int awayTeamGoals)
        {
            if(User == null)
            {
                return Json("Not authorized");
            }
            var user = User.Identity.Name;
            return Json("Ok");
        }
    }
}
