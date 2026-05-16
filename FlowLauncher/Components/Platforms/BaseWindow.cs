using Avalonia.Controls;
using RootLayoutViewModel = FlowLauncher.Components.UI.RootLayoutViewModel;

namespace FlowLauncher.Components.Platforms;

public class BaseWindow : Window
{
    public static RootLayoutViewModel RootLayout { get; } = new();

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        Flow.InvokeTask("app:func:stop");
    }
}
