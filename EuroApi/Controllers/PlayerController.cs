using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroApi.Context;
using EuroApi.DAL;
using EuroApi.Models;
using EuroApi.Util;

namespace EuroApi.Controllers
{
    public class PlayerController : Controller
    {
        IRepository<Team> _teamRepository = new TeamRepository();
        private FootyFeudContext db = new FootyFeudContext();

        //
        // GET: /Player/

        public ActionResult Index()
        {
            var teams = _teamRepository.GetAll().OrderBy(x => x.GroupId).ToList();
            ViewBag.Teams = teams;
            return View(db.Players.ToList().Take(10));
        }

        public ActionResult TopList()
        {
            var players = db.Players.OrderByDescending(x => x.Goals).ToList();
            return View(players);
        }

        [OutputCache(Duration = 3600)]
        public ActionResult TopTeams()
        {
            var sums = db.Players.GroupBy(x => x.NationalTeam).Select(x => 
                new { 
                    Goals = x.Sum(y => y.Goals),
                    Name = x.FirstOrDefault().NationalTeam,
                    Caps = x.Sum(y => y.Caps),
                    DateOfBirthAverage = x.Average(y => (y.DateOfBirth.Year * 365 + y.DateOfBirth.Month * 30 + y.DateOfBirth.Day)/365),
                    DateOfBirth = DateTime.MinValue,
                }).OrderByDescending(d => d.Goals);
            var datoer = new List<string>();
            foreach (var dato in sums.Select(x => x.DateOfBirthAverage))
            {
                if(Math.Abs(Math.Round(dato, 2) - Math.Round(dato, 0)) < 0.05)
                    datoer.Add(Math.Round(dato,0) + ".0");
                else
                    datoer.Add(Math.Round(dato, 1).ToString(CultureInfo.InvariantCulture));
            }
            ViewBag.Goals = sums.Select(x => x.Goals).ToList();
            ViewBag.Names = sums.Select(x => x.Name).ToList();
            ViewBag.Caps = sums.Select(x => x.Caps).ToList();
            ViewBag.DateOfBirthAverage = datoer;
            return View("TopTeams");
        }

        public JsonResult GetPlayerList()
        {
            var playerNames = db.Players.OrderBy(x => x.NationalTeam).Select(x => x.Name).ToList();
            return Json(playerNames);
        }

        public JsonResult GetPlayerListWithLabels()
        {
            var players = db.Players.OrderBy(x => x.NationalTeam).Select(x => new { label = x.Name, id = x.Id }).ToList();
            return Json(players);
        }

        public ActionResult Show(string name)
        {
            var player = db.Players.FirstOrDefault(t => t.Name == name);
            if (player == null)
                return RedirectToAction("Index");
            return RedirectToAction("Details", new {id = player.Id});
        }

        //
        // GET: /Player/Details/5

        public ActionResult Details(int id = 0)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // GET: /Player/Create
        [Authorize(Users = "perkrihe, slashP")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Player/Create

        [HttpPost]
        [Authorize(Users = "perkrihe, slashP")]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        //
        // GET: /Player/Edit/5
        [Authorize(Users = "perkrihe, slashP")]
        public ActionResult Edit(int id = 0)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // POST: /Player/Edit/5

        [HttpPost]
        [Authorize(Users = "perkrihe, slashP")]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        //
        // GET: /Player/Delete/5

        [Authorize(Users = "perkrihe, slashP")]
        public ActionResult Delete(int id = 0)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // POST: /Player/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Users = "perkrihe, slashP")]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Team(int id)
        {
            var teamName = _teamRepository.Find(id).Name;
            return View(db.Players.Where(x => x.NationalTeam == teamName).ToList());
        }
    }
}