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
    public class PrescribedMedsController : Controller
    {
        private ClinicDBContext db = new ClinicDBContext();

        public ActionResult BulkSave()
        {
            List<PrescribedMed> ci = new List<PrescribedMed> { new PrescribedMed { VisitId = 0, MedicineName = "", Power = "",NoOfTime="",Quantity="" } };
            return View(ci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkSave(List<PrescribedMed> ci)
        {
            if (ModelState.IsValid)
            {
                
                    foreach (var i in ci)
                    {
                        db.PrescribedMeds.Add(i);
                    }
                    db.SaveChanges();
                    ViewBag.Message = "Data successfully saved!";
                    ModelState.Clear();
                    ci = new List<PrescribedMed> { new PrescribedMed { VisitId = 0, MedicineName = "", Power = "", NoOfTime = "", Quantity = "" } };
                
            }
            return View(ci);
        }
        // GET: PrescribedMeds
        public ActionResult Index()
        {
            var prescribedMeds = db.PrescribedMeds.Include(p => p.Visit);
            return View(prescribedMeds.ToList());
        }

        // GET: PrescribedMeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrescribedMed prescribedMed = db.PrescribedMeds.Find(id);
            if (prescribedMed == null)
            {
                return HttpNotFound();
            }
            return View(prescribedMed);
        }

        // GET: PrescribedMeds/Create
        public ActionResult Create()
        {
            ViewBag.VisitId = new SelectList(db.Visits, "VisitId", "Problems");
            return View();
        }

        // POST: PrescribedMeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrescribedMedId,VisitId,MedicineName,Description,Power,NoOfTime,Quantity,Cost,Remarks")] PrescribedMed prescribedMed)
        {
            if (ModelState.IsValid)
            {
                db.PrescribedMeds.Add(prescribedMed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VisitId = new SelectList(db.Visits, "VisitId", "Problems", prescribedMed.VisitId);
            return View(prescribedMed);
        }

        // GET: PrescribedMeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrescribedMed prescribedMed = db.PrescribedMeds.Find(id);
            if (prescribedMed == null)
            {
                return HttpNotFound();
            }
            ViewBag.VisitId = new SelectList(db.Visits, "VisitId", "Problems", prescribedMed.VisitId);
            return View(prescribedMed);
        }

        // POST: PrescribedMeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrescribedMedId,VisitId,MedicineName,Description,Power,NoOfTime,Quantity,Cost,Remarks")] PrescribedMed prescribedMed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescribedMed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VisitId = new SelectList(db.Visits, "VisitId", "Problems", prescribedMed.VisitId);
            return View(prescribedMed);
        }

        // GET: PrescribedMeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrescribedMed prescribedMed = db.PrescribedMeds.Find(id);
            if (prescribedMed == null)
            {
                return HttpNotFound();
            }
            return View(prescribedMed);
        }

        // POST: PrescribedMeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrescribedMed prescribedMed = db.PrescribedMeds.Find(id);
            db.PrescribedMeds.Remove(prescribedMed);
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
