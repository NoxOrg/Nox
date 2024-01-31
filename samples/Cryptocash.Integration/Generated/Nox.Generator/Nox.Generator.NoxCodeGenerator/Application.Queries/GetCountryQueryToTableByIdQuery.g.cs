// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using CryptocashIntegration.Application.Dto;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryQueryToTableByIdQuery(System.Int32 keyId) : IRequest <IQueryable<CountryQueryToTableDto>>;

internal partial class GetCountryQueryToTableByIdQueryHandler:GetCountryQueryToTableByIdQueryHandlerBase
{
    public GetCountryQueryToTableByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryQueryToTableByIdQueryHandlerBase:  QueryBase<IQueryable<CountryQueryToTableDto>>, IRequestHandler<GetCountryQueryToTableByIdQuery, IQueryable<CountryQueryToTableDto>>
{
    public  GetCountryQueryToTableByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryQueryToTableDto>> Handle(GetCountryQueryToTableByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CountryQueryToTableDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}