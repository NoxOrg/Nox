// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryQueryToCustomTablesQuery() : IRequest<IQueryable<CountryQueryToCustomTableDto>>;

internal partial class GetCountryQueryToCustomTablesQueryHandler: GetCountryQueryToCustomTablesQueryHandlerBase
{
    public GetCountryQueryToCustomTablesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountryQueryToCustomTablesQueryHandlerBase : QueryBase<IQueryable<CountryQueryToCustomTableDto>>, IRequestHandler<GetCountryQueryToCustomTablesQuery, IQueryable<CountryQueryToCustomTableDto>>
{
    public  GetCountryQueryToCustomTablesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryQueryToCustomTableDto>> Handle(GetCountryQueryToCustomTablesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CountryQueryToCustomTableDto>)DataDbContext.CountryQueryToCustomTables
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}