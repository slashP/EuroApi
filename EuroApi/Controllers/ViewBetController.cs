using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroApi.Context;

namespace EuroApi.Controllers
{
    public class ViewBetController : Controller
    {
        private FootyFeudContext _db = new FootyFeudContext();

        public ActionResult Username(string username)
        {
            var user = _db.Users.FirstOrDefault(x => x.Username == username);
            if (user == null) return null;
            var europeanTime = DateTime.UtcNow.AddHours(2);
            var bets = _db.MatchResultBets.Where(x => x.User == user.Username && x.Match.Date < europeanTime).ToList();
            return View(bets);
        }

    }
}
