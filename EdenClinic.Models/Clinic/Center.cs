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
    [Table(nameof(Center))]
    public class Center
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CenterID { get; set; }
        public string CenterName { get; set; }
        public string CenterAddress { get; set; }
        public string CenterPhone { get; set; }


        public ICollection<Person> Persons { get; set; }
        public ICollection<Clinic> Clinics { get; set; }

    }
}
