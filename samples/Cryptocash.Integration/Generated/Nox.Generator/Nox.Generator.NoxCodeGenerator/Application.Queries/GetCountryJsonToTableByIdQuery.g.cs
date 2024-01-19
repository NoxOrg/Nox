// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryJsonToTableByIdQuery(System.Int32 keyId) : IRequest <IQueryable<CountryJsonToTableDto>>;

internal partial class GetCountryJsonToTableByIdQueryHandler:GetCountryJsonToTableByIdQueryHandlerBase
{
    public GetCountryJsonToTableByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryJsonToTableByIdQueryHandlerBase:  QueryBase<IQueryable<CountryJsonToTableDto>>, IRequestHandler<GetCountryJsonToTableByIdQuery, IQueryable<CountryJsonToTableDto>>
{
    public  GetCountryJsonToTableByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryJsonToTableDto>> Handle(GetCountryJsonToTableByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CountryJsonToTableDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}