namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(Treatment))]
    public partial class Treatment : EdenClinic.Models.BaseModel
    {
     
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TreatmentID { get; set; }

        public Guid? TreatmentCategoryID { get; set; } 
        public TreatmentCategory TreatmentCategory { get; set; }

        [StringLength(20)]
        public string TreatmentName { get; set; }

        public double? TreatmentPrice { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }

       
    }
}
