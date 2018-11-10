﻿using System;
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
    public class MembreController : Controller
    {
        private MembreContext db = new MembreContext();

        // GET: Membre
        public ActionResult Index()
        {
            return View(db.Membres.ToList());
        }

        // GET: Membre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = db.Membres.Find(id);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // GET: Membre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Membre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MembreID,Nom,Prenom,Telephone,Email,EnRetard")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                db.Membres.Add(membre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membre);
        }

        // GET: Membre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = db.Membres.Find(id);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // POST: Membre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MembreID,Nom,Prenom,Telephone,Email,EnRetard")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membre);
        }

        // GET: Membre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = db.Membres.Find(id);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // POST: Membre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membre membre = db.Membres.Find(id);
            db.Membres.Remove(membre);
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
