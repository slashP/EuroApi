using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using EuroApi.Context;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    [Authorize]
    public class TeamBetController : BaseController
    {
        //
        // GET: /TeamBet/

        private readonly FootyFeudContext _db = new FootyFeudContext();

        public JsonResult TeamBets()
        {
            var types = _db.TeamBetTypes.ToList();
            var players = _db.Teams.ToList();
            var bets = _db.TeamBets.Where(x => x.User == User.Identity.Name).ToList();
            var html = RenderPartialViewToString("_TeamListBet", players, types, bets);
            return Json(html);
        }

        public JsonResult SetBet(int teamId, int type)
        {
            var europeanTime = DateTime.UtcNow.AddHours(2);
            var match = _db.Matches.FirstOrDefault(x => x.Date > europeanTime);
            if (match != null)
            {
                var date = match.Date;
                if (europeanTime > date) return null;
            }
            var user = User.Identity.Name;
            var bet = _db.TeamBets.FirstOrDefault(x => x.User == user && x.TeamBetTypeId == type);
            if (bet != null)
            {
                bet.TeamId = teamId;
                _db.SaveChanges();
            }
            else
            {
                var newBet = new TeamBet
                {
                    TeamBetTypeId = type,
                    User = user,
                    TeamId = teamId
                };
                _db.TeamBets.Add(newBet);
                _db.SaveChanges();
            }
            var team = _db.Teams.Find(teamId);
            return Json(team == null ? "" : team.Name);
        }

        public JsonResult TeamList()
        {
            var teams = _db.Teams.Select(x => new { label = x.Name, id = x.Id }).ToList();
            return Json(teams);
        }

        protected string RenderPartialViewToString(string viewName, object model, List<TeamBetType> types, List<TeamBet> bets)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewContext.ViewBag.Types = types;
                viewContext.ViewBag.Bets = bets;
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }

    }
}
