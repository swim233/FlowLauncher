using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FlowLauncher.ViewModels;

public partial class MenuItemViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isEnabled = true;
    [ObservableProperty] private string _title = "";
    [ObservableProperty] private Geometry? _icon = null;
    [ObservableProperty] private string? _toolTip = null;
    [ObservableProperty] private ICommand? _command = null;
    [ObservableProperty] private object? _commandParameter = null;
    [ObservableProperty] private Control? _targetContent = null;
}
