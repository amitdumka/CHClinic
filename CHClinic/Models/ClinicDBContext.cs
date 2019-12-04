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
        public ClinicDBContext() : base("name=MyDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOptional(s => s.PatComplaint) // Mark Address property optional in Student entity
                .WithRequired(ad => ad.Person)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Person>()
                .HasOptional(s => s.PatGeneralities) // Mark Address property optional in Student entity
                .WithRequired(ad => ad.Person)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Person>()
                .HasOptional(s => s.PatHistory) // Mark Address property optional in Student entity
                .WithRequired(ad => ad.Person)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Person>()
                .HasOptional(s => s.Examination) // Mark Address property optional in Student entity
                .WithRequired(ad => ad.Person)
                .WillCascadeOnDelete(true);
        }
        //    // Configure Code First to ignore PluralizingTableName convention
        //    // If you keep this convention then the generated tables will have pluralized names.
        //    //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    //modelBuilder.Entity<History>()
        //    //    .HasKey(t => t.PersonId);

        //    //modelBuilder.Entity<PhyicalExamination>()
        //    //  .HasKey(t => t.PersonId);

        //    //modelBuilder.Entity<Complaint>()
        //    //  .HasKey(t => t.PersonId);

        //    //modelBuilder.Entity<Generalities>()
        //    //  .HasKey(t => t.PersonId);

        //    //modelBuilder.Entity<Person>()
        //    //    .HasOptional(a => a.Complaint)
        //    //    .WithRequired(a=>a.Person)
        //    //    .WillCascadeOnDelete(true);

        //    //modelBuilder.Entity<Person>()
        //    //    .HasOptional(a => a.History)
        //    //    .WithRequired(a => a.Person)
        //    //    .WillCascadeOnDelete(true);

        //    //modelBuilder.Entity<Person>()
        //    //                .HasOptional(a => a.Examination)
        //    //                .WithRequired(a => a.Person)
        //    //                .WillCascadeOnDelete(true);
        //    //modelBuilder.Entity<Person>()
        //    //                .HasOptional(a => a.Generalities)
        //    //               .WithRequired(a => a.Person)
        //    //                .WillCascadeOnDelete(true);

        //    //modelBuilder.Entity<Person>()
        //    //               .HasOptional(a => a.Generalities)
        //    //               .WithOptionalDependent()
        //    //               .WillCascadeOnDelete(true);

        //    //modelBuilder.Entity<History>()
        //    //    .HasRequired(t => t.Person)       
        //    //    .WithRequiredPrincipal(t => t.History)       
        //    //    .WillCascadeOnDelete(true);
        //    //modelBuilder.Entity<Generalities>()
        //    //   .HasRequired(t => t.Person)
        //    //   .WithRequiredPrincipal(t => t.Generalities)
        //    //   .WillCascadeOnDelete(true);
        //    //modelBuilder.Entity<Complaint>()
        //    //   .HasRequired(t => t.Person)
        //    //   .WithRequiredPrincipal(t => t.Complaint)
        //    //   .WillCascadeOnDelete(true);
        //    //modelBuilder.Entity<PhyicalExamination>()
        //    //   .HasRequired(t => t.Person)
        //    //   .WithOptionalDependent(t => t.Examination)
        //    //   .WillCascadeOnDelete(true);

        //}

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

        //Version 2
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<DueList> DueLists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


    }
}