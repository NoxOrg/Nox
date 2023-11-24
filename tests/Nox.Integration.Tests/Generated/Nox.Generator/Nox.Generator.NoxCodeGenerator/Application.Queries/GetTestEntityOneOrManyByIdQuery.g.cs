// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOneOrManyDto>>;

internal partial class GetTestEntityOneOrManyByIdQueryHandler:GetTestEntityOneOrManyByIdQueryHandlerBase
{
    public  GetTestEntityOneOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOneOrManyDto>>, IRequestHandler<GetTestEntityOneOrManyByIdQuery, IQueryable<TestEntityOneOrManyDto>>
{
    public  GetTestEntityOneOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyDto>> Handle(GetTestEntityOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityOneOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}