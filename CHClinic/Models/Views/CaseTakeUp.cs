using CHClinic.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CHClinic.Models.Views
{

    public class DashBoardInfoData
    {
        public decimal? TodayEarning { get; set; }
        public decimal? MonthlyEarning { get; set; }
        public decimal? YearlyEarning { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
    public class PatientListData
    {
        public IEnumerable<Person> People { get; set; }
        public Complaint Complaint { get; set; }
        public History History { get; set; }
        public Generalities Generalities { get; set; }
        public PhyicalExamination Examination{ get; set; }
    }

    public class PatientHistoryData
    {
        public Person Person { get; set; }
        public Complaint Complaint { get; set; }
        public History History { get; set; }
        public Generalities Generalities { get; set; }
        public PhyicalExamination Examination { get; set; }
        public ICollection<VisitEditData> VisitHistorys { get; set; }
    }

    public class VisitListData
    {
        public IEnumerable<Person> People { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
        public IEnumerable<PrescribedMed>Meds { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }

    }

    public class VisitCreateData
    {
        //public int PersonId { get; set; }
        public Visit Visit { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<PrescribedMed> Meds { get; set; }
    }

   public class VisitEditData
    {
        public Visit Visit { get; set; }
        public ICollection<PrescribedMed> Meds { get; set; }
    }

    public class RegularVisitData
    {
        

        public int VisitId { get; set; } //PK
     
        [Required]
        public int PersonId { get; set; } //FK

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Visit Date")]
        public DateTime? VisitDate { get; set; }

        
        [Display(Name = "Complains")]
        public string Problems { get; set; }

        [Display(Name = "Is Revisit")]
        public bool Revisit { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Next Visit Date")]
        public DateTime? NextVisit { get; set; }


        [Display(Name = "Is Billable")]
        public bool Billable { get; set; }

        [Display(Name = "Is Visit Billable")]
        public bool VisitBillable { get; set; }

               
        [Display(Name = "Visit Charge")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal VisitCharge { get; set; }            

        public List<PrescribedMed> PrescribedMeds { get; set; }
        
        public RegularVisitData()
        {
            PrescribedMeds = new List<PrescribedMed>();
        }
    }
}
