// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityExactlyOneToZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityExactlyOneToZeroOrManyDto>>;

internal partial class GetTestEntityExactlyOneToZeroOrManyByIdQueryHandler:GetTestEntityExactlyOneToZeroOrManyByIdQueryHandlerBase
{
    public  GetTestEntityExactlyOneToZeroOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityExactlyOneToZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityExactlyOneToZeroOrManyDto>>, IRequestHandler<GetTestEntityExactlyOneToZeroOrManyByIdQuery, IQueryable<TestEntityExactlyOneToZeroOrManyDto>>
{
    public  GetTestEntityExactlyOneToZeroOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToZeroOrManyDto>> Handle(GetTestEntityExactlyOneToZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityExactlyOneToZeroOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}