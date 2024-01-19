// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryQueryToTablesQuery() : IRequest<IQueryable<CountryQueryToTableDto>>;

internal partial class GetCountryQueryToTablesQueryHandler: GetCountryQueryToTablesQueryHandlerBase
{
    public GetCountryQueryToTablesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryQueryToTablesQueryHandlerBase : QueryBase<IQueryable<CountryQueryToTableDto>>, IRequestHandler<GetCountryQueryToTablesQuery, IQueryable<CountryQueryToTableDto>>
{
    public  GetCountryQueryToTablesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryQueryToTableDto>> Handle(GetCountryQueryToTablesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<CountryQueryToTableDto>();
       return Task.FromResult(OnResponse(query));
    }
}