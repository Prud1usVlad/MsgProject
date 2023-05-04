﻿using Microsoft.Extensions.Logging;
using DevExpress.Maui;
using System.Text.Json;
using CommunityToolkit.Maui;
using Msg.Mobile.Views;
using Msg.Mobile.Services.Interfaces;
using Msg.Mobile.Services;

namespace Msg.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseDevExpress()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterHttpClient()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<AppShell>();
            mauiAppBuilder.Services.AddTransient<MainPage>();
            mauiAppBuilder.Services.AddTransient<Login>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterHttpClient(this MauiAppBuilder mauiAppBuilder)
        {
            Uri apiAddress = new Uri("http://192.168.1.239:5157/api/");

            mauiAppBuilder.Services.AddTransient<HttpClient>(p =>
            {
                var client = new HttpClient
                {
                    BaseAddress = apiAddress,
                };

                client.DefaultRequestHeaders.Add("Accept", "application/json");

                return client;
            });

            mauiAppBuilder.Services.AddTransient<JsonSerializerOptions>(p =>
            {
                return new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            });

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<IHttpService, HttpService>();
            mauiAppBuilder.Services.AddTransient<IUserService, UserService>();

            return mauiAppBuilder;
        }
    }
}