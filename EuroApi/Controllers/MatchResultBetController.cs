﻿using System.Collections.Generic;
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
            var betTeams = new List<Team>();
            foreach (var groupName in new []{"A", "B", "C", "D"})
            {
                var teamsInGroup = _teamRepository.Query(t => t.Group.Name == groupName).ToList();
                var sortedGroupTeams = UserBetStanding.SortTeams(teamsInGroup, userBets);
                groups.Add(sortedGroupTeams);
                sortedGroupTeams.ForEach(betTeams.Add);
            }
            var knockout = new KnockoutPhase();
            var matches = knockout.GetQuarterFinals(betTeams);
            ViewBag.QuarterFinals = matches;
            return View(groups);
            
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
            var knockout = new KnockoutPhase();
            var quarterFinals = knockout.GetQuarterFinals(SortedTeamsAfterGroupPlay());
            return quarterFinals;
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

        public ActionResult ChampionshipBet()
        {
            var matches = _matchRepository.GetAll().OrderBy(x => x.HomeTeam.Group.Name).ThenBy(x => x.Date).ToList();
            ViewBag.UsersResultBets = _repository.Query(x => x.User == User.Identity.Name).ToList();
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

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

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