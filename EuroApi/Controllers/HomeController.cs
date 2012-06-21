using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CodeFirstMembershipSharp;
using EuroApi.Context;
using EuroApi.DAL;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepository<Match> _matchRepository = new MatchRepository();
        private readonly IRepository<Team> _teamRepository = new TeamRepository();
        private readonly FootyFeudContext _db = new FootyFeudContext();

        public ActionResult Index()
        {
            var europeanTime = DateTime.UtcNow.AddHours(2);
            var matches = _db.KnockoutMatches.Where(x => x.Date > europeanTime).OrderBy(x => x.Date).Take(4).ToList();
            var playedMatches = _db.KnockoutMatches.Where(x => x.HomeTeamGoals != null && x.AwayTeamGoals != null).OrderByDescending(x => x.Date).Take(4).ToList();
            playedMatches.Reverse();
            ViewBag.PlayedMatches = playedMatches;
            var teamsByGroup = new List<List<Team>>();
            
            foreach (var groupId in _teamRepository.GetAll().Select(x => x.Group.Name).Distinct())
            {
                teamsByGroup.Add(_teamRepository.Query(x => x.Group.Name == groupId).ToList());
            }
            var orderedTeams = new List<IEnumerable<Team>>();
            teamsByGroup.ForEach(t => orderedTeams.Add(Standing.SortTeams(t)));
            ViewBag.Groups = orderedTeams;
            ViewBag.Users = GetUserResultList();
            var currentMatch = _db.KnockoutMatches.OrderByDescending(x => x.Date).FirstOrDefault(x => x.Date < europeanTime);
            if (currentMatch != null)
            {
                var todayDate = currentMatch.Date;
                var allCurrent = new List<KnockoutMatch>();
                foreach (var match in _db.KnockoutMatches)
                {
                    if(match.Date == todayDate)
                    {
                        allCurrent.Add(match);
                    }
                }
                var endTime = currentMatch.Date.AddHours(2);
                if(endTime > europeanTime)
                {
                    var matchBets = new List<List<KnockoutMatchResultBet>>();
                    foreach (var match in allCurrent)
                    {
                        matchBets.Add(_db.KnockoutMatchResultBets.Where(x => x.KnockoutMatchId == match.Id).ToList());
                    }
                    ViewBag.CurrentMatchBets = matchBets;
                }
            }
            return View(matches);
        }

        public ActionResult Rules()
        {
            return View();
        }

        private IOrderedEnumerable<User> GetUserResultList()
        {
            var users = _db.Users.ToList();
            var europeanTime = DateTime.UtcNow.AddHours(2);
            var matches = _matchRepository.Query(x => x.Date < europeanTime).ToList();
            foreach (var user in users)
            {
                var usr = user;
                var userBets = _db.MatchResultBets.Where(x => x.User == usr.Username).ToList();
                foreach (var userbet in matches.Select(match => userBets.FirstOrDefault(x => x.MatchId == match.Id)).Where(userbet => userbet != null))
                {
                    user.CorrectOutcomes += userbet.CorrectOutcome();
                    user.CorrectResults += userbet.CorrectBet();
                }
                var knockoutUserBets = _db.KnockoutMatchResultBets.Where(x => x.User == usr.Username).ToList();
                foreach (var knockoutUserBet in knockoutUserBets)
                {
                    user.CorrectOutcomes += knockoutUserBet.CorrectOutcome();
                    user.CorrectResults += knockoutUserBet.CorrectBet();
                }
            }
            return users.OrderByDescending(x => x.Points);
        }
    }

 
}
