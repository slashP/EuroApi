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
    public class MatchResultBetController : Controller
    {
        private readonly EuroApiContext _db = new EuroApiContext();

        //
        // GET: /MatchResultBet/

        public ActionResult Index()
        {
            var matchresultbets = _db.MatchResultBets.Include(m => m.Match);
            return View(matchresultbets.ToList());
        }

        //
        // GET: /MatchResultBet/Details/5

        public ActionResult Details(int id = 0)
        {
            MatchResultBet matchresultbet = _db.MatchResultBets.Find(id);
            if (matchresultbet == null)
            {
                return HttpNotFound();
            }
            return View(matchresultbet);
        }

        //
        // GET: /MatchResultBet/Create

        public ActionResult Create()
        {
            ViewBag.MatchId = new SelectList(_db.Matches, "Id", "Id");
            return View();
        }

        //
        // POST: /MatchResultBet/Create

        [HttpPost]
        public ActionResult Create(MatchResultBet matchresultbet)
        {
            if (ModelState.IsValid)
            {
                _db.MatchResultBets.Add(matchresultbet);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchId = new SelectList(_db.Matches, "Id", "Id", matchresultbet.MatchId);
            return View(matchresultbet);
        }

        //
        // GET: /MatchResultBet/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MatchResultBet matchresultbet = _db.MatchResultBets.Find(id);
            if (matchresultbet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchId = new SelectList(_db.Matches, "Id", "Id", matchresultbet.MatchId);
            return View(matchresultbet);
        }

        //
        // POST: /MatchResultBet/Edit/5

        [HttpPost]
        public ActionResult Edit(MatchResultBet matchresultbet)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(matchresultbet).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatchId = new SelectList(_db.Matches, "Id", "Id", matchresultbet.MatchId);
            return View(matchresultbet);
        }

        //
        // GET: /MatchResultBet/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MatchResultBet matchresultbet = _db.MatchResultBets.Find(id);
            if (matchresultbet == null)
            {
                return HttpNotFound();
            }
            return View(matchresultbet);
        }

        //
        // POST: /MatchResultBet/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchResultBet matchresultbet = _db.MatchResultBets.Find(id);
            _db.MatchResultBets.Remove(matchresultbet);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}