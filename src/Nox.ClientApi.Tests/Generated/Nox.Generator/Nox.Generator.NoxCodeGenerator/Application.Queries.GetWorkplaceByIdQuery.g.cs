// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetWorkplaceByIdQuery(System.Guid keyId) : IRequest <WorkplaceDto?>;

public partial class GetWorkplaceByIdQueryHandler:  QueryBase<WorkplaceDto?>, IRequestHandler<GetWorkplaceByIdQuery, WorkplaceDto?>
{
    public  GetWorkplaceByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<WorkplaceDto?> Handle(GetWorkplaceByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Workplaces
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                true
            );
        return Task.FromResult(OnResponse(item));
    }
}