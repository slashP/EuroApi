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
    public class BogusController : Controller
    {
        private EuroApiContext db = new EuroApiContext();

        //
        // GET: /Bogus/

        public ActionResult Index()
        {
            var matchresultbets = db.MatchResultBets.Include(m => m.Match);
            return View(matchresultbets.ToList());
        }

        //
        // GET: /Bogus/Details/5

        public ActionResult Details(int id = 0)
        {
            MatchResultBet matchresultbet = db.MatchResultBets.Find(id);
            if (matchresultbet == null)
            {
                return HttpNotFound();
            }
            return View(matchresultbet);
        }

        //
        // GET: /Bogus/Create

        public ActionResult Create()
        {
            ViewBag.MatchId = new SelectList(db.Matches, "Id", "Place");
            return View();
        }

        //
        // POST: /Bogus/Create

        [HttpPost]
        public ActionResult Create(MatchResultBet matchresultbet)
        {
            if (ModelState.IsValid)
            {
                db.MatchResultBets.Add(matchresultbet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchId = new SelectList(db.Matches, "Id", "Place", matchresultbet.MatchId);
            return View(matchresultbet);
        }

        //
        // GET: /Bogus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MatchResultBet matchresultbet = db.MatchResultBets.Find(id);
            if (matchresultbet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchId = new SelectList(db.Matches, "Id", "Place", matchresultbet.MatchId);
            return View(matchresultbet);
        }

        //
        // POST: /Bogus/Edit/5

        [HttpPost]
        public ActionResult Edit(MatchResultBet matchresultbet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchresultbet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatchId = new SelectList(db.Matches, "Id", "Place", matchresultbet.MatchId);
            return View(matchresultbet);
        }

        //
        // GET: /Bogus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MatchResultBet matchresultbet = db.MatchResultBets.Find(id);
            if (matchresultbet == null)
            {
                return HttpNotFound();
            }
            return View(matchresultbet);
        }

        //
        // POST: /Bogus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchResultBet matchresultbet = db.MatchResultBets.Find(id);
            db.MatchResultBets.Remove(matchresultbet);
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