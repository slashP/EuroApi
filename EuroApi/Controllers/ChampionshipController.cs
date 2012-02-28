using System;
using System.Collections.Generic;
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
            var group = "A";
            var matches = _db.Matches.Where(m => m.HomeTeam.Group.Name == group && m.HomeTeamGoals != null).ToList();
            ViewBag.Matches = matches;
            
            var teams = _db.Teams.Where(t => t.Group.Name == group).ToList();
            Standing.SortTeams(ref teams);
            return View(teams);
        }

        public ActionResult Groups()
        {
            var groups = new List<List<Team>>();
            foreach (var team in _db.Groups.Select(a => a.Name))
            {
                var teamsInGroup = _db.Teams.Where(t => t.Group.Name == team).ToList();
                Standing.SortTeams(ref teamsInGroup);
                groups.Add(teamsInGroup);
            }
            return View(groups);
        }

        public ActionResult TeamView()
        {
            return View();
        }
    }
}
