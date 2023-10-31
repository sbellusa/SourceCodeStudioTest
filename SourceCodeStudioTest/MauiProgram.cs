using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SourceCodeStudioTest.Services;
using SourceCodeStudioTest.ViewModels;
using SourceCodeStudioTest.Views;

namespace SourceCodeStudioTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()          
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            // Services
            builder.Services.AddSingleton<IDogService, DogService>();
            builder.Services.AddSingleton<ILocationService, LocationService>();
            builder.Services.AddHttpClient();


            // Views and ViewModels
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddSingleton<DogsPage>();
            builder.Services.AddSingleton<DogsPageViewModel>();


            return builder.Build();
        }
    }
}