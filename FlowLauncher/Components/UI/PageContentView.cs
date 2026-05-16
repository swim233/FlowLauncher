using Avalonia.Controls;

namespace FlowLauncher.Components.UI;

public abstract class PageContentView : UserControl
{
    private static readonly Dictionary<Type, PageContentView> _ViewCache = [];

    internal static PageContentView GetViewCacheOrCreate<TContent>(bool bypassCache = false)
        where TContent : PageContentView, new()
    {
        if (bypassCache) return new TContent();
        var type = typeof(TContent);
        if (!_ViewCache.TryGetValue(type, out var control))
            _ViewCache[type] = control = new TContent();
        return control;
    }
}
