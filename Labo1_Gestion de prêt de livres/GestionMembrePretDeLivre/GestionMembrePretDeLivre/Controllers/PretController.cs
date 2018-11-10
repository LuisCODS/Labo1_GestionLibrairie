using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionMembrePretDeLivre.DAL;
using GestionMembrePretDeLivre.Models;

namespace GestionMembrePretDeLivre.Controllers
{
    public class PretController : Controller
    {
        private MembreContext db = new MembreContext();

        // GET: Pret
        public ActionResult Index()
        {
            var prets = db.Prets.Include(p => p.Livre).Include(p => p.Membre);
            return View(prets.ToList());
        }

        // GET: Pret/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = db.Prets.Find(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // GET: Pret/Create
        public ActionResult Create()
        {
            ViewBag.LivreID = new SelectList(db.Livres, "LivreID", "Titre");
            ViewBag.MembreID = new SelectList(db.Membres, "MembreID", "Nom");
            return View();
        }

        // POST: Pret/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PretID,DateDuPret,MembreID,LivreID")] Pret pret)
        {
            if (ModelState.IsValid)
            {
                db.Prets.Add(pret);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LivreID = new SelectList(db.Livres, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(db.Membres, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // GET: Pret/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = db.Prets.Find(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivreID = new SelectList(db.Livres, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(db.Membres, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // POST: Pret/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PretID,DateDuPret,MembreID,LivreID")] Pret pret)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pret).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivreID = new SelectList(db.Livres, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(db.Membres, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // GET: Pret/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = db.Prets.Find(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // POST: Pret/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pret pret = db.Prets.Find(id);
            db.Prets.Remove(pret);
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
