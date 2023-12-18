// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryJsonToTableByIdQuery(System.Int32 keyId) : IRequest <IQueryable<CountryJsonToTableDto>>;

internal partial class GetCountryJsonToTableByIdQueryHandler:GetCountryJsonToTableByIdQueryHandlerBase
{
    public  GetCountryJsonToTableByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountryJsonToTableByIdQueryHandlerBase:  QueryBase<IQueryable<CountryJsonToTableDto>>, IRequestHandler<GetCountryJsonToTableByIdQuery, IQueryable<CountryJsonToTableDto>>
{
    public  GetCountryJsonToTableByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryJsonToTableDto>> Handle(GetCountryJsonToTableByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.CountryJsonToTables
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}