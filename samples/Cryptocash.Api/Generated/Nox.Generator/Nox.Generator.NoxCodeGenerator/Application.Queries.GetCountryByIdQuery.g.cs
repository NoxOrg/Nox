// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCountryByIdQuery(System.String keyId) : IRequest <CountryDto?>;

public partial class GetCountryByIdQueryHandler:  QueryBase<CountryDto?>, IRequestHandler<GetCountryByIdQuery, CountryDto?>
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
            .Include(r => r.CountryUsedByCurrency)
            .Include(r => r.CountryUsedByCommissions)
            .Include(r => r.CountryUsedByVendingMachines)
            .Include(r => r.CountryUsedByCustomers)
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}