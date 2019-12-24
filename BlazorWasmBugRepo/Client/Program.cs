using Microsoft.AspNetCore.Blazor.Hosting;
using Serilog;
using Serilog.Core;
using System;

namespace BlazorWasmBugRepo.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Serilog.Debugging.SelfLog.Enable(m => Console.Error.WriteLine(m));

            var levelSwitch = new LoggingLevelSwitch() { MinimumLevel = Serilog.Events.LogEventLevel.Verbose };
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
                .WriteTo.BrowserConsole()
                .CreateLogger();

            //Log.Information("Hello, browser!");

            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
