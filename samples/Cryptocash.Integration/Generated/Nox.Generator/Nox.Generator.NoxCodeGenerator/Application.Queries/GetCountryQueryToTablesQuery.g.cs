// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryQueryToTablesQuery() : IRequest<IQueryable<CountryQueryToTableDto>>;

internal partial class GetCountryQueryToTablesQueryHandler: GetCountryQueryToTablesQueryHandlerBase
{
    public GetCountryQueryToTablesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountryQueryToTablesQueryHandlerBase : QueryBase<IQueryable<CountryQueryToTableDto>>, IRequestHandler<GetCountryQueryToTablesQuery, IQueryable<CountryQueryToTableDto>>
{
    public  GetCountryQueryToTablesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryQueryToTableDto>> Handle(GetCountryQueryToTablesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CountryQueryToTableDto>)DataDbContext.CountryQueryToTables
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}