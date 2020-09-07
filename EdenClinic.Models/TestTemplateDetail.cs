namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(TestTemplateDetail))]
    public partial class TestTemplateDetail : EdenClinic.Models.BaseModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TestTemplateDetailID { get; set; }

        public Guid? TestTemplateID { get; set; }
        public TestTemplate TestsTemplate { get; set; }

        [StringLength(20)]
        public string TestItemName { get; set; }

        [StringLength(20)]
        public string TestItemNormal { get; set; }

        [StringLength(10)]
        public string TestItemUnit { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<MedicalTestsDetail> MedicalTestsDetails { get; set; }

    }
}
