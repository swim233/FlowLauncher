using FlowLauncher.Components.UI;
using FlowLauncher.Resources;
using FlowLauncher.Views;

namespace FlowLauncher.ViewModels;

public partial class MainPageViewModel : PageViewModel<MainPage>
{
    public MainPageViewModel() : base("main", Strings.PageTitleMain)
    {
        LeftMenuItems = [
            new LeftMenuTitleViewModel
            {
                Title = "Title"
            },
            new LeftMenuItemViewModel
            {
                Title = "Main",
                Icon = Icon("IconSettings"),
                TargetContent = Content
            },
            new LeftMenuItemViewModel
            {
                Title = "456",
                Icon = Icon("IconSettings"),
                TargetContent = PageContent<MainPage>()
            },
            new LeftMenuItemViewModel
            {
                Title = "789",
                Icon = Icon("IconSettings")
            },
        ];
    }
}
