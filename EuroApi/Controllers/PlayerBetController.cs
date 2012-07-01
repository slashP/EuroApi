using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroApi.Context;
using EuroApi.DAL;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    [Authorize]
    public class PlayerBetController : BaseController
    {
        private readonly FootyFeudContext _db = new FootyFeudContext();

        public JsonResult PlayerBets()
        {
            var types = _db.PlayerBetTypes.ToList();
            var players = _db.Players.OrderBy(x => x.NationalTeam).ToList();
            var bets = _db.PlayerBets.Where(x => x.User == User.Identity.Name).ToList();
            var html = RenderPartialViewToString("_PlayerListBet", players, types, bets);
            return Json(html);
        }

        public JsonResult SetBet(int playerId, int type)
        {
            return null;
            var europeanTime = DateTime.UtcNow.AddHours(2);
            var match = _db.Matches.FirstOrDefault(x => x.Date > europeanTime);
            if (match != null)
            {
                var date = match.Date;
                if (europeanTime > date) return null;
            }
            var user = User.Identity.Name;
            var bet = _db.PlayerBets.FirstOrDefault(x => x.User == user && x.PlayerBetTypeId == type);
            
            if(bet != null)
            {
                bet.PlayerId = playerId;
                _db.SaveChanges();
            }
            else
            {
                var newBet = new PlayerBet
                                 {
                                     PlayerBetTypeId = type,
                                     User = user,
                                     PlayerId = playerId
                                 };
                _db.PlayerBets.Add(newBet);
                _db.SaveChanges();
            }
            var player = _db.Players.Find(playerId);
            return Json(player == null ? "" : player.Name);
        }

        protected string RenderPartialViewToString(string viewName, object model, List<PlayerBetType> types, List<PlayerBet> bets)
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
