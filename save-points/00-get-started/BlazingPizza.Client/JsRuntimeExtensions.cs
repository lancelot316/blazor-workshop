using Microsoft.JSInterop;

namespace BlazingPizza.Client
{
    public static class JsRuntimeExtensions
    {
        public static ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message)
        {
            return jsRuntime.InvokeAsync<bool>("confirm", message);
        }
    }
}
