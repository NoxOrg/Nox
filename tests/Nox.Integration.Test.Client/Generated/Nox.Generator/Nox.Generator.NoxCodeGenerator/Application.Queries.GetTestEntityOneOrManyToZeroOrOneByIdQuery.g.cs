// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityOneOrManyToZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOneOrManyToZeroOrOneDto>>;

internal partial class GetTestEntityOneOrManyToZeroOrOneByIdQueryHandler:GetTestEntityOneOrManyToZeroOrOneByIdQueryHandlerBase
{
    public  GetTestEntityOneOrManyToZeroOrOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOneOrManyToZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOneOrManyToZeroOrOneDto>>, IRequestHandler<GetTestEntityOneOrManyToZeroOrOneByIdQuery, IQueryable<TestEntityOneOrManyToZeroOrOneDto>>
{
    public  GetTestEntityOneOrManyToZeroOrOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToZeroOrOneDto>> Handle(GetTestEntityOneOrManyToZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityOneOrManyToZeroOrOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}