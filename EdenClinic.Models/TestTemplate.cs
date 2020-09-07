namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(TestTemplate))]
    public partial class TestTemplate : EdenClinic.Models.BaseModel
    {
        
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TestTemplateID { get; set; }

        [StringLength(100)]
        public string TestName { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        public ICollection<MedicalTest> MedicalTests { get; set; }
        public ICollection<TestTemplateDetail> TestTemplateDetails { get; set; }
    }
}
