using Blazored.LocalStorage;
using Blazored.SessionStorage;
using EdenClinic.Extensions;
using EdenClinic.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using StringEncryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Helpers
{
    public class SharedTools
    {
        public const string StorageEncryptionKey = "PERSON-EDEN";
        public SharedTools(IMatToaster toast,
            ILocalStorageService localStorage,
            ISessionStorageService sessionStorage,
            NavigationManager uriHelper,
            SessionManager session)
        {
            Toast = toast;
            LocalStorage = localStorage;
            SessionStorage = sessionStorage;
            UriHelper = uriHelper;
            Session = session;
        }

        public IMatToaster Toast { get; }
        public ILocalStorageService LocalStorage { get; }
        public ISessionStorageService SessionStorage { get; }
        public NavigationManager UriHelper { get; }
        public SessionManager Session { get; }

        public async Task OnLogged(Person person)
        {
            switch (person.PersonState)
            {
                case UserStates.Pending:
                    Toast.Add("NotApproved", MatToastType.Warning);
                    return;
                case UserStates.Blocked:
                    Toast.Add("NotAuthorized", MatToastType.Warning);
                    return;
                default:
                    break;
            }

            Session.Me = person;
            var json = person.ToJsonString().Encrypt(StorageEncryptionKey);
            await LocalStorage.SetItemAsync("locref", json);
            await SessionStorage.SetItemAsync("sesref", json);
            Session.UpdateMainLayout();
        }
    }
}
