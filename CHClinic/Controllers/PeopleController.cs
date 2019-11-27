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
    public class PeopleController : Controller
    {
        private ClinicDBContext db = new ClinicDBContext();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.Include(p => p.Complaint).Include(p => p.Examination).Include(p => p.Generalities).Include(p => p.History);
            return View(people.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.Complaints, "ComplaintId", "HistoryCompalin");
            ViewBag.PersonId = new SelectList(db.PhyicalExaminations, "PhyicalExaminationId", "Anemia");
            ViewBag.PersonId = new SelectList(db.Generalities, "GeneralitiesId", "Appatite");
            ViewBag.PersonId = new SelectList(db.Histories, "HistoryId", "Accomodation");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,OPDRegistrationID,DateofRecord,FirstName,LastName,Gender,Age,AddressLine1,AddressLine2,City,State,Country,MobileNo,Occupation,Religion")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.Complaints, "ComplaintId", "HistoryCompalin", person.PersonId);
            ViewBag.PersonId = new SelectList(db.PhyicalExaminations, "PhyicalExaminationId", "Anemia", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Generalities, "GeneralitiesId", "Appatite", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Histories, "HistoryId", "Accomodation", person.PersonId);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.Complaints, "ComplaintId", "HistoryCompalin", person.PersonId);
            ViewBag.PersonId = new SelectList(db.PhyicalExaminations, "PhyicalExaminationId", "Anemia", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Generalities, "GeneralitiesId", "Appatite", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Histories, "HistoryId", "Accomodation", person.PersonId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,OPDRegistrationID,DateofRecord,FirstName,LastName,Gender,Age,AddressLine1,AddressLine2,City,State,Country,MobileNo,Occupation,Religion")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.Complaints, "ComplaintId", "HistoryCompalin", person.PersonId);
            ViewBag.PersonId = new SelectList(db.PhyicalExaminations, "PhyicalExaminationId", "Anemia", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Generalities, "GeneralitiesId", "Appatite", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Histories, "HistoryId", "Accomodation", person.PersonId);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
