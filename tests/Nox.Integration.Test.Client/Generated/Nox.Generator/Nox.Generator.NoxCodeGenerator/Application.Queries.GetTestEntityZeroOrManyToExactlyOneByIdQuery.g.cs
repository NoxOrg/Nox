// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityZeroOrManyToExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrManyToExactlyOneDto>>;

internal partial class GetTestEntityZeroOrManyToExactlyOneByIdQueryHandler:GetTestEntityZeroOrManyToExactlyOneByIdQueryHandlerBase
{
    public  GetTestEntityZeroOrManyToExactlyOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrManyToExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrManyToExactlyOneDto>>, IRequestHandler<GetTestEntityZeroOrManyToExactlyOneByIdQuery, IQueryable<TestEntityZeroOrManyToExactlyOneDto>>
{
    public  GetTestEntityZeroOrManyToExactlyOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToExactlyOneDto>> Handle(GetTestEntityZeroOrManyToExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityZeroOrManyToExactlyOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}