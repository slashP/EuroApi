using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    public class ChampionshipController : Controller
    {
        private readonly EuroApiContext _db = new EuroApiContext();

        public ActionResult Index()
        {
            var firstOrDefault = _db.Teams.Include(t => t.Group).FirstOrDefault();
            var group = "A";
            var matches = _db.Matches.Where(m => m.HomeTeam.Group.Name == group && m.HomeTeamGoals != null).ToList();
            ViewBag.Matches = matches;
            var teams = _db.Teams.Where(t => t.Group.Name == group).ToList();
            Standing.SortTeams(ref teams);
            return View(teams);
        }

        public ActionResult TeamView()
        {
            return View();
        }
    }
}
