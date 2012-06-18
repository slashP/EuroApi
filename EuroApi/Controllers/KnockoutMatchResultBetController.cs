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
    public class KnockoutMatchResultBetController : BaseController
    {
        private readonly IRepository<KnockoutMatchResultBet> _repository = new KnockoutMatchResultBetRepository();
        private readonly IRepository<Team> _teamRepository = new TeamRepository();
        private readonly IRepository<KnockoutMatch> _knockoutMatchRepository = new KnockoutMatchRepository();
        private readonly IRepository<MatchResultBet> _matchResultBetRepository = new MatchResultBetRepository();
        private readonly FootyFeudContext _db = new FootyFeudContext();

        public ActionResult Quarter()
        {
            var europeanTime = DateTime.UtcNow.AddHours(2);
            var quarters = _db.KnockoutMatches.Where(x => x.Type == 1 && x.Date > europeanTime).ToList();
            ViewBag.UsersResultBetsKnockout = _db.KnockoutMatchResultBets.Where(x => x.User == User.Identity.Name && x.KnockoutMatch.Type == 1).ToList();
            return View(quarters);
        }

        public ActionResult Semi()
        {
            var europeanTime = DateTime.UtcNow.AddHours(2);
            var quarters = _db.KnockoutMatches.Where(x => x.Type == 2 && x.Date > europeanTime).ToList();
            ViewBag.UsersResultBetsKnockout = _db.KnockoutMatchResultBets.Where(x => x.User == User.Identity.Name && x.KnockoutMatch.Type == 2).ToList();
            return View(quarters);
        }

        public ActionResult Final()
        {
            var europeanTime = DateTime.UtcNow.AddHours(2);
            var quarters = _db.KnockoutMatches.Where(x => x.Type == 3 && x.Date > europeanTime).ToList();
            ViewBag.UsersResultBetsKnockout = _db.KnockoutMatchResultBets.Where(x => x.User == User.Identity.Name && x.KnockoutMatch.Type == 3).ToList();
            return View(quarters);
        }


        public JsonResult SetBet(int? matchId, int? homeGoals, int? awayGoals, int? homeTeamId, int? awayTeamId)
        {
            if (matchId == null || homeGoals == null || awayGoals == null || homeTeamId == null || awayTeamId == null)
                return null;
            var match = _knockoutMatchRepository.Find((int)matchId);
            var europeanTime = DateTime.UtcNow.AddHours(2);
            if (match == null || match.Date < europeanTime) return null;
            var userBet = _repository.Query(x => x.User == User.Identity.Name && x.KnockoutMatchId == matchId && x.KnockoutMatch.Type == match.Type).FirstOrDefault();
            if (userBet == null)
            {
                var userB = new KnockoutMatchResultBet
                {
                    User = User.Identity.Name,
                    KnockoutMatchId = (int)matchId,
                    HomeTeamGoals = (int)homeGoals,
                    AwayTeamGoals = (int)awayGoals,
                    HomeTeamId = (int)homeTeamId,
                    AwayTeamId = (int)awayTeamId,
                };
                _repository.Add(userB);
                _repository.Save();
            }
            else
            {
                userBet.HomeTeamGoals = (int)homeGoals;
                userBet.AwayTeamGoals = (int)awayGoals;
                userBet.HomeTeamId = (int) homeTeamId;
                userBet.AwayTeamId = (int) awayTeamId;
                _repository.Save();
            }
            return Json("");
        }

        private IEnumerable<KnockoutMatch> GetSemiFinalsFromBets()
        {
            var userBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
            var quarterFinals = _knockoutMatchRepository.Query(x => x.Type == KnockoutMatch.QUARTERFINAL).OrderBy(x => x.Date).ToList();
            var semiFinals = _knockoutMatchRepository.Query(x => x.Type == KnockoutMatch.SEMIFINAL).OrderBy(x => x.Date).ToList();
            return UserBetStanding.GetSemiFinals(userBets, quarterFinals, semiFinals);
        }

        private KnockoutMatch GetFinalFromBets()
        {
            var userBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
            var final = _knockoutMatchRepository.Query(x => x.Type == KnockoutMatch.FINAL).FirstOrDefault();
            return UserBetStanding.GetFinal(userBets, final);
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;
            
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewContext.ViewBag.UsersResultBetsKnockout = _repository.Query(x => x.User == User.Identity.Name).ToList();
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }

        public JsonResult SemiFinals()
        {
            var userBets =
                _repository.Query(x => x.KnockoutMatch.Type == KnockoutMatch.QUARTERFINAL && x.User == User.Identity.Name).
                    ToList();
            var groupBets = _matchResultBetRepository.Query(x => x.User == User.Identity.Name);
            if (userBets.Count >= 4 && groupBets.Count() >= 24)
            {
                var semiFinals = GetSemiFinalsFromBets().ToList();
                if (userBets.Any(x => x.KnockoutMatch.Winner() == null))
                    return Json("Some results are draw in quarter finals.");
                var html = semiFinals.Select(x => RenderPartialViewToString("_UserBetKnockoutMatch", x));
                return Json(html);
            }
            return Json("Set bets in groups and quarter finals before semi finals.");
        }
    }
}
