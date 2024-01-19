// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryJsonToTablesQuery() : IRequest<IQueryable<CountryJsonToTableDto>>;

internal partial class GetCountryJsonToTablesQueryHandler: GetCountryJsonToTablesQueryHandlerBase
{
    public GetCountryJsonToTablesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountryJsonToTablesQueryHandlerBase : QueryBase<IQueryable<CountryJsonToTableDto>>, IRequestHandler<GetCountryJsonToTablesQuery, IQueryable<CountryJsonToTableDto>>
{
    public  GetCountryJsonToTablesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryJsonToTableDto>> Handle(GetCountryJsonToTablesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CountryJsonToTableDto>)DataDbContext.CountryJsonToTables
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}