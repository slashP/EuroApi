﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EuroApi.Context;
using EuroApi.Models;

namespace EuroApi.Controllers
{ 
    [Authorize]
    public class GjestebokController : BaseController
    {
        private readonly FootyFeudContext _db = new FootyFeudContext();

        //
        // GET: /Gjestebok/

        public ViewResult Index()
        {
            if (!SetGuestbookCount()) return null;
            return View(_db.Guestbooks.ToList().OrderByDescending(i => i.Id).Take(50));
        }

        private bool SetGuestbookCount()
        {
            var user = _db.Users.FirstOrDefault(x => x.Username == User.Identity.Name);
            if (user == null) return false;
            user.GuestbookCount = _db.Guestbooks.Count() + _db.Comments.Count();
            _db.SaveChanges();
            ViewBag.GuestbookCountNotRead = 0;
            return true;
        }

        public ActionResult Create()
        {
            var innlegg = _db.Guestbooks.OrderByDescending(m => m.Id).Take(10).ToList();
            ViewBag.Meldinger = innlegg;
            return View();
        } 

        //
        // POST: /Gjestebok/Create

        [HttpPost]
        public ActionResult Create(Guestbook gjestebok)
        {
            gjestebok.Name = User.Identity.Name;
            _db.Guestbooks.Add(gjestebok);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        //
        // GET: /Gjestebok/Edit/5
 
        public ActionResult Kommenter(int id = 1)
        {
            var innlegg = _db.Guestbooks.Find(id);
            var cmts = _db.Comments.Where(c => c.GuestbookId == innlegg.Id);
            var kommentarer = new List<Comment>();
            if(cmts.Any())
                kommentarer = cmts.ToList();
            ViewBag.Melding = innlegg;
            return View(kommentarer);
        }

        //
        // POST: /Gjestebok/Create

        [HttpPost]
        public ActionResult Kommenter(Comment kommentar, int id)
        {
            if (ModelState.IsValid)
            {
                var innlegg = Request["innlegg"];
                var k = new Comment(){GuestbookId = id, Kommentar = innlegg, Name = User.Identity.Name};
                _db.Comments.Add(k);
                _db.SaveChanges();
                SetGuestbookCount();
                return RedirectToAction("Kommenter");
            }

            return null;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}