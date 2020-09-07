namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(Disease))]
    public partial class Disease : EdenClinic.Models.BaseModel
    {
       
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DiseaseID { get; set; }

        [StringLength(50)]
        public string DiseaseName { get; set; }

        [StringLength(50)]
        public string DiseaseCode { get; set; }

        public byte? DiseaseDanger { get; set; }

        public Guid? ClinicID { get; set; }
        public Clinic Clinic { get; set; }

        public Guid? DiseaseCategoryID { get; set; }
        public DiseaseCategory DiseasesCategory { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
    }
}
