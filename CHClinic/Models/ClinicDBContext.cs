using CHClinic.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHClinic.Models
{
    public class ClinicDBContext:DbContext
    {
        public ClinicDBContext() : base("CHClinicDatabase")
        {

        }

        DbSet<BloodGroup>BloodGroups { get; set; }
        DbSet<History>Histories { get; set; }
        DbSet<Person>People { get; set; }
        DbSet<Visit>Visits { get; set; }
        DbSet<PrescribedMed>PrescribedMeds { get; set; }
        DbSet<Invoice>Invoices { get; set; }
        DbSet<Complaint>Complaints { get; set; }
        DbSet<PhyicalExamination>PhyicalExaminations { get; set; }
        DbSet<Generalities>Generalities { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Country>Countries { get; set; }
        DbSet<State> States { get; set; }
        DbSet<AuthUser>AuthUsers { get; set; }
        DbSet<AuthUserInfo>AuthUserInfos { get; set; }


    }
}