using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EuroApi.DAL;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Match> _matchRepository = new MatchRepository();
        private readonly IRepository<Team> _teamRepository = new TeamRepository();

        public ActionResult Index()
        {
            var europeanTime = DateTime.UtcNow.AddHours(2);
            var matches = _matchRepository.Query(x => x.Date > europeanTime).OrderBy(x => x.Date).Take(6).ToList();
            var teamsByGroup = new List<IEnumerable<Team>>();
            
            foreach (var groupId in _teamRepository.GetAll().Select(x => x.Group.Name).Distinct())
            {
                teamsByGroup.Add(_teamRepository.Query(x => x.Group.Name == groupId).ToList());
            }
            ViewBag.Groups = teamsByGroup;
            return View(matches);
        }
    }
}
