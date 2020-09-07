namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(MedicalHistoryCaption))]
    public partial class MedicalHistoryCaption : EdenClinic.Models.BaseModel
    {
       
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CaptionID { get; set; }

        [StringLength(250)]
        public string CaptionDescription { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<MedicalHistory> MedicalHistories { get; set; }
    }
}
