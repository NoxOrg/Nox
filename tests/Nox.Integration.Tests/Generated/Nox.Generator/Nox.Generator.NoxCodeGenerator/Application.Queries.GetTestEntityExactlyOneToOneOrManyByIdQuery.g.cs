// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityExactlyOneToOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityExactlyOneToOneOrManyDto>>;

internal partial class GetTestEntityExactlyOneToOneOrManyByIdQueryHandler:GetTestEntityExactlyOneToOneOrManyByIdQueryHandlerBase
{
    public  GetTestEntityExactlyOneToOneOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityExactlyOneToOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityExactlyOneToOneOrManyDto>>, IRequestHandler<GetTestEntityExactlyOneToOneOrManyByIdQuery, IQueryable<TestEntityExactlyOneToOneOrManyDto>>
{
    public  GetTestEntityExactlyOneToOneOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToOneOrManyDto>> Handle(GetTestEntityExactlyOneToOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityExactlyOneToOneOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}