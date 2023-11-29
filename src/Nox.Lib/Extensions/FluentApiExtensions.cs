namespace Nox.Extensions;

public static class FluentApiExtensions
{
    public static void SetIfNotNull<T>(this T obj, object? value, Action<T> setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction(obj);
        }
    }
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> array, Action<T> act)
    {
        foreach (var i in array)
            act(i);
        return array;
    }
    public static bool HasAtLeastOneItem<T>(this List<T> list)
    {
        return list != null && list.Count > 0;
    }
    public static bool HasExactlyOneItem<T>(this List<T> list)
    {
        return list != null && list.Count == 1;
    }
}
