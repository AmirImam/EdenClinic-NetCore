namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(Prescription))]
    public partial class Prescription : EdenClinic.Models.BaseModel
    {
       
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PrescriptionID { get; set; }

        public Guid? ReservationID { get; set; }
        public Reservation Reservation { get; set; }

        public string Notes { get; set; }
       

        public Guid? DiagnosisID { get; set; }
        public Diagnosis Diagnosis { get; set; }

        public Guid? MedicalProcedureID { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }

        public string ChiefComplaint { get; set; }

        public ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
    }
}
