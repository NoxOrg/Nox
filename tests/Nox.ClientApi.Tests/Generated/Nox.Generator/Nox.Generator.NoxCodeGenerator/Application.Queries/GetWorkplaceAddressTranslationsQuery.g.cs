// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record  GetWorkplaceAddressTranslationsQuery(System.Guid keyId) : IRequest <IQueryable<WorkplaceAddressLocalizedDto>>;

internal partial class GetWorkplaceAddressTranslationsQueryHandler:GetWorkplaceAddressTranslationsQueryHandlerBase
{
    public  GetWorkplaceAddressTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetWorkplaceAddressTranslationsQueryHandlerBase:  QueryBase<IQueryable<WorkplaceAddressLocalizedDto>>, IRequestHandler<GetWorkplaceAddressTranslationsQuery, IQueryable<WorkplaceAddressLocalizedDto>>
{
    public  GetWorkplaceAddressTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<WorkplaceAddressLocalizedDto>> Handle(GetWorkplaceAddressTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<WorkplaceAddressLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}