using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CHClinic.Models;
using CHClinic.Models.Data;

namespace CHClinic.Controllers
{
    public class GeneralitiesController : Controller
    {
        private ClinicDBContext db = new ClinicDBContext();

        // GET: Generalities
        public ActionResult Index()
        {
            var generalities = db.Generalities.Include(g => g.Person);
            return View(generalities.ToList());
        }

        // GET: Generalities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Generalities generalities = db.Generalities.Find(id);
            if (generalities == null)
            {
                return HttpNotFound();
            }
            return View(generalities);
        }

        // GET: Generalities/Create
        public ActionResult Create()
        {
            ViewBag.GeneralitiesId = new SelectList(db.People, "PersonId", "OPDRegistrationID");
            return View();
        }

        // POST: Generalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GeneralitiesId,Appatite,Aversion,Desire,Discharge,Intolerance,Mensutral,Mental,Modalities,Periperation,Salavation,Sentation,Sleep,Stool,Taste,Tendencies,ThermalReaction,Thirst,Urine")] Generalities generalities)
        {
            if (ModelState.IsValid)
            {
                db.Generalities.Add(generalities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeneralitiesId = new SelectList(db.People, "PersonId", "OPDRegistrationID", generalities.PersonId);
            return View(generalities);
        }

        // GET: Generalities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Generalities generalities = db.Generalities.Find(id);
            if (generalities == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneralitiesId = new SelectList(db.People, "PersonId", "OPDRegistrationID", generalities.PersonId);
            return View(generalities);
        }

        // POST: Generalities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GeneralitiesId,Appatite,Aversion,Desire,Discharge,Intolerance,Mensutral,Mental,Modalities,Periperation,Salavation,Sentation,Sleep,Stool,Taste,Tendencies,ThermalReaction,Thirst,Urine")] Generalities generalities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generalities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeneralitiesId = new SelectList(db.People, "PersonId", "OPDRegistrationID", generalities.PersonId);
            return View(generalities);
        }

        // GET: Generalities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Generalities generalities = db.Generalities.Find(id);
            if (generalities == null)
            {
                return HttpNotFound();
            }
            return View(generalities);
        }

        // POST: Generalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Generalities generalities = db.Generalities.Find(id);
            db.Generalities.Remove(generalities);
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
