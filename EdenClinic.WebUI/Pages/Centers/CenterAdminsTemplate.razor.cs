using EdenClinic.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Pages.Centers
{
    public partial class CenterAdminsTemplate
    {
        [Parameter]
        public Guid CenterID { get; set; }
        List<Person> AdminsList = new List<Person>();
        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender == true)
            {
                AdminsList = (await ClientService
                    .Persons
                    .Include(it => it.Role)
                    .Where(it => it.CenterID == CenterID && it.Role.IsAdmin == true)
                    .ResultAsync()).ToList();
                StateHasChanged();
            }
        }


        private async void SwitchPersonState(Guid id,UserStates state)
        {
            Busy(true);
            var origin = await ClientService.Persons
                .FirstAsync(it => it.PersonID == id);
            origin.PersonState = state;
            await ClientService.Persons.UpdateEntityAsync(id, origin);
            AdminsList.First(it => it.PersonID == id).PersonState = state;


            Busy(false);
            StateHasChanged();
        }
    }
}
