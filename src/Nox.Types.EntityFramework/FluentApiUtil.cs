namespace Nox.Types.EntityFramework;

public static class FluentApiUtil
{
    public static T IfNotNull<T>(this T builder, object? value, Action<T> actionToExecute)
    {
        if (value != null)
        {
            actionToExecute(builder);
        }

        return builder;
    }
    public static T If<T>(this T builder, bool value, Action<T> actionToExecute)
    {
        if (value)
        {
            actionToExecute(builder);
        }

        return builder;
    }
}