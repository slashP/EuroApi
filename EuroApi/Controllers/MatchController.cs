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
    public class MatchController : Controller
    {
        private EuroApiContext db = new EuroApiContext();

        //
        // GET: /Match/

        public ActionResult Index()
        {
            var matches = db.Matches.Include(m => m.HomeTeam).Include(m => m.GuestTeam);
            return View(matches.ToList());
        }

        //
        // GET: /Match/Details/5

        public ActionResult Details(int id = 0)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        //
        // GET: /Match/Create

        public ActionResult Create()
        {
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name");
            ViewBag.GuestTeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        //
        // POST: /Match/Create

        [HttpPost]
        public ActionResult Create(Match match)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name", match.HomeTeamId);
            ViewBag.GuestTeamId = new SelectList(db.Teams, "Id", "Name", match.GuestTeamId);
            return View(match);
        }

        //
        // GET: /Match/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name", match.HomeTeamId);
            ViewBag.GuestTeamId = new SelectList(db.Teams, "Id", "Name", match.GuestTeamId);
            return View(match);
        }

        //
        // POST: /Match/Edit/5

        [HttpPost]
        public ActionResult Edit(Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name", match.HomeTeamId);
            ViewBag.GuestTeamId = new SelectList(db.Teams, "Id", "Name", match.GuestTeamId);
            return View(match);
        }

        //
        // GET: /Match/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        //
        // POST: /Match/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
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