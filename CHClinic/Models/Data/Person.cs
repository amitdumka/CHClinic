using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CHClinic.Models.Data
{
    public enum Genders { Male, Female, Transgender }
    enum BloodGroups { Ap, Bp, Op, An, Bn, On, ABp, ABn }
    public class Person
    {
        public Person()
        {
            Visits = new HashSet<Visit>();
           
            // PrescribedMeds = new HashSet<PrescribedMed>();
            // Invoices = new HashSet<Invoice>();
            // Histories = new HashSet<History>();
            // Complaints = new HashSet<Complaint>();
            // PhyicalExaminations = new HashSet<PhyicalExamination>();
            // Generalities = new HashSet<Generalities>();
        }

        public int PersonId { get; set; }

        public string OPDRegistrationID { get; set; }

        public DateTime? DateofRecord { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }

        public Genders Gender { get; set; }
        public int Age { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "MobileNo is required.")]
        public string MobileNo { get; set; }

        public string Occupation { get; set; }
        public string Religion { get; set; }

        public virtual History History { get; set; }
        public virtual Complaint Complaint { get; set; }
        public virtual PhyicalExamination Examination { get; set; }
        public virtual Generalities Generalities { get; set; }
        
        public virtual ICollection<Visit> Visits { get; set; }
        
        //  [Timestamp]
        // public Byte[] TimeStamp { get; set; }


        //  public virtual ICollection<PrescribedMed> PrescribedMeds { get; set; }
        // public virtual ICollection<Invoice> Invoices { get; set; }

        //public virtual ICollection<History> Histories { get; set; }
        //public virtual ICollection<Complaint> Complaints { get; set; }
        //public virtual ICollection<PhyicalExamination> PhyicalExaminations { get; set; }
        //public virtual ICollection<Generalities> Generalities { get; set; }


    }

    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }

    // First Visit of Person
    public class BloodGroup
    {
        public int BloodGroupId { get; set; }
        public string Blood { get; set; }
        public string RH { get; set; }
    }
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

    // Regular Visit

    public class Visit
    {
        public Visit()
        {
            this.PrescribedMeds = new HashSet<PrescribedMed>();
            this.Invoices = new HashSet<Invoice>();
        }

        public int VisitId { get; set; }
        public int PersonId { get; set; }

        public DateTime? VisitDate { get; set; }
        public int VisitNo { get; set; }
        public int Revisit { get; set; }
        public DateTime? NextVisit { get; set; }
        public string Problems { get; set; }
        public int Billable { get; set; }
        public int VisitBillable { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<PrescribedMed> PrescribedMeds { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }


    }
    public class PrescribedMed
    {
        public int PrescribedMedId { get; set; }
        //   public int PersonId { get; set; }
        public int VisitID { get; set; }

        public string MedicineName { get; set; }
        public string Description { get; set; }
        public string Power { get; set; }
        public string NoOfTime { get; set; }
        public string Quantity { get; set; }
        public float Cost { get; set; }
        public string Remarks { get; set; }

        public virtual Person Person { get; set; }
        public virtual Visit Visit { get; set; }
    }

    public class Invoice
    {
        public int InvoiceId { get; set; }
        // public int PersonId { get; set; }
        public int VisitId { get; set; }

        public float VisitCharge { get; set; }
        public float MedCharge { get; set; }
        public float OtherCharges { get; set; }
        public float Paid { get; set; }
        public float Dues { get; set; }
        public string Remarks { get; set; }

        public virtual Person Person { get; set; }
        public virtual Visit Visit { get; set; }

    }


}