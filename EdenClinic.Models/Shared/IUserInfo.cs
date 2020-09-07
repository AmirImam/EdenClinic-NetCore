using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Models
{
    public interface IUserInfo
    {
        string FullName { get; set; }
        bool IsActive { get; set; }

        Guid? RoleID { get; set; }
        SystemRole Role { get; set; }
    }
}
