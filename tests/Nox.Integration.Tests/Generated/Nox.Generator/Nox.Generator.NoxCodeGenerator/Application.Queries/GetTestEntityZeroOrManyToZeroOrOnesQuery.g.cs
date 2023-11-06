// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManyToZeroOrOnesQuery() : IRequest<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>;

internal partial class GetTestEntityZeroOrManyToZeroOrOnesQueryHandler: GetTestEntityZeroOrManyToZeroOrOnesQueryHandlerBase
{
    public GetTestEntityZeroOrManyToZeroOrOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrManyToZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>, IRequestHandler<GetTestEntityZeroOrManyToZeroOrOnesQuery, IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>
{
    public  GetTestEntityZeroOrManyToZeroOrOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>> Handle(GetTestEntityZeroOrManyToZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityZeroOrManyToZeroOrOneDto>)DataDbContext.TestEntityZeroOrManyToZeroOrOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}