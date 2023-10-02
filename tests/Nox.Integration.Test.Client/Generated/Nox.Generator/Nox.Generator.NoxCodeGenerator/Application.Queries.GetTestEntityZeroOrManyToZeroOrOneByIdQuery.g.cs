// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityZeroOrManyToZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>;

internal partial class GetTestEntityZeroOrManyToZeroOrOneByIdQueryHandler:GetTestEntityZeroOrManyToZeroOrOneByIdQueryHandlerBase
{
    public  GetTestEntityZeroOrManyToZeroOrOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrManyToZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>, IRequestHandler<GetTestEntityZeroOrManyToZeroOrOneByIdQuery, IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>
{
    public  GetTestEntityZeroOrManyToZeroOrOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>> Handle(GetTestEntityZeroOrManyToZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityZeroOrManyToZeroOrOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}