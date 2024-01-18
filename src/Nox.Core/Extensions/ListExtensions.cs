namespace Nox.Extensions;

public static class ListExtensions
{
    public static bool HasAtLeastOneItem<T>(this List<T> list)
    {
        return list != null && list.Any();
    }
    public static bool HasExactlyOneItem<T>(this List<T> list)
    {
        return list != null && list.Count == 1;
    }
}
