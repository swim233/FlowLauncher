using FlowLauncher.Components.UI;
using FlowLauncher.Resources;
using FlowLauncher.Views;

namespace FlowLauncher.ViewModels;

public partial class ToolsPageViewModel : PageViewModel<ToolsPage>
{
    public ToolsPageViewModel() : base("tools", Strings.PageTitleTools)
    {
        LeftMenuItems = [
            new LeftMenuTitleViewModel
            {
                Title = "Title"
            },
            new LeftMenuItemViewModel
            {
                Title = "MainLoooooooooooooooog",
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
