// Copyright (c) 2025 ssaattww. All rights reserved.
// Licensed under the MIT License.

using Microsoft.JSInterop;

public static class Interop
{
    public static void SetTitle(IJSRuntime jsRuntime, string title)
    {
        jsRuntime.InvokeVoidAsync("setPhotinoTitle", title);
    }
}
