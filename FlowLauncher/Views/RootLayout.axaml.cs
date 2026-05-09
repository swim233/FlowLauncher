using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using FlowLauncher.ViewModels;

namespace FlowLauncher.Views;

public partial class RootLayout : UserControl
{
    public static readonly StyledProperty<Window?> ParentWindowProperty =
        AvaloniaProperty.Register<RootLayout, Window?>(nameof(ParentWindow));

    public Window? ParentWindow
    {
        get => GetValue(ParentWindowProperty);
        set => SetValue(ParentWindowProperty, value);
    }

    public RootLayout()
    {
        InitializeComponent();
    }

    private RootLayoutViewModel ViewModel => DataContext as RootLayoutViewModel
        ?? throw new InvalidOperationException("Layout view model not set or type mismatch.");

    private void TopBar_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        ParentWindow?.BeginMoveDrag(e);
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        base.OnKeyUp(e);
        if (e.Key == Key.Escape)
        {
            ViewModel.BackCommand.Execute(null);
        }
    }
}
