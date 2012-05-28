using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroApi.Models;
using EuroApi.Context;

namespace EuroApi.Controllers
{
    public class KnockoutMatchController : Controller
    {
        private readonly FootyFeudContext _db = new FootyFeudContext();

        //
        // GET: /KnockoutMatch/

        public ActionResult Index()
        {
            var knockoutmatches = _db.KnockoutMatches.Include(k => k.HomeTeam).Include(k => k.AwayTeam);
            return View(knockoutmatches.ToList());
        }

        //
        // GET: /KnockoutMatch/Details/5

        public ActionResult Details(int id = 0)
        {
            KnockoutMatch knockoutmatch = _db.KnockoutMatches.Find(id);
            if (knockoutmatch == null)
            {
                return HttpNotFound();
            }
            return View(knockoutmatch);
        }

        //
        // GET: /KnockoutMatch/Create

        public ActionResult Create()
        {
            ViewBag.HomeTeamId = new SelectList(_db.Teams, "Id", "Name");
            ViewBag.AwayTeamId = new SelectList(_db.Teams, "Id", "Name");
            return View();
        }

        //
        // POST: /KnockoutMatch/Create

        [HttpPost]
        public ActionResult Create(KnockoutMatch knockoutmatch)
        {
            if (ModelState.IsValid)
            {
                _db.KnockoutMatches.Add(knockoutmatch);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomeTeamId = new SelectList(_db.Teams, "Id", "Name", knockoutmatch.HomeTeamId);
            ViewBag.AwayTeamId = new SelectList(_db.Teams, "Id", "Name", knockoutmatch.AwayTeamId);
            return View(knockoutmatch);
        }

        //
        // GET: /KnockoutMatch/Edit/5

        public ActionResult Edit(int id = 0)
        {
            KnockoutMatch knockoutmatch = _db.KnockoutMatches.Find(id);
            if (knockoutmatch == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomeTeamId = new SelectList(_db.Teams, "Id", "Name", knockoutmatch.HomeTeamId);
            ViewBag.AwayTeamId = new SelectList(_db.Teams, "Id", "Name", knockoutmatch.AwayTeamId);
            return View(knockoutmatch);
        }

        //
        // POST: /KnockoutMatch/Edit/5

        [HttpPost]
        public ActionResult Edit(KnockoutMatch knockoutmatch)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(knockoutmatch).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomeTeamId = new SelectList(_db.Teams, "Id", "Name", knockoutmatch.HomeTeamId);
            ViewBag.AwayTeamId = new SelectList(_db.Teams, "Id", "Name", knockoutmatch.AwayTeamId);
            return View(knockoutmatch);
        }

        //
        // GET: /KnockoutMatch/Delete/5

        public ActionResult Delete(int id = 0)
        {
            KnockoutMatch knockoutmatch = _db.KnockoutMatches.Find(id);
            if (knockoutmatch == null)
            {
                return HttpNotFound();
            }
            return View(knockoutmatch);
        }

        //
        // POST: /KnockoutMatch/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            KnockoutMatch knockoutmatch = _db.KnockoutMatches.Find(id);
            _db.KnockoutMatches.Remove(knockoutmatch);
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