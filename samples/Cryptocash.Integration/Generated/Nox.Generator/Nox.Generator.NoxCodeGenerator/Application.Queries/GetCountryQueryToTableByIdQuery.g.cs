// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryQueryToTableByIdQuery(System.Int32 keyId) : IRequest <IQueryable<CountryQueryToTableDto>>;

internal partial class GetCountryQueryToTableByIdQueryHandler:GetCountryQueryToTableByIdQueryHandlerBase
{
    public  GetCountryQueryToTableByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountryQueryToTableByIdQueryHandlerBase:  QueryBase<IQueryable<CountryQueryToTableDto>>, IRequestHandler<GetCountryQueryToTableByIdQuery, IQueryable<CountryQueryToTableDto>>
{
    public  GetCountryQueryToTableByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryQueryToTableDto>> Handle(GetCountryQueryToTableByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.CountryQueryToTables
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}