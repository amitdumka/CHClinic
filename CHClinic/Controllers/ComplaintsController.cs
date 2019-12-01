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
    public class ComplaintsController : Controller
    {
        private ClinicDBContext db = new ClinicDBContext();
        
        // GET: Complaints
        public ActionResult Index()
        {
            var complaints = db.Complaints.Include(c => c.Person);
            return View(complaints.ToList());
        }

        // GET: Complaints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // GET: Complaints/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID",id);
            }
            else
                 ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID");
            ViewBag.returnUrl = Request.UrlReferrer;
            return View();
        }

        // POST: Complaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,HistoryCompalin,MatarnalSide,OwnSide,PaternalSide,PastComplian,PresentComplain")] Complaint complaint, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Complaints.Add(complaint);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", complaint.PersonId);
            return View(complaint);
        }

        // GET: Complaints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", complaint.PersonId);

            ViewBag.returnUrl = Request.UrlReferrer;
            return View(complaint);
        }

        // POST: Complaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,HistoryCompalin,MatarnalSide,OwnSide,PaternalSide,PastComplian,PresentComplain")] Complaint complaint, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);

                // return RedirectToAction(returnUrl);
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", complaint.PersonId);
            return View(complaint);
        }

        // GET: Complaints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.returnUrl = Request.UrlReferrer;
            return View(complaint);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            Complaint complaint = db.Complaints.Find(id);
            db.Complaints.Remove(complaint);
            db.SaveChanges();

            return Redirect(returnUrl);
            //return RedirectToAction("Index");
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
