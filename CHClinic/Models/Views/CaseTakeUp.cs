using CHClinic.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHClinic.Models.Views
{
    public class PatientListData
    {
        public IEnumerable<Person> People { get; set; }
        public Complaint Complaint { get; set; }
        public History History { get; set; }
        public Generalities Generalities { get; set; }
        public PhyicalExamination Examination{ get; set; }
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
}
