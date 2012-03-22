using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using EuroApi.DAL;
using EuroApi.DTO;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    [Authorize]
    public class MatchResultBetController : Controller
    {
        private readonly IRepository<MatchResultBet> _repository = new MatchResultBetRepository();
        private readonly IRepository<Match> _matchRepository = new MatchRepository();
        private readonly IRepository<Team> _teamRepository = new TeamRepository();
        private readonly IRepository<KnockoutMatchResultBet> _knockoutBetRepository = new KnockoutMatchResultBetRepository();
        private readonly IRepository<KnockoutMatch> _knockoutMatchRepository = new KnockoutMatchRepository();


        //
        // GET: /MatchResultBet/

        public ActionResult Index()
        {
            var matches = _matchRepository.GetAll().OrderBy(x => x.HomeTeam.Group.Name).ThenBy(x => x.Date).ToList();
            ViewBag.UsersResultBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
            return View(matches);
        }

        private List<Team> SortedTeamsAfterGroupPlay()
        {
            var teams = _teamRepository.GetAll().ToList();
            var userBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
            var sortedGroupTeams = UserBetStanding.SortTeamsByGroup(teams, userBets);
            return sortedGroupTeams;
        }

        private List<KnockoutMatch> QuarterFinalsFromBets()
        {
            var userBets =
                _knockoutBetRepository.Query(
                    x => x.User == User.Identity.Name && x.KnockoutMatch.Type == KnockoutMatch.QUARTERFINAL).ToList();
            var origQuarterFinals = _knockoutMatchRepository.Query(x => x.Type == KnockoutMatch.QUARTERFINAL).OrderBy(x => x.Date).ToList();
            var quarterFinals = UserBetStanding.GetQuarterFinals(SortedTeamsAfterGroupPlay(), origQuarterFinals , userBets);
            return quarterFinals;
        } 

        public JsonResult GetGroups()
        {
            var groups = new[] {"A", "B", "C", "D"};
            var userBets = _repository.Query(x => x.User == User.Identity.Name).ToList();

            var listOfTeams = new List<List<Team>>();
            foreach (var @group in groups)
            {
                var teams = _teamRepository.Query(t => t.Group.Name == group).ToList();
                var sortedGroupTeams = UserBetStanding.SortTeams(teams, userBets);
                listOfTeams.Add(sortedGroupTeams);
            }
            return Json(RenderPartialViewToString("_Groups", listOfTeams));
        }

        public JsonResult QuarterFinals()
        {
            var count = _repository.GetAll().Count();
            if (count < 24)
            {
                return Json("Not enough bets");
            }
            var quarterFinals = QuarterFinalsFromBets();
            var html = quarterFinals.Select(x => RenderPartialViewToString("_UserBetKnockoutMatch", x));
            return Json(html);
        }

        public JsonResult SemiFinals()
        {
            var semiFinals = new KnockoutPhase().SemiFinals(QuarterFinalsFromBets());
            return Json("TODO");
        }

        public JsonResult Final()
        {
            var knockoutPhase = new KnockoutPhase();
            var final = knockoutPhase.Final(knockoutPhase.SemiFinals(QuarterFinalsFromBets()));
            return Json("TODO");
        }

        public JsonResult GetTeamsInGroup(string group = "A")
        {
            var teams = _teamRepository.Query(t => t.Group.Name == group).ToList();
            var userBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
            var sortedGroupTeams = UserBetStanding.SortTeams(teams, userBets);
            return Json(new { html = RenderPartialViewToString("_Group", sortedGroupTeams), group = group });            
        }

        public JsonResult SetBet(int? matchId, int? homeGoals, int? awayGoals, string group)
        {
            if (matchId == null || homeGoals == null || awayGoals == null)
                return null;
            var userBet = _repository.Query(x => x.User == User.Identity.Name && x.MatchId == matchId).FirstOrDefault();
            if(userBet == null)
            {
                var userB = new MatchResultBet
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
            return GetTeamsInGroup(group);
        }

        public JsonResult RemoveAllBets(string group)
        {
            var matchIds = _matchRepository.Query(x => x.HomeTeam.Group.Name == group).Select(x => new {x.Id});
            foreach (var userBet in matchIds.Select(matchId => _repository.Query(x => x.User == User.Identity.Name && x.MatchId == matchId.Id).FirstOrDefault()).Where(userBet => userBet != null))
            {
                _repository.Remove(userBet);
            }
            _repository.Save();
            return GetTeamsInGroup(group);
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
                viewContext.ViewBag.UsersResultBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
                viewContext.ViewBag.UsersResultBetsKnockout = _knockoutBetRepository.Query(x => x.User == User.Identity.Name).ToList();
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}