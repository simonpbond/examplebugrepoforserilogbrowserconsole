using BlazorWasmBugRepo.Client.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Serilog;
using Serilog.Core;
using System;

namespace BlazorWasmBugRepo.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Serilog logging unavailable here.

            services.AddSingleton<SessionStorageService>();
    
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            
            Log.Information("Configure running.");

            app.AddComponent<App>("app");
        }
    }
}
