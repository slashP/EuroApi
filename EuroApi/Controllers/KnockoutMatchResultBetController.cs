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
    public class KnockoutMatchResultBetController : Controller
    {
        private readonly IRepository<KnockoutMatchResultBet> _repository = new KnockoutMatchResultBetRepository();
        private readonly IRepository<Team> _teamRepository = new TeamRepository();
        private readonly IRepository<KnockoutMatch> _knockoutMatchRepository = new KnockoutMatchRepository();

        public JsonResult SetBet(int? matchId, int? homeGoals, int? awayGoals)
        {
            if (matchId == null || homeGoals == null || awayGoals == null)
                return null;
            var userBet = _repository.Query(x => x.User == User.Identity.Name && x.MatchId == matchId && x.Match.Type == KnockoutMatch.QUARTERFINAL).FirstOrDefault();
            if (userBet == null)
            {
                var userB = new KnockoutMatchResultBet
                {
                    User = User.Identity.Name,
                    MatchId = (int)matchId,
                    HomeTeamGoals = (int)homeGoals,
                    AwayTeamGoals = (int)awayGoals
                };
                _repository.Add(userB);
                _repository.Save();
            }
            else
            {
                userBet.HomeTeamGoals = (int)homeGoals;
                userBet.AwayTeamGoals = (int)awayGoals;
                _repository.Save();
            }
            var userBets =
                _repository.Query(x => x.Match.Type == KnockoutMatch.QUARTERFINAL && x.User == User.Identity.Name).
                    ToList();
            if(userBets.Count == 4)
            {
                var semiFinals = SemiFinalsFromBets();
                var html = semiFinals.Select(x => RenderPartialViewToString("_UserBetKnockoutMatch", x));
                return Json(html);
            }
            return Json("");
        }

        private IEnumerable<KnockoutMatch> SemiFinalsFromBets()
        {
            var knockout = new KnockoutPhase();
            var semiFinals = knockout.SemiFinals(GetSemiFinalsFromBets());
            return semiFinals;
        }

        private List<KnockoutMatch> GetSemiFinalsFromBets()
        {
            var userBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
            var quarterFinals = _knockoutMatchRepository.Query(x => x.Type == KnockoutMatch.QUARTERFINAL).ToList();
            var semiFinals = _knockoutMatchRepository.Query(x => x.Type == KnockoutMatch.SEMIFINAL).ToList();
            return UserBetStanding.GetSemiFinals(userBets, quarterFinals, semiFinals);
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;
            ViewBag.UsersResultBetsKnockout = _repository.Query(x => x.User == User.Identity.Name).ToList();

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
