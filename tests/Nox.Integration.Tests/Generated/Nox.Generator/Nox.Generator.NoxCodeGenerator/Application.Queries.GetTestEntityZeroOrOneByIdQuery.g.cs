// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrOneDto>>;

internal partial class GetTestEntityZeroOrOneByIdQueryHandler:GetTestEntityZeroOrOneByIdQueryHandlerBase
{
    public  GetTestEntityZeroOrOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrOneDto>>, IRequestHandler<GetTestEntityZeroOrOneByIdQuery, IQueryable<TestEntityZeroOrOneDto>>
{
    public  GetTestEntityZeroOrOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneDto>> Handle(GetTestEntityZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityZeroOrOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}