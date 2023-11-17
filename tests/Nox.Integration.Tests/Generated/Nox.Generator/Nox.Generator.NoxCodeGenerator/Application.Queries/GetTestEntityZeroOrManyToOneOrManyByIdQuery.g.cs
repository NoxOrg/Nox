// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManyToOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrManyToOneOrManyDto>>;

internal partial class GetTestEntityZeroOrManyToOneOrManyByIdQueryHandler:GetTestEntityZeroOrManyToOneOrManyByIdQueryHandlerBase
{
    public  GetTestEntityZeroOrManyToOneOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrManyToOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrManyToOneOrManyDto>>, IRequestHandler<GetTestEntityZeroOrManyToOneOrManyByIdQuery, IQueryable<TestEntityZeroOrManyToOneOrManyDto>>
{
    public  GetTestEntityZeroOrManyToOneOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToOneOrManyDto>> Handle(GetTestEntityZeroOrManyToOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityZeroOrManyToOneOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}