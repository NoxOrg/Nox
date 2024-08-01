// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using CryptocashIntegration.Application.Dto;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryProcToTablesQuery() : IRequest<IQueryable<CountryProcToTableDto>>;

internal partial class GetCountryProcToTablesQueryHandler: GetCountryProcToTablesQueryHandlerBase
{
    public GetCountryProcToTablesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryProcToTablesQueryHandlerBase : QueryBase<IQueryable<CountryProcToTableDto>>, IRequestHandler<GetCountryProcToTablesQuery, IQueryable<CountryProcToTableDto>>
{
    public  GetCountryProcToTablesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryProcToTableDto>> Handle(GetCountryProcToTablesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<CountryProcToTableDto>();
       return Task.FromResult(OnResponse(query));
    }
}