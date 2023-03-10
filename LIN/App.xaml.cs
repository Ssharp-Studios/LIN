using LIN.CustomControls;
using Microsoft.Maui.Platform;

namespace LIN;

public partial class App : Application
{
	public App()
	{
        InitializeComponent();

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
            }
        });


        var form = new UI.Vistas.Login();
        MainPage = new NavigationPage(form);
    }
}
