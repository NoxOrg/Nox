// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrManyDto>>;

internal partial class GetTestEntityZeroOrManyByIdQueryHandler:GetTestEntityZeroOrManyByIdQueryHandlerBase
{
    public  GetTestEntityZeroOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrManyDto>>, IRequestHandler<GetTestEntityZeroOrManyByIdQuery, IQueryable<TestEntityZeroOrManyDto>>
{
    public  GetTestEntityZeroOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyDto>> Handle(GetTestEntityZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityZeroOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}