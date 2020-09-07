//using Eden.Accounting.Models.Abstract;
using EdenClinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Models
{
    [Table(nameof(Person))]
    public class Person : BasicDataModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PersonID { get; set; }

        public string ApplicationUserID { get; set; }

        [StringLength(50)]
        [Required]
        public string PersonName { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string PersonAddress { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        public Guid? RoleID { get; set; }
        public SystemRole Role { get; set; }

        public DateTime BirthDate { get; set; }
        public string StrBirthdate { get; set; }

        public UserStates PersonState { get; set; }
        public UserJob? PersonJob { get; set; }

        public Ganders Gander { get; set; }

        public Guid? ClinicID { get; set; }
        public Clinic Clinic { get; set; }
        
      

        public Guid? CenterID { get; set; }
        public Center Center { get; set; }


        public bool IsPatient { get; set; }
        public PatientInfo PatientInfo { get; set; }

        //[NotMapped]
        public string UserPassword { get; set; }

        public ICollection<DoctorSetting> DoctorSetting { get; set; }
        public ICollection<Remark> Remarks { get; set; }
        public ICollection<Reservation> DoctorReservations { get; set; }
        public ICollection<Reservation> PatientReservations { get; set; }

        public ICollection<WorkingSheet> WorkingSheets { get; set; }

        public ICollection<MedicalTest> PatientMedicalTests { get; set; }
        public ICollection<PatientMedicalHistory> PatientMedicalHistory { get; set; }
        

        public string AccessToken { get; set; }
    }
}
