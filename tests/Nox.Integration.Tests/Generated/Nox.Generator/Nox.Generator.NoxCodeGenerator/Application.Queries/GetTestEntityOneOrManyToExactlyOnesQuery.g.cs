// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyToExactlyOnesQuery() : IRequest<IQueryable<TestEntityOneOrManyToExactlyOneDto>>;

internal partial class GetTestEntityOneOrManyToExactlyOnesQueryHandler: GetTestEntityOneOrManyToExactlyOnesQueryHandlerBase
{
    public GetTestEntityOneOrManyToExactlyOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOneOrManyToExactlyOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityOneOrManyToExactlyOneDto>>, IRequestHandler<GetTestEntityOneOrManyToExactlyOnesQuery, IQueryable<TestEntityOneOrManyToExactlyOneDto>>
{
    public  GetTestEntityOneOrManyToExactlyOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToExactlyOneDto>> Handle(GetTestEntityOneOrManyToExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityOneOrManyToExactlyOneDto>)DataDbContext.TestEntityOneOrManyToExactlyOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}