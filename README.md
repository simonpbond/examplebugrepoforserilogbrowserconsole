# Example project showing JsInterop bug when adding Serilog.Sinks.BrowserConsole  
On first run it will fail to retrieve session storage value.  
  
  If you comment out `.WriteTo.BrowserConsole()` in `Program.cs` it will begin to work.  
    
  The project uses the default Blazor WebAssembly (.NET Core hosted) template, with an extra service for handing the session storage, and add's the Serilog.Sinks.BrowserConsole package.
