using FlowLauncher.Resources;
using FlowLauncher.Views;

namespace FlowLauncher.ViewModels;

public partial class MainPageViewModel : PageViewModel
{
    public MainPageViewModel() : base("main", Strings.PageTitleMain)
    {
        LeftMenuItems = [
            new MenuTitleViewModel
            {
                Title = "Title"
            },
            new MenuItemViewModel
            {
                Title = "123",
                Icon = GetIcon("IconSettings")
            },
            new MenuItemViewModel
            {
                Title = "456",
                Icon = GetIcon("IconSettings")
            },
            new MenuItemViewModel
            {
                Title = "789",
                Icon = GetIcon("IconSettings")
            },
        ];
        Content = new MainPage { DataContext = this };
    }
}
