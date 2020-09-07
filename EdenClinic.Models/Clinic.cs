namespace EdenClinic.Models
{
    using EdenClinic.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(Clinic))]
    public partial class Clinic : EdenClinic.Models.BaseModel
    {
       
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClinicID { get; set; }

        [Required]
        [StringLength(50)]
        public string ClinicName { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        

        [Required]
        public double ClinicPrice { get; set; }

        [Required]
        public Guid? SpecialistID { get; set; }
        [Display(Name = "Specialist")]
        public Specialist Specialist { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        
        public ICollection<Treasury> Treasuries { get; set; }
        public ICollection<Person> Persons { get; set; }
        public ICollection<Disease> Diseases { get; set; }

        public Guid? CenterID { get; set; }
        public Center Center { get; set; }
        
    }
}
