using CuentasClaras.Models;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace CuentasClaras.Services;

public class BrowserLocalStorageProvider : IStorageProvider
{
    private const string StorageKey = "cuentas_claras_mock_json";
    private readonly IJSRuntime _jsRuntime;

    public BrowserLocalStorageProvider(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<DocumentState> LoadStateAsync()
    {
        var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", StorageKey);
        
        if (string.IsNullOrWhiteSpace(json))
        {
            return new DocumentState(); // Return empty defaults
        }

        try
        {
            var state = JsonSerializer.Deserialize<DocumentState>(json);
            return state ?? new DocumentState();
        }
        catch
        {
            return new DocumentState();
        }
    }

    public async Task SaveStateAsync(DocumentState state)
    {
        var json = JsonSerializer.Serialize(state, new JsonSerializerOptions 
        { 
            WriteIndented = true 
        });
        
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
    }
}
