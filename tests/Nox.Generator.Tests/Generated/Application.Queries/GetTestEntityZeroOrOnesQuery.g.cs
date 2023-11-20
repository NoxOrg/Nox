// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOnesQuery() : IRequest<IQueryable<TestEntityZeroOrOneDto>>;

internal partial class GetTestEntityZeroOrOnesQueryHandler: GetTestEntityZeroOrOnesQueryHandlerBase
{
    public GetTestEntityZeroOrOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrOneDto>>, IRequestHandler<GetTestEntityZeroOrOnesQuery, IQueryable<TestEntityZeroOrOneDto>>
{
    public  GetTestEntityZeroOrOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneDto>> Handle(GetTestEntityZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityZeroOrOneDto>)DataDbContext.TestEntityZeroOrOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}