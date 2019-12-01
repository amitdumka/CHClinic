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
    public class PhyicalExaminationsController : Controller
    {
        private ClinicDBContext db = new ClinicDBContext();

        // GET: PhyicalExaminations
        public ActionResult Index()
        {
            var phyicalExaminations = db.PhyicalExaminations.Include(p => p.Person);
            return View(phyicalExaminations.ToList());
        }

        // GET: PhyicalExaminations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhyicalExamination phyicalExamination = db.PhyicalExaminations.Find(id);
            if (phyicalExamination == null)
            {
                return HttpNotFound();
            }
            return View(phyicalExamination);
        }

        // GET: PhyicalExaminations/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID");
            return View();
        }

        // POST: PhyicalExaminations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,Anemia,Apperance,BP,Built,Clubbing,Cynosis,Decubities,Facies,Jaundance,LymphNode,Neck,Nutri,Oedema,Pigmentation,Pluse,ReportDetails,Respiration,Temp")] PhyicalExamination phyicalExamination)
        {
            if (ModelState.IsValid)
            {
                db.PhyicalExaminations.Add(phyicalExamination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", phyicalExamination.PersonId);
            return View(phyicalExamination);
        }

        // GET: PhyicalExaminations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhyicalExamination phyicalExamination = db.PhyicalExaminations.Find(id);
            if (phyicalExamination == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", phyicalExamination.PersonId);
            return View(phyicalExamination);
        }

        // POST: PhyicalExaminations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,Anemia,Apperance,BP,Built,Clubbing,Cynosis,Decubities,Facies,Jaundance,LymphNode,Neck,Nutri,Oedema,Pigmentation,Pluse,ReportDetails,Respiration,Temp")] PhyicalExamination phyicalExamination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phyicalExamination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", phyicalExamination.PersonId);
            return View(phyicalExamination);
        }

        // GET: PhyicalExaminations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhyicalExamination phyicalExamination = db.PhyicalExaminations.Find(id);
            if (phyicalExamination == null)
            {
                return HttpNotFound();
            }
            return View(phyicalExamination);
        }

        // POST: PhyicalExaminations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhyicalExamination phyicalExamination = db.PhyicalExaminations.Find(id);
            db.PhyicalExaminations.Remove(phyicalExamination);
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
