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

    public class RegularVisitListData
    {

    }
}
