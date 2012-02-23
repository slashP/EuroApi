using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    public class ChampionshipController : Controller
    {
        //
        // GET: /Championship/


        private readonly EuroApiContext _db = new EuroApiContext();

        public ActionResult Index()
        {
            var firstOrDefault = _db.Teams.FirstOrDefault();
            var group = "A";
            if (firstOrDefault != null)
            {
                group = firstOrDefault.Group.Name;
            }
            var matches = _db.Matches.Where(m => m.HomeTeam.Group.Name == group && m.Date.CompareTo(DateTime.Now) > 0).ToList();
            ViewBag.Matches = matches;
            var teams = _db.Teams.ToList();
            Standing.SortTeams(ref teams);
            return View(teams);
        }

    }
}
