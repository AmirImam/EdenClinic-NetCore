using Blazored.LocalStorage;
using Blazored.SessionStorage;
using EdenClinic.Service;
using EdenClinic.WebUI.Helpers;
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
        protected void Busy(bool state)
        {
            Session.IsBusy = state;
            Session.UpdateMainLayout();
        }
    }
}
