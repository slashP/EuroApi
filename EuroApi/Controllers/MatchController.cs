using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    public class MatchController : Controller
    {
        private EuroApiContext db = new EuroApiContext();

        public ActionResult Index()
        {
            var matches = db.Matches.Include(m => m.HomeTeam).Include(m => m.GuestTeam);
            return View(matches.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        public ActionResult Create()
        {
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name");
            ViewBag.GuestTeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

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

        public ActionResult Delete(int id = 0)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

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