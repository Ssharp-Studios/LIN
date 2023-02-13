global using CommunityExtensions;
global using CommunityToolkit.Maui;
global using CommunityToolkit.Maui.Views;
global using CommunityToolkit.Maui.Animations;
global using CommunityToolkit.Maui.Extensions;

namespace LIN;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("Quicksand-Bold.ttf", "QSB");
                fonts.AddFont("Quicksand-Light.ttf", "QSL");
                fonts.AddFont("Quicksand-Medium.ttf", "QSM");
                fonts.AddFont("Quicksand-Regular.ttf", "QSR");
                fonts.AddFont("Quicksand-SemiBold.ttf", "QSSB");
            })
            .UseMauiCommunityToolkit();

        return builder.Build();
    }
}