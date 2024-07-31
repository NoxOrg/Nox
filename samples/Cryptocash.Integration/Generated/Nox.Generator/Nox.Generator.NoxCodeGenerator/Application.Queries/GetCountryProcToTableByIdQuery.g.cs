// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using CryptocashIntegration.Application.Dto;

namespace CryptocashIntegration.Application.Queries;

public partial record GetCountryProcToTableByIdQuery(System.Int32 keyCountryId) : IRequest <IQueryable<CountryProcToTableDto>>;

internal partial class GetCountryProcToTableByIdQueryHandler:GetCountryProcToTableByIdQueryHandlerBase
{
    public GetCountryProcToTableByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryProcToTableByIdQueryHandlerBase:  QueryBase<IQueryable<CountryProcToTableDto>>, IRequestHandler<GetCountryProcToTableByIdQuery, IQueryable<CountryProcToTableDto>>
{
    public  GetCountryProcToTableByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryProcToTableDto>> Handle(GetCountryProcToTableByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CountryProcToTableDto>()
            .Where(r =>
                r.CountryId.Equals(request.keyCountryId));
        return Task.FromResult(OnResponse(query));
    }
}