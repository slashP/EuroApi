using System.Collections.Generic;
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
        //
        // GET: /MatchResultBet/

        public ActionResult Index(string group = "A")
        {
            var matches = _matchRepository.Query(x => x.HomeTeam.Group.Name == group);
            ViewBag.UsersResultBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
            return View(matches.ToList());
        }

        public ActionResult Overview()
        {
            var groups = new List<List<Team>>();
            var userBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
            foreach (var groupName in new []{"A", "B", "C", "D"})
            {
                var teamsInGroup = _teamRepository.Query(t => t.Group.Name == groupName).ToList();
                var sortedGroupTeams = UserBetStanding.SortTeams(teamsInGroup, userBets);
                groups.Add(sortedGroupTeams);
            }
            var knockout = new KnockoutPhase();
            var teams = _teamRepository.GetAll().ToList();
            var sortedGroupTeams2 = UserBetStanding.SortTeams(teams, userBets);
            var matches = knockout.GetQuarterFinals(sortedGroupTeams2);
            ViewBag.QuarterFinals = matches;
            return View(groups);
            
        }

        public ActionResult QuarterFinals()
        {
            var knockout = new KnockoutPhase();
            var teams = _teamRepository.GetAll().ToList();
            var userBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
            var sortedGroupTeams = UserBetStanding.SortTeams(teams, userBets);
            var matches = knockout.GetQuarterFinals(sortedGroupTeams);
            return View(matches);
        }

        public JsonResult GetTeamsInGroup(string group = "A")
        {
            var teams = _teamRepository.Query(t => t.Group.Name == group).ToList();
            var userBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
            var sortedGroupTeams = UserBetStanding.SortTeams(teams, userBets);
            var teamsDto = DtoTeam.TeamsToDto(sortedGroupTeams);
            return Json(teamsDto);
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
    }
}