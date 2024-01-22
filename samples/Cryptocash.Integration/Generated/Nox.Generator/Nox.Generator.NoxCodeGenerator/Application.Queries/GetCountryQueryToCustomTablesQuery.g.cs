// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryQueryToCustomTablesQuery() : IRequest<IQueryable<CountryQueryToCustomTableDto>>;

internal partial class GetCountryQueryToCustomTablesQueryHandler: GetCountryQueryToCustomTablesQueryHandlerBase
{
    public GetCountryQueryToCustomTablesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryQueryToCustomTablesQueryHandlerBase : QueryBase<IQueryable<CountryQueryToCustomTableDto>>, IRequestHandler<GetCountryQueryToCustomTablesQuery, IQueryable<CountryQueryToCustomTableDto>>
{
    public  GetCountryQueryToCustomTablesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryQueryToCustomTableDto>> Handle(GetCountryQueryToCustomTablesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<CountryQueryToCustomTableDto>();
       return Task.FromResult(OnResponse(query));
    }
}