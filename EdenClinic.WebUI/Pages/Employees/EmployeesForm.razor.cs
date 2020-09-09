using EdenClinic.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Pages.Employees
{
    public partial class EmployeesForm
    {
        [Parameter]
        public Guid? Id { get; set; }
        private Person Model = new Person();
        private async void Submit()
        {

        }
    }
}
