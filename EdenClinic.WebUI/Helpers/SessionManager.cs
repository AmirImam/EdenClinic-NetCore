using EdenClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Helpers
{
    public class SessionManager
    {
        public Person Me { get; set; }
        public bool IsBusy { get; set; }
        public Action UpdateMainLayout { get; set; }
    }
}
