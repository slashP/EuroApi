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
    public class TeamController : Controller
    {
        private EuroApiContext db = new EuroApiContext();

        public ActionResult Index()
        {
            var teams = db.Teams.Include(t => t.Group);
            return View(teams.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", team.GroupId);
            return View(team);
        }

        public ActionResult Edit(int id = 0)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", team.GroupId);
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", team.GroupId);
            return View(team);
        }

        public ActionResult Delete(int id = 0)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
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