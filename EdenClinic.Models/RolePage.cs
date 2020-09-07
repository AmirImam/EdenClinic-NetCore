using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Models
{
    [Table(nameof(RolePage))]
    public class RolePage
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RolePageID { get; set; }

        public string PageName { get; set; }
        public Guid? RoleID { get; set; }
        public Role Role { get; set; }

        public bool CanAccess { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        
    }
}
