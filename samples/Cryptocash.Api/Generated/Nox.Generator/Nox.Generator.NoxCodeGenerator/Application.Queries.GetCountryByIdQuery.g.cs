// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCountryByIdQuery(System.String keyId) : IRequest <IQueryable<CountryDto>>;

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