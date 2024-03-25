// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Nox.Exceptions;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public record  GetWorkplaceAddressTranslationsByParentIdQuery(System.Int64 WorkplaceId,System.Guid WorkplaceAddressId) : IRequest <IQueryable<WorkplaceAddressLocalizedDto>>;

internal partial class GetWorkplaceAddressTranslationsByParentIdQueryHandler:GetWorkplaceAddressTranslationsByParentIdQueryHandlerBase
{
    public  GetWorkplaceAddressTranslationsByParentIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetWorkplaceAddressTranslationsByParentIdQueryHandlerBase:  QueryBase<IQueryable<WorkplaceAddressLocalizedDto>>, IRequestHandler<GetWorkplaceAddressTranslationsByParentIdQuery, IQueryable<WorkplaceAddressLocalizedDto>>
{
    public  GetWorkplaceAddressTranslationsByParentIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual async Task<IQueryable<WorkplaceAddressLocalizedDto>> Handle(GetWorkplaceAddressTranslationsByParentIdQuery request, CancellationToken cancellationToken)
    {    
        var parentEntity = await ReadOnlyRepository.Query<WorkplaceDto>()
                    .Include(e => e.WorkplaceAddresses)
                    .Where(r =>
                            r.Id.Equals(request.WorkplaceId)
                            && r.WorkplaceAddresses.Any(e => e.Id.Equals(request.WorkplaceAddressId))
                    ).CountAsync();
        if (parentEntity == 0)
        {
            throw new EntityNotFoundException("Workplace", request.WorkplaceId.ToString());
        }
        
        var query = ReadOnlyRepository.Query<WorkplaceAddressLocalizedDto>()
           .Where(r =>
                r.Id.Equals(request.WorkplaceAddressId) 
           );
           
        
        return OnResponse(query);
        
    }
}