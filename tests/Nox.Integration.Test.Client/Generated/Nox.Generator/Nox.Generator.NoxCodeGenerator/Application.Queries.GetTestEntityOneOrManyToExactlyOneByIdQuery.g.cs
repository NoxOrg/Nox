// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityOneOrManyToExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOneOrManyToExactlyOneDto>>;

internal partial class GetTestEntityOneOrManyToExactlyOneByIdQueryHandler:GetTestEntityOneOrManyToExactlyOneByIdQueryHandlerBase
{
    public  GetTestEntityOneOrManyToExactlyOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOneOrManyToExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOneOrManyToExactlyOneDto>>, IRequestHandler<GetTestEntityOneOrManyToExactlyOneByIdQuery, IQueryable<TestEntityOneOrManyToExactlyOneDto>>
{
    public  GetTestEntityOneOrManyToExactlyOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToExactlyOneDto>> Handle(GetTestEntityOneOrManyToExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityOneOrManyToExactlyOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}