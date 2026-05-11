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

    public void RegisterPage(PageViewModel page)
    {
        _NavigateMap[page.Id] = page;
    }

    private readonly Stack<PageViewModel> _BackStack = [];

    public PageViewModel? LastPage
    {
        get;
        private set
        {
            if (field == value) return;
            SetProperty(ref field, value);
        }
    }

    public bool HasLastPage
    {
        get;
        private set
        {
            if (field == value) return;
            SetProperty(ref field, value);
        }
    }

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

    private void _Navigate(string pageId, bool forward)
    {
        if (!_NavigateMap.TryGetValue(pageId, out var page)) return;
        if (forward) _BackStack.Push(CurrentPage);
        else _BackStack.Clear();
        CurrentPage = page;
    }

    [RelayCommand]
    private void Back()
    {
        if (_BackStack.TryPop(out var page)) CurrentPage = page;
    }

    [RelayCommand]
    private void Navigate(string pageId) => _Navigate(pageId, false);

    [RelayCommand]
    private void Forward(string pageId) => _Navigate(pageId, true);
}
