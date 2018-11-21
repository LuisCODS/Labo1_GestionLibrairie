
using GestionMembrePretDeLivre.DAL;
using GestionMembrePretDeLivre.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GestionMembrePretDeLivre.Controllers
{
    public class PretController : Controller
    {
        private LibrairieDBContext db = new LibrairieDBContext();

        // GET: Pret
        public ActionResult Index()
        {
            var pret = db.Pret.Include(p => p.Livre).Include(p => p.Membre);
            //ViewData["sansDoublon"] = pret.Select(p => p.Membre.Nom).Distinct().ToList());
            return View(pret.ToList());
        }

        // GET: Pret/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = db.Pret.Find(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // GET: Pret/Create
        public ActionResult Create()
        {
            ViewBag.LivreID = new SelectList(db.Livre, "LivreID", "Titre");
            ViewBag.MembreID = new SelectList(db.Membre, "MembreID", "Nom");

            return View();
        }

        // POST: Pret/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PretID,DateDuPret,DateRetour,MembreID,LivreID")] Pret pret)
        {
            if (ModelState.IsValid)
            {        
                Membre trouve = db.Membre.Find(pret.MembreID);
                if (trouve.nbLivres != 3)
                {
                    db.Pret.Add(pret);
                    trouve.nbLivres = trouve.nbLivres + 1;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.msn = 1;
                return View();
            }

            ViewBag.LivreID = new SelectList(db.Livre, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(db.Membre, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // GET: Pret/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = db.Pret.Find(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivreID = new SelectList(db.Livre, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(db.Membre, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // POST: Pret/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PretID,DateDuPret,DateRetour,MembreID,LivreID")] Pret pret)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pret).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivreID = new SelectList(db.Livre, "LivreID", "Titre", pret.LivreID);
            ViewBag.MembreID = new SelectList(db.Membre, "MembreID", "Nom", pret.MembreID);
            return View(pret);
        }

        // GET: Pret/Delete/5
        public ActionResult Delete( int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = db.Pret.Find(id);
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
            Pret pret = db.Pret.Find(id);
            pret.Membre.nbLivres--;
            //Membre trouve = db.Membre.Find(pret.MembreID);
            db.Pret.Remove(pret);
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
