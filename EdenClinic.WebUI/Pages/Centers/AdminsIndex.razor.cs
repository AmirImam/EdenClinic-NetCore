using EdenClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Pages.Centers
{
    public partial class AdminsIndex
    {
        List<Center> CentersList = new List<Center>();
        Dictionary<Guid?, List<Person>> DataList = new Dictionary<Guid?, List<Person>>();
        protected override async void OnAfterRender(bool firstRender)
        {
            if(firstRender == true)
            {
                if(Session.Me.Role.IsSystemAdmin == false)
                {
                    UriHelper.NavigateTo("/");
                }
                Busy(true);
                CentersList = (await ClientService.Centers.ResultAsync()).ToList();

                //var list = await ClientService
                //    .Persons
                //    .Include(it=>new { it.Role,it.Center })
                //    .Where(it => it.Role.IsAdmin == true)
                //    .ResultAsync();

                //DataList = list.GroupBy(k => k.CenterID)
                //    .ToDictionary(k => k.Key, v => v.ToList());
                StateHasChanged();
                Busy(false);
            }
        }
    }
}
