// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetCountriesQuery() : IRequest<IQueryable<CountryDto>>;

public partial class GetCountriesQueryHandler : QueryBase<IQueryable<CountryDto>>, IRequestHandler<GetCountriesQuery, IQueryable<CountryDto>>
{
    public  GetCountriesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CountryDto>)DataDbContext.Countries
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}