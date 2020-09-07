namespace EdenClinic.Models
{
    using EdenClinic.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table(nameof(DoctorSetting))]
    public partial class DoctorSetting
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DoctorSettingID { get; set; }


        public bool? PrintingDescription { get; set; }
        public byte? DetectingInfoStartup { get; set; }

        public Guid? DoctorID { get; set; }
        [ForeignKey("DoctorID")]
        public Person Doctor { get; set; }
    }
}
