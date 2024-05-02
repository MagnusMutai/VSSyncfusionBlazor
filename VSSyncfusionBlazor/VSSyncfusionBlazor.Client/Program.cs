﻿using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.JSInterop;
using VSSyncfusionBlazor.Client;

//Register Syncfusion license https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzI1Mjc1MkAzMjM1MmUzMDJlMzBWZ2N4R2RuSmpNM2tyN21zUU1DYjFiandjL29VdW9KakxWbGRKcllLSzJJPQ==");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();
            builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

            // Set the default culture of the application
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

                        // Get the modified culture from culture switcher
                        var host = builder.Build();
                        var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
                        var result = await jsInterop.InvokeAsync<string>("cultureInfo.get");
                        if (result != null)
                        {
                            // Set the culture from culture switcher
                            var culture = new CultureInfo(result);
                            CultureInfo.DefaultThreadCurrentCulture = culture;
                            CultureInfo.DefaultThreadCurrentUICulture = culture;
                        }
await builder.Build().RunAsync();
