// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityExactlyOneToZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityExactlyOneToZeroOrOneDto>>;

internal partial class GetTestEntityExactlyOneToZeroOrOneByIdQueryHandler:GetTestEntityExactlyOneToZeroOrOneByIdQueryHandlerBase
{
    public  GetTestEntityExactlyOneToZeroOrOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityExactlyOneToZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityExactlyOneToZeroOrOneDto>>, IRequestHandler<GetTestEntityExactlyOneToZeroOrOneByIdQuery, IQueryable<TestEntityExactlyOneToZeroOrOneDto>>
{
    public  GetTestEntityExactlyOneToZeroOrOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToZeroOrOneDto>> Handle(GetTestEntityExactlyOneToZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityExactlyOneToZeroOrOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}