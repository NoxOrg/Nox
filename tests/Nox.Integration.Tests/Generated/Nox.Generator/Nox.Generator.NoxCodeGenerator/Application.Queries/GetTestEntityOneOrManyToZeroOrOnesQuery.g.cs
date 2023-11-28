// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyToZeroOrOnesQuery() : IRequest<IQueryable<TestEntityOneOrManyToZeroOrOneDto>>;

internal partial class GetTestEntityOneOrManyToZeroOrOnesQueryHandler: GetTestEntityOneOrManyToZeroOrOnesQueryHandlerBase
{
    public GetTestEntityOneOrManyToZeroOrOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOneOrManyToZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityOneOrManyToZeroOrOneDto>>, IRequestHandler<GetTestEntityOneOrManyToZeroOrOnesQuery, IQueryable<TestEntityOneOrManyToZeroOrOneDto>>
{
    public  GetTestEntityOneOrManyToZeroOrOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToZeroOrOneDto>> Handle(GetTestEntityOneOrManyToZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityOneOrManyToZeroOrOneDto>)DataDbContext.TestEntityOneOrManyToZeroOrOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}