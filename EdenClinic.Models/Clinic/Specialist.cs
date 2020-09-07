namespace EdenClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(Specialist))]
    public partial class Specialist : EdenClinic.Models.BaseModel
    {
      
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SpecialistID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="Specialist Name is required")]
        public string SpecialistName { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Clinic> Clinics { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
