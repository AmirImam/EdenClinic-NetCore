namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(MedicalTest))]
    public partial class MedicalTest : EdenClinic.Models.BaseModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MedicalTestID { get; set; }
        

        [StringLength(25)]
        public DateTime TestDate { get; set; }

        [StringLength(50)]
        public string LabName { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }


        public Guid? PatientID { get; set; }
        public Person Patient { get; set; }


        public Guid? TestTemplateID { get; set; }
        [ForeignKey("TestTemplateID")]
        public TestTemplate TestsTemplate { get; set; }

        

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<MedicalTestsDetail> MedicalTestsDetails { get; set; }
    }
}
