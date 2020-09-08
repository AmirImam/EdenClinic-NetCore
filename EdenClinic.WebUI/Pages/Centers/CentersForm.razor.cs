using EdenClinic.Models;
using EdenClinic.Service;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Pages.Centers
{
    public partial class CentersForm
    {
        [Parameter]
        public Guid? Id { get; set; }
        private Center Model = new Center();
        protected override async void OnAfterRender(bool firstRender)
        {
            if (Id != null)
            {
                Model = await ClientService.Centers
                    .FirstAsync(it => it.CenterID == Id);
                StateHasChanged();
            }
        }
        private async void Submit()
        {
            ResponseResult<Center> result = new ResponseResult<Center>();
            Busy(true);
            if(Id == null)
            {
                result = await ClientService.Centers.InsertEntityAsync(Model);
            }
            else
            {
                result = await ClientService.Centers.UpdateEntityAsync(Id.Value, Model);
            }
            Busy(false);
            if(result.Success == true)
            {
                UriHelper.NavigateTo("/centers");
            }
            else
            {
                Toast.Add(result.Message, MatBlazor.MatToastType.Danger);
            }
        }

        private async void DeleteItem()
        {
            var result = await Alert("AreYouSure", "DeleteItem", AlertButtons.OkCancel);
        }
    }
}
