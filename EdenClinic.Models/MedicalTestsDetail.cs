namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(MedicalTestsDetail))]
    public partial class MedicalTestsDetail : BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MedicalTestDetailID { get; set; }

        public Guid? MedicalTestID { get; set; }
        public MedicalTest MedicalTest { get; set; }

        public Guid? TestTemplateDetailID { get; set; }
        public TestTemplateDetail TestTemplateDetail { get; set; }
        [StringLength(10)]
        public string TestValue { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }




    }
}
