namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table(nameof(MedicalHistory))]
    public partial class MedicalHistory : EdenClinic.Models.BaseModel
    {
        
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MedicalHistoryID { get; set; }

        [StringLength(100)]
        public string MedicalDescription { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public Guid? CaptionID { get; set; }
        public MedicalHistoryCaption MedicalHistoryCaptions { get; set; }
        public ICollection<PatientMedicalHistory> PatientMedicalHistories { get; set; }
    }
}
