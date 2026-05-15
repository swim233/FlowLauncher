using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlowLauncher.Platforms;

namespace FlowLauncher.ViewModels;

public abstract partial class PageViewModel(string id, string title = "Untitled") : ViewModelBase
{
    public static RootLayoutViewModel RootLayout => BaseWindow.RootLayout;

    public string Id { get; } = id;

    public string Title { get; protected set => SetProperty(ref field, value); } = title;

    [ObservableProperty] private Collection<MenuItemViewModel> _leftMenuItems = new ObservableCollection<MenuItemViewModel>();

    [ObservableProperty] private Control? _leftExtraContent = null;

    [ObservableProperty] private Control? _content = null;

    protected static Geometry? Icon(string resourceKey)
    {
        if (Application.Current?.Resources is not { } res) return null;
        if (!res.TryGetValue(resourceKey, out var value)) return null;
        return value as Geometry;
    }
}

public abstract class PageViewModel<TPageControl> : PageViewModel
    where TPageControl : Control, new()
{
    protected PageViewModel(string id, string title = "Untitled") : base(id, title)
    {
        Content = new TPageControl { DataContext = this };
    }
}
