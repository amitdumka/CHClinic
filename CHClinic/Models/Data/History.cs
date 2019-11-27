using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHClinic.Models.Data
{
    public class History
    {
        [ForeignKey("Person")]
        public int HistoryId { get; set; }
        //public int PersonId { get; set; }
        public string Accomodation { get; set; }
        public string Addications { get; set; }
        public string AnyMed { get; set; }
        public string BirthPlace { get; set; }
        public string ChildAges { get; set; }
        public string Diet { get; set; }
        public string Habbit { get; set; }
        public string Hobbies { get; set; }
        public string MaritalStatus { get; set; }
        public string Moutox { get; set; }
        public int NoOfChild { get; set; }
        public string Obes { get; set; }
        public string RelationWithFamily { get; set; }
        public string SexualHistory { get; set; }
        public string Sterlization { get; set; }
        public string Vaccine { get; set; }

        public virtual Person Person { get; set; }
    }


    public class Complaint
    {
        [ForeignKey("Person")]
        public int ComplaintId { get; set; }
        //public int PersonId { get; set; }

        public string HistoryCompalin { get; set; }
        public string MatarnalSide { get; set; }
        public string OwnSide { get; set; }
        public string PastComplian { get; set; }
        public string PaternalSide { get; set; }
        public string PresentComplain { get; set; }

        public virtual Person Person { get; set; }
    }

    public class PhyicalExamination
    {
        [ForeignKey("Person")]
        public int PhyicalExaminationId { get; set; }
        //public int PersonId { get; set; }

        public string Anemia { get; set; }
        public string Apperance { get; set; }
        public string BP { get; set; }
        public string Built { get; set; }
        public string Clubbing { get; set; }
        public string Cynosis { get; set; }
        public string Decubities { get; set; }
        public string Facies { get; set; }
        public string Jaundance { get; set; }
        public string LymphNode { get; set; }
        public string Neck { get; set; }
        public string Nutri { get; set; }
        public string Oedema { get; set; }
        public string Pigmentation { get; set; }
        public string Pluse { get; set; }
        public string ReportDetails { get; set; }
        public string Respiration { get; set; }
        public string Temp { get; set; }

        public virtual Person Person { get; set; }
    }

    public class Generalities
    {
        [ForeignKey("Person")]
        public int GeneralitiesId { get; set; }
        //public int PersonId { get; set; }

        public string Appatite { get; set; }
        public string Aversion { get; set; }
        public string Desire { get; set; }
        public string Discharge { get; set; }
        public string Intolerance { get; set; }
        public string Mensutral { get; set; }
        public string Mental { get; set; }
        public string Modalities { get; set; }
        public string Periperation { get; set; }
        public string Salavation { get; set; }
        public string Sentation { get; set; }
        public string Sleep { get; set; }
        public string Stool { get; set; }
        public string Taste { get; set; }
        public string Tendencies { get; set; }
        public string ThermalReaction { get; set; }
        public string Thirst { get; set; }
        public string Urine { get; set; }

        public virtual Person Person { get; set; }
    }
}