
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            builder.Entity<Person>().Ignore(it => it.AccessToken);
            builder.Entity<Reservation>()
                 .HasOne(it => it.Doctor)
                 .WithMany(it => it.DoctorReservations)
                 .HasForeignKey(it => it.DoctorID);
            builder.Entity<Reservation>()
                 .HasOne(it => it.Patient)
                 .WithMany(it => it.PatientReservations)
                 .HasForeignKey(it => it.PatientID);
            base.OnModelCreating(builder);
        }

        //public DbSet<Accounts> Accounts { get; set; }
        //public DbSet<Allowances> Allowances { get; set; }
        //public DbSet<Assets> Assets { get; set; }
        //public DbSet<AssetsSales> AssetsSales { get; set; }
        //public DbSet<Banks> Banks { get; set; }
        //public DbSet<CostCenters> CostCenters { get; set; }
        //public DbSet<Employees> Employees { get; set; }
        //public DbSet<Expenses> Expenses { get; set; }
        //public DbSet<ExpensesActions> ExpensesActions { get; set; }
        //public DbSet<FinancialPapers> FinancialPapers { get; set; }
        //public DbSet<JournalEntries> JournalEntries { get; set; }
        //public DbSet<JournalEntryDetails> JournalEntryDetails { get; set; }
        //public DbSet<PatientContacts> PatientContacts { get; set; }
        //public DbSet<SalariesPaymentDetails> SalariesPaymentDetails { get; set; }
        //public DbSet<SalariesPayments> SalariesPayments { get; set; }
        //public DbSet<SalaryAllowances> SalaryAllowances { get; set; }
        //public DbSet<SupplierContacts> SupplierContacts { get; set; }
        //public DbSet<Supplier> Suppliers { get; set; }
        //public DbSet<Box> Boxes { get; set; }
        //public DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        //public DbSet<ABCXYZ> ABCXYZ { get; set; }
        //public DbSet<DiseasesCategory> DiseasesCategory { get; set; }
        //public DbSet<SystemUser> Users { get; set; }
        //public DbSet<Chart> Charts { get; set; }
        //public DbSet<TagObject> TagObjects { get; set; }
        //public DbSet<ToothInfo> ToothInfos { get; set; }

        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<PatientInfo> PatientInfoes { get; set; }
     
        public DbSet<SystemRole> DbRoles { get; set; }
        public DbSet<RolePage> RolePages { get; set; }

      public DbSet<WorkingSheet> WorkingSheets { get; set; }
        public DbSet<TestTemplate> TestTemplates { get; set; }
        public DbSet<ClinicalHistory> ClinicalHistories { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        
        public DbSet<DoctorSetting> DoctorSettings { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<MedicalHistoryCaption> MedicalHistoryCaptions { get; set; }
        public DbSet<MedicalTest> MedicalTests { get; set; }
        public DbSet<MedicalTestsDetail> MedicalTestsDetails { get; set; }
        public DbSet<PatientMedicalHistory> PatientMedicalHistories { get; set; }

        public DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Remark> Remarks { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<DiseaseCategory> DiseaseCategories { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<SystemAction> SystemActions { get; set; }
        public DbSet<TestTemplate> TestsTemplates { get; set; }
        public DbSet<TestTemplateDetail> TestTemplateDetails { get; set; }
        public DbSet<Treasury> Treasuries { get; set; }
        public DbSet<TreatmentCategory>  TreatmentCategories { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        
        public DbSet<WorkingSheet> WorkingSheet { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Center> Centers { get; set; }


        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<MedicalProcedure> MedicalProcedures { get; set; }

      
        
    }
}
