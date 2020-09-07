namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("DiseaseCategory")]
    public partial class DiseaseCategory : EdenClinic.Models.BaseModel
    {
       

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DiseaseCategoryID { get; set; }

        [StringLength(50)]
        public string DiseaseCategoryName { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Disease> Diseases { get; set; }
    }
}
