// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityExactlyOneDto>>;

internal partial class GetTestEntityExactlyOneByIdQueryHandler:GetTestEntityExactlyOneByIdQueryHandlerBase
{
    public  GetTestEntityExactlyOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityExactlyOneDto>>, IRequestHandler<GetTestEntityExactlyOneByIdQuery, IQueryable<TestEntityExactlyOneDto>>
{
    public  GetTestEntityExactlyOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneDto>> Handle(GetTestEntityExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityExactlyOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}