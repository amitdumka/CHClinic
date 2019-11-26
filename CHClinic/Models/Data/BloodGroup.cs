using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHClinic.Models.Data
{

    enum BloodGroups { Ap, Bp, Op, An, Bn, On, ABp, ABn }

    class BloodGroup
    {
        public int BloodGroupId { get; set; }
        public string Blood { get; set; }
        public string RH { get; set; }
    }

    class Visit
    {
        public Visit()
        {
           this. PrescribedMeds =new HashSet<PrescribedMed>();
            this.Invoices = new HashSet<Invoice>();
        }

        public int VisitId { get; set; }
        public int OPDRegID { get; set; }
        
        public DateTime? VisitDate { get; set; }
        public int VisitNo { get; set; }
        public int Revisit { get; set; }
        public DateTime? NextVisit { get; set; }
        public string Problems { get; set; }
        public int Billable { get; set; }
        public int VisitBillable { get; set; }

        public virtual OPDReg OPDReg { get; set; }

        public virtual ICollection<PrescribedMed> PrescribedMeds { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }


    }
    class PrescribedMed
    {
        public int PrescribedMedId { get; set; }
        public int OPDRegId { get; set; }
        public int VisitID { get; set; }

        public string MedicineName { get; set; }
        public string Description { get; set; }
        public string Power { get; set; }
        public string NoOfTime { get; set; }
        public string Quantity { get; set; }
        public float Cost { get; set; }
        public string Remarks { get; set; }

        public virtual OPDReg OPDReg { get; set; }
        public virtual Visit Visit { get; set; }
    }

    class Invoice
    {
        public int InvoiceId { get; set; }
        public int OPDRegId { get; set; }
        public int VisitId { get; set; }
        
        public float VisitCharge { get; set; }
        public float MedCharge { get; set; }
        public float OtherCharges { get; set; }
        public float Paid { get; set; }
        public float Dues { get; set; }
        public string Remarks { get; set; }

        public virtual OPDReg OPDReg { get; set; }
        public virtual Visit Visit { get; set; }

    }


}