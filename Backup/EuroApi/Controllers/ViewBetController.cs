using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroApi.Context;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    public class ViewBetController : BaseController
    {
        private readonly FootyFeudContext _db = new FootyFeudContext();

        public ActionResult Username(string username)
        {
            var user = _db.Users.FirstOrDefault(x => x.Username == username);
            if (user == null) return null;
            var europeanTime = DateTime.UtcNow.AddHours(2);
            var bets = _db.MatchResultBets.Where(x => x.User == user.Username && x.Match.Date < europeanTime).OrderBy(x => x.Match.Date).ToList();
            return View(bets);
        }

        public ActionResult Match(int id)
        {
            var match = _db.Matches.Find(id);
            if (match == null) return null;
            var europeanTime = DateTime.UtcNow.AddHours(2);
            if(match.Date < europeanTime)
            {
                var bets = _db.MatchResultBets.Where(x => x.MatchId == id).ToList();
                return View(bets);
            }
            return View(new List<MatchResultBet>());
        }
    }
}
