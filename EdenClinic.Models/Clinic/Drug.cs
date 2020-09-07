namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(Drug))]
    public partial class Drug : EdenClinic.Models.BaseModel
    {
      
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DrugID { get; set; }

        [StringLength(50)]
        public string DrugName { get; set; }

        [StringLength(20)]
        public string DrugCode { get; set; }

        public double DrugPrice { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
    }
}
