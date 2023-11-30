// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetCountryByIdQuery(System.Int64 keyId) : IRequest <IQueryable<CountryDto>>;

internal partial class GetCountryByIdQueryHandler:GetCountryByIdQueryHandlerBase
{
    public  GetCountryByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountryByIdQueryHandlerBase:  QueryBase<IQueryable<CountryDto>>, IRequestHandler<GetCountryByIdQuery, IQueryable<CountryDto>>
{
    public  GetCountryByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Countries
            .AsNoTracking()
            .Include(e => e.CountryLocalNames)
            .Include(e => e.CountryBarCode)
            .Include(e => e.CountryTimeZones)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}