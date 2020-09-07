﻿using EdenClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenClinic.WebUI.Pages.Centers
{
    public partial class CentersIndex
    {
        List<Center> DataList = new List<Center>();
        protected override async void OnAfterRender(bool firstRender)
        {
            if(firstRender == true)
            {
                DataList = (await ClientService.Centers.ResultAsync()).ToList();
                StateHasChanged();
            }
        }
    }
}
