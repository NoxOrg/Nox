using Microsoft.EntityFrameworkCore;
using Nox.Reference;
using Nox.Reference.Data.World;
using System.Linq.Expressions;

namespace Nox.Types.Extensions;

public static class CountryExtensions
{
    public static CountryCode2 GetCountryCode2(this Country referenceCountry) => CountryCode2.From(referenceCountry.AlphaCode2);
    public static CountryCode3 GetCountryCode3(this Country referenceCountry) => CountryCode3.From(referenceCountry.AlphaCode3);
    public static CountryNumber GetCountryNumber(this Country referenceCountry) => CountryNumber.From(ushort.Parse(referenceCountry.NumericCode));
    public static Country GetReferenceCountry(this CountryCode3 countryCode3, params Expression<Func<Country, object>>[] includeExpressions)
    {
        using var worldContext = new WorldContext();
        IQueryable<Country> query = BuildQuery(includeExpressions, worldContext);
        return query.GetByAlpha3Code(countryCode3.Value)!;
    }
    public static Country GetReferenceCountry(this CountryCode2 countryCode2, params Expression<Func<Country, object>>[] includeExpressions)
    {
        using var worldContext = new WorldContext();
        IQueryable<Country> query = BuildQuery(includeExpressions, worldContext);
        return query.GetByAlpha2Code(countryCode2.Value)!;
    }
    public static Country GetReferenceCountry(this CountryNumber countryNumber, params Expression<Func<Country, object>>[] includeExpressions)
    {
        using var worldContext = new WorldContext();
        IQueryable<Country> query = BuildQuery(includeExpressions, worldContext);
        return query.GetByNumericCode(countryNumber.Value.ToString())!;
    }

    private static IQueryable<Country> BuildQuery(Expression<Func<Country, object>>[] includeExpressions, WorldContext worldContext)
    {
        IQueryable<Country> query = worldContext.GetCountriesQuery();
        if (includeExpressions is not null)
        {
            foreach (var includeExpression in includeExpressions)
            {
                query = query.Include(includeExpression);
            }
        }
        return query;
    }
}