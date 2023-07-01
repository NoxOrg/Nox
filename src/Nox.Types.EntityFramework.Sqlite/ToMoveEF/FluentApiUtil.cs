namespace Nox.Types.EntityFramework.Sqlite.ToMoveEF;

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
}