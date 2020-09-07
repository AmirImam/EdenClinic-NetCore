using EdenClinic.Extensions;
using EdenClinic.Models;
using EdenClinic.Service;
using EdenClinic.WebUI.Helpers;
using StringEncryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Pages
{
    public partial class Login
    {
        UserLoginModel model = new UserLoginModel();
        bool rememberMe = false;
        protected override async void OnInitialized()
        {
            Busy(true);
            var result = await ClientService.Persons.CreateFirstAdmin();
            if (result.Success == true)
            {
                model.Email = result.Model.Email;
                model.Password = result.Model.UserPassword.Decrypt(result.Model.ApplicationUserID);
                StateHasChanged();
            }

            var locData = await LocalStorage.GetItemAsync<string>("locref");
            if (locData != null)
            {
                string json = locData.Decrypt(SharedTools.StorageEncryptionKey);
                Person person = json.ToJsonObject<Person>();
                model.Email = person.Email;
                model.Password = person.UserPassword.Decrypt(person.ApplicationUserID);
                StateHasChanged();
            }
            Busy(false);
        }

        
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
                await Tools.OnLogged(result.Model,rememberMe);
            }
        }
    }
}
