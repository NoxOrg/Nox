// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCountryByIdQuery(System.String keyId) : IRequest<CountryDto?>;

public class GetCountryByIdQueryHandler: IRequestHandler<GetCountryByIdQuery, CountryDto?>
{
    public  GetCountryByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CountryDto?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Countries
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}