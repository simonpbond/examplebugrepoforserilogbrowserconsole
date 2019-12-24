using Microsoft.JSInterop;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmBugRepo.Client.Services
{
    public class SessionStorageService
    {
        private readonly IJSRuntime _jSRuntime;
        
        public SessionStorageService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }
            
        public async Task SetSessionStorage(string key, string value)
        {
            Log.Information("Setting SessionStorage with Key: {0} , and Value: {1}", key, value);
            await _jSRuntime.InvokeVoidAsync("SessionStorage.setSessionStorage", key, value);
        }

        public async Task<string> GetSessionStorage(string key)
        {
            var value = await _jSRuntime.InvokeAsync<string>("SessionStorage.getSessionStorage", key);
            Log.Information("Got SessionStorage with Key: {0} , and return Value: {1}", key, value ?? "NULL");
            return value;
        }

    }
}
