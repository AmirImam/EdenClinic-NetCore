namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table(nameof(PatientMedicalHistory))]
    public partial class PatientMedicalHistory : EdenClinic.Models.BaseModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PatientMedicalHistoryID { get; set; }
    
        public Guid? PatientID { get; set; }
        public Person Patient { get; set; }

        public Guid? MedicalHistoryID { get; set; }
        public MedicalHistory MedicalHistory { get; set; }

        public bool? IsYes { get; set; }

        [StringLength(100)]
        public string YesDescription { get; set; }

       

       
    }
}
