// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetCountriesQuery() : IRequest<IQueryable<CountryDto>>;

internal partial class GetCountriesQueryHandler: GetCountriesQueryHandlerBase
{
    public GetCountriesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountriesQueryHandlerBase : QueryBase<IQueryable<CountryDto>>, IRequestHandler<GetCountriesQuery, IQueryable<CountryDto>>
{
    public  GetCountriesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<CountryDto>()
            .Include(e => e.CountryTimeZones)
            .Include(e => e.Holidays);
       return Task.FromResult(OnResponse(query));
    }
}