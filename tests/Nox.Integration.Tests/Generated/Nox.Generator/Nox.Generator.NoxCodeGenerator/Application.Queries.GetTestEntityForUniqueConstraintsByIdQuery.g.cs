// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityForUniqueConstraintsByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityForUniqueConstraintsDto>>;

internal partial class GetTestEntityForUniqueConstraintsByIdQueryHandler:GetTestEntityForUniqueConstraintsByIdQueryHandlerBase
{
    public  GetTestEntityForUniqueConstraintsByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityForUniqueConstraintsByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityForUniqueConstraintsDto>>, IRequestHandler<GetTestEntityForUniqueConstraintsByIdQuery, IQueryable<TestEntityForUniqueConstraintsDto>>
{
    public  GetTestEntityForUniqueConstraintsByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityForUniqueConstraintsDto>> Handle(GetTestEntityForUniqueConstraintsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityForUniqueConstraints
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}