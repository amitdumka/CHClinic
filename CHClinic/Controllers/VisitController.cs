using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CHClinic.Models;
using CHClinic.Models.Data;
using CHClinic.Models.Views;

namespace CHClinic.Controllers
{
    public class VisitController : Controller
    {
        private ClinicDBContext db = new ClinicDBContext();

        // GET: Visit
        public ActionResult Index(int? id, int? personId, string opdRegistrationid, string searchString)
        {
            var opdList = new List<string>();
            var opdQry = from d in db.People
                         orderby d.OPDRegistrationID
                         select d.OPDRegistrationID;
            opdList.AddRange(opdQry.Distinct());
            ViewBag.opdRegistrationid = new SelectList(opdList);




            var viewModel = new VisitListData();
            viewModel.People = db.People.Include(p => p.Visits).OrderBy(p => p.LastName);

            viewModel.Visits = db.Visits.Include(v => v.Person)
                 .Include(i => i.Invoices)
                 .Include(i => i.PrescribedMeds)
                .OrderByDescending(i => i.VisitDate);

            if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrEmpty(opdRegistrationid))
            {
                var people = from p in db.People.Include(p => p.Complaint).Include(p => p.Examination).Include(p => p.Generalities).Include(p => p.History)
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
                ViewBag.VisitId = id.Value;
                viewModel.Meds = viewModel.Visits.Where(
                    i => i.VisitId == id.Value).Single().PrescribedMeds;
                viewModel.Invoices = viewModel.Visits.Where(
                    i => i.VisitId == id.Value).Single().Invoices;
            }


            return View(viewModel);

        }

        // GET: Visit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // GET: RegularVisit/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID");
            var ViewModel = new RegularVisitData();
            ViewModel.PrescribedMeds = new List<PrescribedMed> { new PrescribedMed { VisitId = 0, MedicineName = "", Power = "", NoOfTime = "", Quantity = "", Remarks = "" } };

            return View(ViewModel);
        }

        // POST: RegularVisit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegularVisitData todayVisit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Visit visit = new Visit()
                    {
                        PersonId = todayVisit.PersonId,
                        Problems = todayVisit.Problems,
                        Billable = todayVisit.Billable,
                        NextVisit = todayVisit.NextVisit,
                        Revisit = todayVisit.Revisit,
                        VisitBillable = todayVisit.VisitBillable,
                        VisitCharge = todayVisit.VisitCharge,
                        VisitDate = todayVisit.VisitDate
                    };
                    foreach (var med in todayVisit.PrescribedMeds)
                    {
                        visit.PrescribedMeds.Add(med);
                    }

                    if (visit.Revisit)
                    {
                        Appointment apps = db.Appointments.Where(c => c.PersonId == visit.PersonId).OrderByDescending(c => c.Date).FirstOrDefault();

                        if (apps != null)
                        {
                            apps.VisitDate = visit.VisitDate;
                            db.Entry(apps).State = EntityState.Modified;
                        }
                    }

                    if (visit.VisitCharge > 0)
                    {
                        Income income = new Income()
                        {
                            Amount = visit.VisitCharge,
                            IncomeDate = visit.VisitDate
                        };
                        db.Incomes.Add(income);
                    }
                    if (visit.NextVisit != null)
                    {
                        Appointment apps = new Appointment()
                        {
                            Date = (DateTime)(visit.NextVisit),
                            PersonId = visit.PersonId
                        };
                        db.Appointments.Add(apps);

                    }
                    db.Visits.Add(visit);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.PersonId = new SelectList(db.People, "PersonId", "PersonId", todayVisit.PersonId);
                return View(todayVisit);

            }
            catch
            {
                return View();
            }
        }


        // GET: Visit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", visit.PersonId);
            return View(visit);
        }

        // POST: Visit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitId,PersonId,VisitDate,Problems,Revisit,NextVisit,Billable,VisitBillable")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", visit.PersonId);
            return View(visit);
        }

        // GET: Visit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: Visit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
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
    
        private void PopulateDropDownList(object selectedPerson = null)
        {
            var Query = from d in db.People
                                   orderby d.OPDRegistrationID
                                   select d;
            ViewBag.PersonId = new SelectList(Query, "PersonId", "PersonId", selectedPerson);
        }
    }
}
