// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetCountryByIdQuery(System.Int64 keyId) : IRequest <IQueryable<CountryDto>>;

public partial class GetCountryByIdQueryHandler:  QueryBase<IQueryable<CountryDto>>, IRequestHandler<GetCountryByIdQuery, IQueryable<CountryDto>>
{
    public  GetCountryByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Countries
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}