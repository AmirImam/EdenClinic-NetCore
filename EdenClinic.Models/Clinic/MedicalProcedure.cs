using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Models
{
    [Table(nameof(MedicalProcedure))]
    public class MedicalProcedure
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MedicalProcedureID { get; set; }
        public string MedicalProcedureDescription { get; set; }
        public double Price { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
