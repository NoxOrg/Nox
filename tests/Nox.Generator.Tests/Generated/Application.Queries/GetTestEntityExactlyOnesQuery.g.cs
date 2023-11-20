// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOnesQuery() : IRequest<IQueryable<TestEntityExactlyOneDto>>;

internal partial class GetTestEntityExactlyOnesQueryHandler: GetTestEntityExactlyOnesQueryHandlerBase
{
    public GetTestEntityExactlyOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityExactlyOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityExactlyOneDto>>, IRequestHandler<GetTestEntityExactlyOnesQuery, IQueryable<TestEntityExactlyOneDto>>
{
    public  GetTestEntityExactlyOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneDto>> Handle(GetTestEntityExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityExactlyOneDto>)DataDbContext.TestEntityExactlyOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}