using FlowLauncher.Resources;
using FlowLauncher.Views;

namespace FlowLauncher.ViewModels;

public partial class MainPageViewModel : PageViewModel
{
    public MainPageViewModel() : base("main", Strings.PageTitleMain)
    {
        Content = new MainPage { DataContext = this };
        LeftMenuItems = [
            new MenuTitleViewModel
            {
                Title = "Title"
            },
            new MenuItemViewModel
            {
                Title = "Main",
                Icon = Icon("IconSettings"),
                TargetContent = Content
            },
            new MenuItemViewModel
            {
                Title = "456",
                Icon = Icon("IconSettings")
            },
            new MenuItemViewModel
            {
                Title = "789",
                Icon = Icon("IconSettings")
            },
        ];
    }
}
