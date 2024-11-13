﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using VillageApp.Data;
using VillageApp.Services;
using VillageApp.ViewModels;
using VillageApp.Views;
using System.Reflection;

namespace VillageApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        builder.Register();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static MauiAppBuilder Register(this MauiAppBuilder mauiAppBuilder)
    {
        IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (Type type in types.Where(c => c.Name.EndsWith("ViewModel") || c.Name.EndsWith("Page")))
        {
            mauiAppBuilder.Services.AddTransient(type);
        }

        return mauiAppBuilder;
    }
}
