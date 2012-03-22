using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroApi.DAL;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    [Authorize]
    public class PlayerBetController : Controller
    {
        IRepository<PlayerBet> _playerBetRepository = new PlayerBetRepository();
        private IRepository<Player> _playerRepository = new PlayerRepository();
        readonly IRepository<PlayerBetType> _playerBetTypeRepository = new PlayerBetTypeRepository();
        public JsonResult PlayerBets()
        {
            var types = _playerBetTypeRepository.GetAll().ToList();
            var players = _playerRepository.GetAll().ToList();
            var bets = _playerBetRepository.Query(x => x.User == User.Identity.Name).ToList();
            var html = RenderPartialViewToString("_PlayerListBet", players, types, bets);
            return Json(html);
        }

        public JsonResult SetBet(int playerId, int type)
        {
            var user = User.Identity.Name;
            var bet = _playerBetRepository.Query(x => x.User == user && x.PlayerBetTypeId == type).FirstOrDefault();
            if(bet != null)
            {
                bet.PlayerId = playerId;
                _playerBetRepository.Save();
            }
            else
            {
                var newBet = new PlayerBet
                                 {
                                     PlayerBetTypeId = type,
                                     User = user,
                                     PlayerId = playerId
                                 };
                _playerBetRepository.Add(newBet);
                _playerBetRepository.Save();
            }
            var player = _playerRepository.Find(playerId);
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
