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
    public class HistoriesController : Controller
    {
        private ClinicDBContext db = new ClinicDBContext();

        // GET: Histories
        public ActionResult Index()
        {
            var histories = db.Histories.Include(h => h.Person);
            return View(histories.ToList());
        }

        // GET: Histories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History history = db.Histories.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            return View(history);
        }

        // GET: Histories/Create
        public ActionResult Create(int? id)
        {
            ViewBag.returnUrl = Request.UrlReferrer;
            if (id != null)
            {
                ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", id);
            }
            else
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID");
            return View();
        }

        // POST: Histories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,Accomodation,Addications,AnyMed,BirthPlace,ChildAges,Diet,Habbit,Hobbies,MaritalStatus,Moutox,NoOfChild,Obes,RelationWithFamily,SexualHistory,Sterlization,Vaccine")] History history, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Histories.Add(history);
                db.SaveChanges();
                return Redirect(returnUrl); //return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", history.PersonId);
            return View(history);
        }

        // GET: Histories/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.returnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History history = db.Histories.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", history.PersonId);
            return View(history);
        }

        // POST: Histories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,Accomodation,Addications,AnyMed,BirthPlace,ChildAges,Diet,Habbit,Hobbies,MaritalStatus,Moutox,NoOfChild,Obes,RelationWithFamily,SexualHistory,Sterlization,Vaccine")] History history, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(history).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl); //return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", history.PersonId);
            return View(history);
        }

        // GET: Histories/Delete/5
        public ActionResult Delete(int? id, string returnPage)
        {
            ViewBag.returnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History history = db.Histories.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            return View(history);
        }

        // POST: Histories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            History history = db.Histories.Find(id);
            db.Histories.Remove(history);
            db.SaveChanges();
            return Redirect(returnUrl); //return RedirectToAction("Index");
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
