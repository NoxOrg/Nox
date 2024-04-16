// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record GetWorkplaceByIdQuery(System.Int64 keyId) : IRequest <IQueryable<WorkplaceDto>>;

internal partial class GetWorkplaceByIdQueryHandler:GetWorkplaceByIdQueryHandlerBase
{
    public GetWorkplaceByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetWorkplaceByIdQueryHandlerBase:  QueryBase<IQueryable<WorkplaceDto>>, IRequestHandler<GetWorkplaceByIdQuery, IQueryable<WorkplaceDto>>
{
    public  GetWorkplaceByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<WorkplaceDto>> Handle(GetWorkplaceByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<WorkplaceDto>()
            .Include(e => e.WorkplaceAddresses)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}