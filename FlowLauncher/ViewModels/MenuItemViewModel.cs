using CommunityToolkit.Mvvm.ComponentModel;

namespace FlowLauncher.ViewModels;

public partial class MenuItemViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isEnabled = true;
    [ObservableProperty] private string _title = "";
    [ObservableProperty] private string? _toolTip = null;
}
