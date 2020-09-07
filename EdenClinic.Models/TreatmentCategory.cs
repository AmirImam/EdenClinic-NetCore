namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table(nameof(TreatmentCategory))]
    public partial class TreatmentCategory : EdenClinic.Models.BaseModel
    {
       [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TreatmentCategoryID { get; set; }

        [StringLength(50)]
        public string TreatmentCategoryName { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Treatment> Treatments { get; set; }
    }
}
