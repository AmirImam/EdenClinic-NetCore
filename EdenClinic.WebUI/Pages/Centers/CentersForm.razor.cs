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

            if (firstRender == true)
            {
                if (Session.Me.Role.IsSystemAdmin == false)
                {
                    UriHelper.NavigateTo("/");
                }
                if (Id != null)
                {
                    Busy(true);
                    Model = await ClientService.Centers
                        .FirstAsync(it => it.CenterID == Id);
                    StateHasChanged();
                    Busy(false);
                }
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
            var msg = await Alert("DeleteItem", "AreYouSure", AlertButtons.OkCancel);
            if(msg == true)
            {
                Busy(true);
                var result = await ClientService.Centers.DeleteEntityAsync(Id.Value);
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
        }
    }
}
