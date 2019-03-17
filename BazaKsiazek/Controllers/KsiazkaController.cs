using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;

namespace BazaKsiazek.Controllers
{
    public class KsiazkaController : Controller
    {
        private BazaKsiazekContext db = new BazaKsiazekContext();

        // GET: Ksiazka
        public ActionResult Index()
        {
            var ksiazki = db.Ksiazki.Include(k => k.Uzytkownik);
            return View(ksiazki.ToList());
        }

        // GET: Ksiazka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }

        // GET: Ksiazka/Create
        public ActionResult Create()
        {
            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Ksiazka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ISBN,Tytul,DataWydania,DataDodania,UzytkownikId")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Ksiazki.Add(ksiazka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email", ksiazka.UzytkownikId);
            return View(ksiazka);
        }

        // GET: Ksiazka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email", ksiazka.UzytkownikId);
            return View(ksiazka);
        }

        // POST: Ksiazka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ISBN,Tytul,DataWydania,DataDodania,UzytkownikId")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ksiazka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UzytkownikId = new SelectList(db.Users, "Id", "Email", ksiazka.UzytkownikId);
            return View(ksiazka);
        }

        // GET: Ksiazka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }

        // POST: Ksiazka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            db.Ksiazki.Remove(ksiazka);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
