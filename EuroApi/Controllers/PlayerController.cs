using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    public class PlayerController : Controller
    {
        private EuroApiContext db = new EuroApiContext();

        //
        // GET: /Player/

        public ActionResult Index()
        {
            return View(db.Players.ToList().Take(10));
        }

        public ActionResult TopList()
        {
            var players = db.Players.OrderByDescending(x => x.Goals).ToList();
            return View(players);
        }

        public ActionResult TopTeams()
        {
            var sums = db.Players.GroupBy(x => x.NationalTeam).Select(x => 
                new { 
                    Goals = x.Sum(y => y.Goals),
                    Name = x.FirstOrDefault().NationalTeam,
                    Caps = x.Sum(y => y.Caps),
                    DateOfBirthAverage = x.Average(y => y.DateOfBirth.Year),
                    DateOfBirth = DateTime.MinValue
                }).OrderByDescending(d => d.Goals).ToList();
            var dates = new List<DateTime>(sums.Select(sum => new DateTime((long)sum.DateOfBirthAverage)));
            return null;
        }

        public JsonResult GetPlayerList()
        {
            var playerNames = db.Players.Select(x => x.Name).ToList();
            return Json(playerNames);
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

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Player/Create

        [HttpPost]
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
    }
}