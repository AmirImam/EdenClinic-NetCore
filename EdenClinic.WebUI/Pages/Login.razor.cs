using EdenClinic.Models;
using EdenClinic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Pages
{
    public partial class Login
    {
        protected override async void OnInitialized()
        {
            Busy(true);
            var result = await ClientService.Persons.CreateFirstAdmin();
            if (result.Success == true)
            {
                model.Email = result.Model.Email;
                model.Password = result.Model.UserPassword;
                StateHasChanged();
            }
            Busy(false);
        }

        UserLoginModel model = new UserLoginModel();
        private async void LoginSubmit()
        {
            Busy(true);
            var result = await ClientService.Persons.Login(model.Email, model.Password);
            
            Busy(false);
            if (result.Success == false)
            {
                Toast.Add("LoginFailed", MatBlazor.MatToastType.Danger);
            }
            else
            {
                await Tools.OnLogged(result.Model);
            }
        }
    }
}
