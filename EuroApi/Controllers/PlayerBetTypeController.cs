using System.Data;
using System.Linq;
using System.Web.Mvc;
using EuroApi.Models;

namespace EuroApi.Controllers
{
    public class PlayerBetTypeController : Controller
    {
        private EuroApiContext db = new EuroApiContext();

        //
        // GET: /PlayerBetType/

        public ActionResult Index()
        {
            return View(db.PlayerBetTypes.ToList());
        }

        //
        // GET: /PlayerBetType/Details/5

        public ActionResult Details(int id = 0)
        {
            PlayerBetType playerbettype = db.PlayerBetTypes.Find(id);
            if (playerbettype == null)
            {
                return HttpNotFound();
            }
            return View(playerbettype);
        }

        //
        // GET: /PlayerBetType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PlayerBetType/Create

        [HttpPost]
        public ActionResult Create(PlayerBetType playerbettype)
        {
            if (ModelState.IsValid)
            {
                db.PlayerBetTypes.Add(playerbettype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerbettype);
        }

        //
        // GET: /PlayerBetType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PlayerBetType playerbettype = db.PlayerBetTypes.Find(id);
            if (playerbettype == null)
            {
                return HttpNotFound();
            }
            return View(playerbettype);
        }

        //
        // POST: /PlayerBetType/Edit/5

        [HttpPost]
        public ActionResult Edit(PlayerBetType playerbettype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerbettype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerbettype);
        }

        //
        // GET: /PlayerBetType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PlayerBetType playerbettype = db.PlayerBetTypes.Find(id);
            if (playerbettype == null)
            {
                return HttpNotFound();
            }
            return View(playerbettype);
        }

        //
        // POST: /PlayerBetType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerBetType playerbettype = db.PlayerBetTypes.Find(id);
            db.PlayerBetTypes.Remove(playerbettype);
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