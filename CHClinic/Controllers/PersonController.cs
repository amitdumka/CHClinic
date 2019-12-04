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
using CHClinic.Models.Views;

namespace CHClinic.Controllers
{
    public class PersonController : Controller
    {
        private ClinicDBContext db = new ClinicDBContext();

        // GET: Person
        public ActionResult Index(int? id, string opdRegistrationid, string searchString)
        {
            var opdList = new List<string>();
            var opdQry = from d in db.People
                         orderby d.OPDRegistrationID
                         select d.OPDRegistrationID;
            opdList.AddRange(opdQry.Distinct());
            ViewBag.opdRegistrationid = new SelectList(opdList);

            var viewModel = new PatientListData
            {
                People = db.People.Include(p => p.PatComplaint).Include(p => p.Examination).Include(p => p.PatGeneralities).Include(p => p.PatHistory)
                .OrderBy(p => p.LastName)
            };

            if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrEmpty(opdRegistrationid))
            {
                var people = from p in db.People.Include(p => p.PatComplaint).Include(p => p.Examination).Include(p => p.PatGeneralities).Include(p => p.PatHistory)
                .OrderBy(p => p.LastName)
                             select p;

                if (!String.IsNullOrEmpty(searchString))
                {
                    viewModel.People = people.Where(s => s.MobileNo.Contains(searchString));
                }
                if (!string.IsNullOrEmpty(opdRegistrationid))
                {
                    viewModel.People = people.Where(x => x.OPDRegistrationID == opdRegistrationid);
                }


                return View(viewModel);
            }

            if (id != null)
            {
                ViewBag.PersonId = id.Value;
                viewModel.History = viewModel.People.Where(
                    i => i.PersonId == id.Value).Single().PatHistory;

                viewModel.Complaint = viewModel.People.Where(
                    i => i.PersonId == id.Value).Single().PatComplaint;

                viewModel.Examination = viewModel.People.Where(
                                    i => i.PersonId == id.Value).Single().Examination;

                viewModel.Generalities = viewModel.People.Where(
                                    i => i.PersonId == id.Value).Single().PatGeneralities;


            }
            else
            {
                ViewBag.PersonId = -999;
            }


            return View(viewModel);
        }

        // GET: Person/Details/5
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
            ViewBag.PersonId = person.PersonId;
            List<VisitEditData> visitData = new List<VisitEditData>();
            var visitList = db.Visits.Where(c => c.PersonId == id).OrderByDescending(c => c.VisitDate).Include(c => c.PrescribedMeds);
            foreach (var item in visitList)
            {
                visitData.Add(new VisitEditData() { Visit = item, Meds = item.PrescribedMeds });
            }
            PatientHistoryData historyData = new PatientHistoryData() {
                Person = person, Complaint = person.PatComplaint, Examination = person.Examination, Generalities = person.PatGeneralities,
                History = person.PatHistory, VisitHistorys = visitData
            };

            return View(historyData);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.Complaints, "PersonId", "HistoryCompalin");
            ViewBag.PersonId = new SelectList(db.PhyicalExaminations, "PersonId", "Anemia");
            ViewBag.PersonId = new SelectList(db.Generalities, "PersonId", "Appatite");
            ViewBag.PersonId = new SelectList(db.Histories, "PersonId", "Accomodation");
            return View();
        }

        // POST: Person/Create
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

            ViewBag.PersonId = new SelectList(db.Complaints, "PersonId", "HistoryCompalin", person.PersonId);
            ViewBag.PersonId = new SelectList(db.PhyicalExaminations, "PersonId", "Anemia", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Generalities, "PersonId", "Appatite", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Histories, "PersonId", "Accomodation", person.PersonId);
            return View(person);
        }

        // GET: Person/Edit/5
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
            ViewBag.PersonId = new SelectList(db.Complaints, "PersonId", "HistoryCompalin", person.PersonId);
            ViewBag.PersonId = new SelectList(db.PhyicalExaminations, "PersonId", "Anemia", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Generalities, "PersonId", "Appatite", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Histories, "PersonId", "Accomodation", person.PersonId);
            return View(person);
        }

        // POST: Person/Edit/5
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
            ViewBag.PersonId = new SelectList(db.Complaints, "PersonId", "HistoryCompalin", person.PersonId);
            ViewBag.PersonId = new SelectList(db.PhyicalExaminations, "PersonId", "Anemia", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Generalities, "PersonId", "Appatite", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Histories, "PersonId", "Accomodation", person.PersonId);
            return View(person);
        }

        // GET: Person/Delete/5
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

        // POST: Person/Delete/5
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
