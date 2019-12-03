using CHClinic.Models;
using CHClinic.Models.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHClinic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DashBoardInfoData infoData = new DashBoardInfoData();
            using (ClinicDBContext db = new ClinicDBContext())
            {
                DateTime date = DateTime.Today;
                infoData.TodayEarning= db.Incomes.Where(c=> DbFunctions.TruncateTime(c.IncomeDate)== DbFunctions.TruncateTime(date)).Sum(s=>(decimal?) s.Amount)??0;
                infoData.MonthlyEarning = db.Incomes.Where(c => DbFunctions.TruncateTime( c.IncomeDate).Value.Month == date.Month).Sum(s => (decimal?)s.Amount)??0;
                infoData.YearlyEarning = db.Incomes.Where(c => DbFunctions.TruncateTime(c.IncomeDate).Value.Year == date.Year).Sum(s => (decimal?)s.Amount)??0;
                infoData.Appointments = db.Appointments.Where(c => DbFunctions.TruncateTime(c.Date) >= date).Include(c=>c.Person).ToList();

            }
            if (infoData.TodayEarning == null)
            {
                infoData.TodayEarning = 0;
            }
            if (infoData.YearlyEarning == null)
            {
                infoData.YearlyEarning = 0;
            }
            if (infoData.MonthlyEarning == null)
            {
                infoData.MonthlyEarning = 0;
            }
            return View(infoData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Calcutta Homeo Clinic.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us.";

            return View();
        }
    }
}