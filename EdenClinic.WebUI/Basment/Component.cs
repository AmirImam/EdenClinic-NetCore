using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.SessionStorage;
using EdenClinic.Service;
using EdenClinic.WebUI.Helpers;
using EdenClinic.WebUI.Shared;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Basment
{
    public class Component : ComponentBase
    {
        [Inject]
        public SessionManager Session { get; set; }
        [Inject]
        public ServiceContext ClientService { get; set; }
        [Inject]
        public IMatToaster Toast { get; set; }
        [Inject]
        public SharedTools Tools { get; set; }
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public ISessionStorageService SessionStorage { get; set; }
        [Inject]
        public NavigationManager UriHelper { get; set; }
        [Inject]
        public IModalService Popup { get; set; }
        //[Inject]
        //public ILanguageContainerService Localizer { get; set; }
        protected void Busy(bool state)
        {
            Session.IsBusy = state;
            Session.UpdateMainLayout();
        }

        public enum AlertButtons
        {
            Ok,
            OkCancel
        }
        protected async Task<bool?> Alert(string title, string message, AlertButtons buttons = AlertButtons.Ok)
        {
            ModalParameters parameters = new ModalParameters();
            parameters.Add("Buttons", buttons);
            parameters.Add("Message", message);
            var alert = Popup.Show<AlertPopup>(title, parameters);
            var result = await alert.Result;
            if (result.Data != null)
            {
                bool alertResult = (bool)result.Data;
                return alertResult;
            }
            return null;

        }
    }
}
