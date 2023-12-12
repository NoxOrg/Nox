// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryQueryToCustomTableByIdQuery(System.Int32 keyId) : IRequest <IQueryable<CountryQueryToCustomTableDto>>;

internal partial class GetCountryQueryToCustomTableByIdQueryHandler:GetCountryQueryToCustomTableByIdQueryHandlerBase
{
    public  GetCountryQueryToCustomTableByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountryQueryToCustomTableByIdQueryHandlerBase:  QueryBase<IQueryable<CountryQueryToCustomTableDto>>, IRequestHandler<GetCountryQueryToCustomTableByIdQuery, IQueryable<CountryQueryToCustomTableDto>>
{
    public  GetCountryQueryToCustomTableByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryQueryToCustomTableDto>> Handle(GetCountryQueryToCustomTableByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.CountryQueryToCustomTables
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}