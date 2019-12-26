using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.JSInterop;
using Serilog;
using Serilog.Core;
using System;

namespace BlazorWasmBugRepo.Client
{
    public class Program
    {

        public static void Main(string[] args)
        {

            IWebAssemblyHost webAssemblyHost = CreateHostBuilder(args).Build();
            var jsRuntime = (IJSRuntime)webAssemblyHost.Services.GetService(typeof(IJSRuntime));

            Serilog.Debugging.SelfLog.Enable(m => Console.Error.WriteLine(m));

            var levelSwitch = new LoggingLevelSwitch() { MinimumLevel = Serilog.Events.LogEventLevel.Verbose };
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
                .WriteTo.BrowserConsole(jsRuntime)
                .CreateLogger();

            Log.Information("Hello, browser!");

            webAssemblyHost.Run();

        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();

    }
}
