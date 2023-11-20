// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityForUniqueConstraintsQuery() : IRequest<IQueryable<TestEntityForUniqueConstraintsDto>>;

internal partial class GetTestEntityForUniqueConstraintsQueryHandler: GetTestEntityForUniqueConstraintsQueryHandlerBase
{
    public GetTestEntityForUniqueConstraintsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityForUniqueConstraintsQueryHandlerBase : QueryBase<IQueryable<TestEntityForUniqueConstraintsDto>>, IRequestHandler<GetTestEntityForUniqueConstraintsQuery, IQueryable<TestEntityForUniqueConstraintsDto>>
{
    public  GetTestEntityForUniqueConstraintsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityForUniqueConstraintsDto>> Handle(GetTestEntityForUniqueConstraintsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityForUniqueConstraintsDto>)DataDbContext.TestEntityForUniqueConstraints
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}