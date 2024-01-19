// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryJsonToTablesQuery() : IRequest<IQueryable<CountryJsonToTableDto>>;

internal partial class GetCountryJsonToTablesQueryHandler: GetCountryJsonToTablesQueryHandlerBase
{
    public GetCountryJsonToTablesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryJsonToTablesQueryHandlerBase : QueryBase<IQueryable<CountryJsonToTableDto>>, IRequestHandler<GetCountryJsonToTablesQuery, IQueryable<CountryJsonToTableDto>>
{
    public  GetCountryJsonToTablesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryJsonToTableDto>> Handle(GetCountryJsonToTablesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<CountryJsonToTableDto>();
       return Task.FromResult(OnResponse(query));
    }
}