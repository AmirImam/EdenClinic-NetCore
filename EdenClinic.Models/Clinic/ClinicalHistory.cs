namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table(nameof(ClinicalHistory))]
    public partial class ClinicalHistory : BaseModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClinicalHistoryID { get; set; }

        public Guid? ReservationID { get; set; }
        public Reservation Reservation { get; set; }
        public string Notes { get; set; }
    }
}
