using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EdenClinic.Service;
using EdenClinic.WebUI.Helpers;
using MatBlazor;
using Blazored.SessionStorage;
using Blazored.LocalStorage;
using AKSoftware.Localization.MultiLanguages;
using System.Reflection;
using System.Globalization;
using Blazored.Modal;

namespace EdenClinic.WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            ODataConfiguration.WebServiceUrl = builder.Configuration["ServerUrl"];
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            Simple.OData.Client.V4Adapter.Reference();
            builder.Services.AddScoped<ServiceContext>();
            builder.Services.AddScoped<SessionManager>();
            builder.Services.AddScoped<SharedTools>();

            builder.Services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredModal();
            //builder.Services.AddLanguageContainer(Assembly.GetExecutingAssembly(), folderName: "Resources");
            await builder.Build().RunAsync();
        }
    }
}
