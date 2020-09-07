using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Models
{
    [Table(nameof(Role))]
    public class Role
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<RolePage> RolePages { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
