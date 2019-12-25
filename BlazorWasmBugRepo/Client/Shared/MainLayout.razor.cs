using BlazorWasmBugRepo.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmBugRepo.Client.Shared
{
    public partial class MainLayout
    {

        [Inject] 
        private SessionStorageService _sessionStorageService {get;set;}

        private readonly string _sessionStorageKey = "Authentication";
        private readonly string _sessionStorageValueSet = Guid.NewGuid().ToString();
        
        private string _sessionStorageValueGet;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Log.Information("Is first render");
                await _sessionStorageService.SetSessionStorage(_sessionStorageKey, _sessionStorageValueSet);
                _sessionStorageValueGet = await _sessionStorageService.GetSessionStorage(_sessionStorageKey);
                StateHasChanged();
            }
        

        }

    }
}
