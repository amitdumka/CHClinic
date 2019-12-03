using CHClinic.Models;
using CHClinic.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using CHClinic.Models.Data;
using System.Net;

namespace CHClinic.Controllers
{
    public class RegularVisitController : Controller
    {
        private ClinicDBContext db = new ClinicDBContext();
        // GET: RegularVisit
        public ActionResult Index(int? id, int? personId, string opdRegistrationid, string searchString)
        {
            var opdList = new List<string>();
            var opdQry = from d in db.People
                         orderby d.OPDRegistrationID
                         select d.OPDRegistrationID;
            opdList.AddRange(opdQry.Distinct());
            ViewBag.opdRegistrationid = new SelectList(opdList);




            var viewModel = new VisitListData
            {
                People = db.People.Include(p => p.Visits).OrderBy(p => p.LastName),

                Visits = db.Visits.Include(v => v.Person)
                 .Include(i => i.Invoices)
                 .Include(i => i.PrescribedMeds)
                .OrderByDescending(i => i.VisitDate)
            };

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

        // GET: RegularVisit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegularVisit/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID");
            var ViewModel = new RegularVisitData
            {
                PrescribedMeds = new List<PrescribedMed> { new PrescribedMed { VisitId = 0, MedicineName = "", Power = "", NoOfTime = "", Quantity = "", Remarks = "" } }
            };

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

        // GET: RegularVisit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            //Visit visit = db.Visits.Find(id);

            //if (visit == null)
            //{
            //    return HttpNotFound();
            //}

            VisitEditData EditModel = new VisitEditData
            {
                Visit = db.Visits.Find(id)
            };
            if (EditModel.Visit == null)
            {
                return HttpNotFound();
            }
            EditModel.Meds = db.PrescribedMeds.Where(c => c.VisitId == id).ToList();

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", EditModel.Visit.PersonId);
            return View(EditModel);
        }

        // POST: RegularVisit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VisitEditData todayVisit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    

                    db.Entry(todayVisit.Visit).State = EntityState.Modified;
                    foreach(var a in todayVisit.Meds)
                    {
                        db.Entry(a).State= EntityState.Modified;
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", todayVisit.Visit.PersonId);
                return View(todayVisit);


            }
            catch
            {
                ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", todayVisit.Visit.PersonId);
                return View();
            }
        }

        // GET: RegularVisit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegularVisit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
