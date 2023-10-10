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
}
