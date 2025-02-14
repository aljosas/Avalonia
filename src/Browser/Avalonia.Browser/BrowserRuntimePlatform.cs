using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;
using Avalonia.Browser.Interop;
using Avalonia.Platform;

namespace Avalonia.Browser;

internal class BrowserRuntimePlatform : StandardRuntimePlatform
{
    private static readonly Lazy<RuntimePlatformInfo> Info = new(() =>
    {
        var result = new RuntimePlatformInfo
        {
            IsCoreClr = true, // WASM browser is always CoreCLR
            IsBrowser = true, // BrowserRuntimePlatform only runs on Browser.
            OperatingSystem = OperatingSystemType.Browser,
            IsMobile = AvaloniaModule.IsMobile()
        };
        
        return result;
    });

    public override RuntimePlatformInfo GetRuntimeInfo() => Info.Value;
}
