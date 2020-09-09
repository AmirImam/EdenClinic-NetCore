using EdenClinic.Extensions;
using EdenClinic.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Pages.Centers
{
    public partial class AdminsForm
    {
        [Parameter]
        public Guid CenterID { get; set; }
      
        private Person Model = new Person() { Gander = Ganders.Female };
        private Center center = new Center();
        protected override async void OnAfterRender(bool firstRender)
        {
            if(firstRender == true)
            {
                center = await ClientService.Centers
                    .FirstAsync(it => it.CenterID == CenterID);
                StateHasChanged();
            }
        }
        private int GanderBind
        {
            set => Model.Gander = (Ganders)value;
            get => (int)Model.Gander;
        }
        private async void Submit()
        {
            SystemRole role = new SystemRole()
            {
                IsAdmin = true,
                IsSystemAdmin=false,
                RoleName = $"{center.CenterName} Admins"
            };
            Busy(true);
            var roleResult = await ClientService.SystemRoles.InsertEntityAsync(role);
            if(roleResult.Success == true)
            {
                Model.CenterID = CenterID;
                Model.UserPassword = "123456";
                Model.RoleID = roleResult.Model.RoleID;
                
                var result = await ClientService.Persons.InsertEntityAsync(Model);
                if(result.Success == true)
                {
                    UriHelper.NavigateTo("/centers/admins");
                }
                else
                {
                    Console.WriteLine(result.Exception.ToJsonString());
                }
            }
            Busy(false);
        }

    }
}
