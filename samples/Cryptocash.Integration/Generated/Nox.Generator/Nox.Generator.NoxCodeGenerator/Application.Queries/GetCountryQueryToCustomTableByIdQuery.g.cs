// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryQueryToCustomTableByIdQuery(System.Int32 keyId) : IRequest <IQueryable<CountryQueryToCustomTableDto>>;

internal partial class GetCountryQueryToCustomTableByIdQueryHandler:GetCountryQueryToCustomTableByIdQueryHandlerBase
{
    public GetCountryQueryToCustomTableByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryQueryToCustomTableByIdQueryHandlerBase:  QueryBase<IQueryable<CountryQueryToCustomTableDto>>, IRequestHandler<GetCountryQueryToCustomTableByIdQuery, IQueryable<CountryQueryToCustomTableDto>>
{
    public  GetCountryQueryToCustomTableByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryQueryToCustomTableDto>> Handle(GetCountryQueryToCustomTableByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CountryQueryToCustomTableDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}