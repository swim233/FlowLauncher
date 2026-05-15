using Avalonia.Data.Converters;

namespace FlowLauncher.Controls;

public static class Converters
{
    public static readonly FuncValueConverter<bool, double?, double> BoolToOpacity = new(static (value, param) =>
    {
        if (!value) return 0;
        var opacity = param ?? 1;
        return opacity;
    });

    public static readonly FuncMultiValueConverter<object?, bool> AllEqual = new(static parts =>
    {
        using var it = parts.GetEnumerator();
        if (!it.MoveNext()) return true;
        var value = it.Current;
        while (it.MoveNext()) if (it.Current != value) return false;
        return true;
    });
}
