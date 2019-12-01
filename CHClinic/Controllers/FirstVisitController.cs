using CHClinic.Models;
using CHClinic.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHClinic.Controllers
{
    public class FirstVisitController : Controller
    {

        private ClinicDBContext db = new ClinicDBContext();


        // GET: FirstVisit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateHistory()
        {
            return View();
        }
        public ActionResult CreateComplaints()
        {
            return View();
        }
        public ActionResult CreateGeneralities()
        {
            return View();
        }
        public ActionResult CreatePhyicalExaminations()
        {
            return View();
        }

        //HTTP POST 
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHistory([Bind(Include = "PersonId,Accomodation,Addications,AnyMed,BirthPlace,ChildAges,Diet,Habbit,Hobbies,MaritalStatus,Moutox,NoOfChild,Obes,RelationWithFamily,SexualHistory,Sterlization,Vaccine")] History history)
        {
            if (ModelState.IsValid)
            {
                db.Histories.Add(history);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", history.PersonId);
            return View(history);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComplaints([Bind(Include = "PersonId,HistoryCompalin,MatarnalSide,OwnSide,PastComplian,PaternalSide,PresentComplain")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                db.Complaints.Add(complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "OPDRegistrationID", complaint.PersonId);
            return View(complaint);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGeneralities([Bind(Include = "GeneralitiesId,Appatite,Aversion,Desire,Discharge,Intolerance,Mensutral,Mental,Modalities,Periperation,Salavation,Sentation,Sleep,Stool,Taste,Tendencies,ThermalReaction,Thirst,Urine")] Generalities generalities)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePhyicalExaminations([Bind(Include = "PersonId,Anemia,Apperance,BP,Built,Clubbing,Cynosis,Decubities,Facies,Jaundance,LymphNode,Neck,Nutri,Oedema,Pigmentation,Pluse,ReportDetails,Respiration,Temp")] PhyicalExamination phyicalExamination)
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

    }
}