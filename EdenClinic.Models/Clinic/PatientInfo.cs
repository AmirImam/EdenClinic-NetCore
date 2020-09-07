namespace EdenClinic.Models
{
    using Eden.Accounting.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(PatientInfo))]
    public partial class PatientInfo : BaseModel
    {
       
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PatientInfoID { get; set; }

        public Guid? PersonID { get; set; }
        public Person Person { get; set; }
       
        [StringLength(50)]
        public string Job { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Patient ID is required")]
        public string PatientIdCard { get; set; }

        public double? PatientHeight { get; set; }

        public double? PatientWight { get; set; }

        [StringLength(100)]
        public string PatientJob { get; set; }

        public short? PaitentKidsCount { get; set; }

        //public double? PatientSalary { get; set; }

        public bool? HasCar { get; set; }

        [StringLength(350)]
        public string PatientHobbys { get; set; }

        //public Guid? AccountID { get; set; }
       
    }
}
