using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FlowLauncher.ViewModels;

public partial class RootLayoutViewModel : ViewModelBase
{
    private Dictionary<string, PageViewModel> _NavigateMap => field ??= new()
    {
        ["main"] = new MainPageViewModel(),
        ["install"] = new InstallPageViewModel(),
        ["tools"] = new ToolsPageViewModel(),
        ["settings"] = new SettingsPageViewModel(),
    };

    public void RegisterPage(PageViewModel page) => _NavigateMap[page.Id] = page;

    private readonly Stack<PageViewModel> _BackStack = [];

    [ObservableProperty]
    public partial PageViewModel? LastPage { get; private set; }

    [ObservableProperty]
    public partial bool HasLastPage { get; private set; }

    public PageViewModel CurrentPage
    {
        get => field ??= _NavigateMap["main"];
        private set
        {
            HasLastPage = _BackStack.TryPeek(out var page);
            LastPage = HasLastPage ? page! : null;
            if (field == value) return;
            SetProperty(ref field, value);
        }
    }

    [ObservableProperty] public partial double _LeftMenuControl_Opacity { get; private set; } = 1;
    [ObservableProperty] public partial double _LeftExtraControl_Scale { get; private set; } = 0;
    [ObservableProperty] public partial double _LeftExtraControl_Opacity { get; private set; } = 1;

    private void _Navigate(string? pageId, bool forward = true)
    {
        PageViewModel? page;
        if (pageId == null)
        {
            if (!_BackStack.TryPop(out page)) return;
        }
        else
        {
            if (!_NavigateMap.TryGetValue(pageId, out page)) return;
            if (forward) _BackStack.Push(CurrentPage);
            else _BackStack.Clear();
        }
        Dispatcher.UIThread.Invoke(async () =>
        {
            _LeftExtraControl_Scale = .5;
            _LeftExtraControl_Opacity = 0;
            _LeftMenuControl_Opacity = 0;
            await Task.Delay(TimeSpan.FromSeconds(.05));
            CurrentPage = page;
            _LeftExtraControl_Scale = 1;
            _LeftExtraControl_Opacity = 1;
            _LeftMenuControl_Opacity = 1;
        });
    }

    [RelayCommand]
    private void Back() => _Navigate(null);

    [RelayCommand]
    private void Navigate(string pageId) => _Navigate(pageId, false);

    [RelayCommand]
    private void Forward(string pageId) => _Navigate(pageId);
}
