namespace FlowLauncher.Components.UI;

public abstract class PageContentViewModel : ViewModelBase
{
    public abstract PageContentView ViewControl { get; }

    public ViewModelBase ViewModel { get; protected init; }

    protected PageContentViewModel()
    {
        ViewModel = this;
    }
}

public abstract class PageContentViewModel<TPage> : PageContentViewModel
    where TPage : PageViewModel
{
    public required TPage Page { get; init; }
}

public abstract class PageContentViewModel<TPage, TContent> : PageContentViewModel<TPage>
    where TPage : PageViewModel
    where TContent : PageContentView, new()
{
    public override PageContentView ViewControl { get; } = PageContentView.GetViewCacheOrCreate<TContent>();
}
