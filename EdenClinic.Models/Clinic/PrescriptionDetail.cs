namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(PrescriptionDetail))]
    public partial class PrescriptionDetail : EdenClinic.Models.BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PrescriptionDetailID { get; set; }

        public Guid? PrescriptionID { get; set; }
        public Prescription Prescription { get; set; }
        public Guid? DrugID { get; set; }
        public Drug Drug { get; set; }
        public double? Dosage { get; set; }

        public byte? Count { get; set; }

        public byte? DaysCount { get; set; }

        public Guid? DiseaseID { get; set; }
        public Disease Disease { get; set; }
        public Guid? TreatmentID { get; set; }
        public Treatment Treatment { get; set; }
    }
}
