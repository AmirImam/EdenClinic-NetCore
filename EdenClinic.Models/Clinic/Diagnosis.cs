using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Models
{
    [Table(nameof(Diagnosis))]
    public class Diagnosis
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DiagnosisID { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisDescription { get; set; }

        public string CategoryCode { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
