using Blazored.Modal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Helpers
{
    public class AlertModalResult : ModalResult
    {
        public AlertModalResult(bool data)
            : base(data, typeof(bool), data)
        {
            Result = data;
        }

        public bool Result { get; set; }
    }
}
