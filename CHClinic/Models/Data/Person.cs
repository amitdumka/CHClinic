using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHClinic.Models.Data
{
    public enum Genders { Male, Female, Transgender }

    public class Person
    {
        public Person()
        {
            Visits = new HashSet<Visit>();
            //  PrescribedMeds = new HashSet<PrescribedMed>();
            // Invoices = new HashSet<Invoice>();
            Histories = new HashSet<History>();
            Complaints = new HashSet<Complaint>();
            PhyicalExaminations = new HashSet<PhyicalExamination>();
            Generalities = new HashSet<Generalities>();
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

      //  [Timestamp]
       // public Byte[] TimeStamp { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
        //  public virtual ICollection<PrescribedMed> PrescribedMeds { get; set; }
        // public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
        public virtual ICollection<PhyicalExamination> PhyicalExaminations { get; set; }
        public virtual ICollection<Generalities> Generalities { get; set; }


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


}