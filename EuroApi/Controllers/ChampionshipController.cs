using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EuroApi.Context;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    public class ChampionshipController : Controller
    {
        private readonly FootyFeudContext _db = new FootyFeudContext();

        public ActionResult Index()
        {
            var group = "A";
            var matches = _db.Matches.Where(m => m.HomeTeam.Group.Name == group && m.HomeTeamGoals != null).ToList();
            ViewBag.Matches = matches;
            
            var teams = _db.Teams.Where(t => t.Group.Name == group).ToList();
            var sortedTeams = Standing.SortTeams(teams);
            return View(sortedTeams);
        }

        public ActionResult Groups()
        {
            var groups = new List<List<Team>>();
            foreach (var team in _db.Groups.Select(a => a.Name))
            {
                var teamsInGroup = _db.Teams.Where(t => t.Group.Name == team).ToList();
                var sortedTeamsInGroup = Standing.SortTeams(teamsInGroup);
                groups.Add(sortedTeamsInGroup);
            }
            return View(groups);
        }

        public ActionResult TeamView()
        {
            return View();
        }
    }
}
