// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetCountryByIdQuery(System.Int64 keyId) : IRequest<CountryDto?>;

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