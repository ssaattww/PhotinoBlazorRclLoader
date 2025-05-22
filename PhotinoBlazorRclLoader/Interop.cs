using Microsoft.JSInterop;

public static class Interop
{
    public static void SetTitle(IJSRuntime jsRuntime, string title)
    {
        jsRuntime.InvokeVoidAsync("setPhotinoTitle", title);
    }
}
