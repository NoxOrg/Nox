// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityWithNuidByIdQuery(System.UInt32 keyId) : IRequest <IQueryable<TestEntityWithNuidDto>>;

internal partial class GetTestEntityWithNuidByIdQueryHandler:GetTestEntityWithNuidByIdQueryHandlerBase
{
    public  GetTestEntityWithNuidByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityWithNuidByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityWithNuidDto>>, IRequestHandler<GetTestEntityWithNuidByIdQuery, IQueryable<TestEntityWithNuidDto>>
{
    public  GetTestEntityWithNuidByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityWithNuidDto>> Handle(GetTestEntityWithNuidByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityWithNuids
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}