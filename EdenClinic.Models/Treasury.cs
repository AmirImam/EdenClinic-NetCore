namespace EdenClinic.Models
{
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(Treasury))]
    public partial class Treasury : EdenClinic.Models.BaseModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TreasuryID { get; set; }

        public double? Amount { get; set; }

        public Guid? ClinicID { get; set; }
        public Clinic Clinic { get; set; }
        
        public DateTime ActionDate { get; set; }

        public Guid? PersonID { get; set; }
        public Person Person { get; set; }

        [StringLength(50)]
        public string ActionDescription { get; set; }

       
    }
}
