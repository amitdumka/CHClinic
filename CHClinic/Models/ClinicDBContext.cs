using CHClinic.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHClinic.Models
{
    public class ClinicDBContext : DbContext
    {
        public ClinicDBContext() : base("CHClinicDatabase")
        {

        }

        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<PrescribedMed> PrescribedMeds { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<PhyicalExamination> PhyicalExaminations { get; set; }
        public DbSet<Generalities> Generalities { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<AuthUserInfo> AuthUserInfos { get; set; }

    }
}