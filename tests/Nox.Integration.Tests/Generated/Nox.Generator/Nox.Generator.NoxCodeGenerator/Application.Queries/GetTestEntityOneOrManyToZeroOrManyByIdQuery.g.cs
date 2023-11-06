// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyToZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOneOrManyToZeroOrManyDto>>;

internal partial class GetTestEntityOneOrManyToZeroOrManyByIdQueryHandler:GetTestEntityOneOrManyToZeroOrManyByIdQueryHandlerBase
{
    public  GetTestEntityOneOrManyToZeroOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOneOrManyToZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOneOrManyToZeroOrManyDto>>, IRequestHandler<GetTestEntityOneOrManyToZeroOrManyByIdQuery, IQueryable<TestEntityOneOrManyToZeroOrManyDto>>
{
    public  GetTestEntityOneOrManyToZeroOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToZeroOrManyDto>> Handle(GetTestEntityOneOrManyToZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityOneOrManyToZeroOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}