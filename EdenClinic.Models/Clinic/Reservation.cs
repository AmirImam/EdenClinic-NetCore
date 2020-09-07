namespace EdenClinic.Models
{
    using EdenClinic.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(Reservation))]
    public partial class Reservation : EdenClinic.Models.BaseModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReservationID { get; set; }
        
        public DateTime ReservationDate { get; set; }
        //[NotMapped]
        public string StrReservationDate { get; set; }
      
        public bool IsConsulting { get; set; }
        
        public PatientDetectingState PatientDetectingState { get; set; }

        public string Notes { get; set; }

   
        public Guid? ClinicID { get; set; }
        public Clinic Clinic { get; set; }

        public Guid PatientID { get; set; }
        public Person Patient { get; set; }


        public Guid? DoctorID { get; set; }
        [ForeignKey("DoctorID")]
        public Person Doctor { get; set; }

       
       
        public Guid? SpecialistID { get; set; }
        public Specialist Specialist { get; set; }

        public double Price { get; set; }
        public double DiscountRatio { get; set; }
        public double DiscountValue { get; set; }
        public double Vat { get; set; }
        public double Net { get; set; }

        public double Paied { get; set; }
        public double Rest { get; set; }
        //public int? EntryID { get; set; }
        //public Accounting.Models.JournalEntries JournalEntries { get; set; }

        // public ICollection<Chart> Charts { get; set; }

        public ICollection<ClinicalHistory> ClinicalHistories { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }

    }
}
