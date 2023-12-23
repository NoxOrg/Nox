using System.Linq.Expressions;

namespace Nox.Extensions;

public static partial class IQueryableExtensions
{
    public static IQueryable<T> WhereAnyMatch<T, V>(this IQueryable<T> source, IEnumerable<V> values, Expression<Func<T, V, bool>> match)
    {
        var parameter = match.Parameters[0];
        var body = values
            .Select(value => ((Expression<Func<V>>)(() => value)).Body)
            .Select(value => match.Body.ReplaceParameter(match.Parameters[1], value))
            .Aggregate(Expression.OrElse);
        var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
        return source.Where(predicate);
    }
}

public static partial class ExpressionBuilder
{
    public static Expression ReplaceParameter(this Expression source, ParameterExpression parameter, Expression value)
        => new ParameterReplacer { Parameter = parameter, Value = value }.Visit(source);

    class ParameterReplacer : ExpressionVisitor
    {
        public ParameterExpression? Parameter;
        public Expression? Value;
        protected override Expression VisitParameter(ParameterExpression node)
            => node == Parameter ? Value! : node;
    }
}