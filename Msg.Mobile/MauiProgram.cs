using Microsoft.Extensions.Logging;
using DevExpress.Maui;
using System.Text.Json;
using CommunityToolkit.Maui;
using Msg.Mobile.Views;
using Msg.Mobile.Services.Interfaces;
using Msg.Mobile.Services;
using Msg.Mobile.ViewModels;

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
            mauiAppBuilder.Services.AddTransient<WarningsViewModel>();
            mauiAppBuilder.Services.AddTransient<ProfileViewModel>();
            mauiAppBuilder.Services.AddTransient<ChangePasswordViewModel>();
            mauiAppBuilder.Services.AddTransient<DevicesViewModel>();
            mauiAppBuilder.Services.AddTransient<DeviceDetailsViewModel>();
            mauiAppBuilder.Services.AddTransient<HelperMainViewModel>();
            mauiAppBuilder.Services.AddTransient<HeplerResultViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<AppShell>();
            mauiAppBuilder.Services.AddTransient<MainPage>();
            mauiAppBuilder.Services.AddTransient<Login>();
            mauiAppBuilder.Services.AddTransient<Warnings>();
            mauiAppBuilder.Services.AddTransient<Profile>();
            mauiAppBuilder.Services.AddTransient<ChangePassword>();
            mauiAppBuilder.Services.AddTransient<Devices>();
            mauiAppBuilder.Services.AddTransient<DeviceDetails>();
            mauiAppBuilder.Services.AddTransient<HelperMain>();
            mauiAppBuilder.Services.AddTransient<HelperResult>();

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
                
                var token = Preferences.Default.Get("Token", "none");

                if (token != "none")
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

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
            mauiAppBuilder.Services.AddTransient<IWarningService, WarningService>();
            mauiAppBuilder.Services.AddTransient<IDeviceService, DeviceService>();
            mauiAppBuilder.Services.AddTransient<IPlantService, PlantService>();
            mauiAppBuilder.Services.AddTransient<ISubstrateService, SubstrateService>();
            mauiAppBuilder.Services.AddTransient<IHelperService, HelperService>();

            return mauiAppBuilder;
        }
    }
}