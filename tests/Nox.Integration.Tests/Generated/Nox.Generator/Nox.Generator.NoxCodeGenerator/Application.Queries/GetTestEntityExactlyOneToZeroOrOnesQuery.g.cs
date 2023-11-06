// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOneToZeroOrOnesQuery() : IRequest<IQueryable<TestEntityExactlyOneToZeroOrOneDto>>;

internal partial class GetTestEntityExactlyOneToZeroOrOnesQueryHandler: GetTestEntityExactlyOneToZeroOrOnesQueryHandlerBase
{
    public GetTestEntityExactlyOneToZeroOrOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityExactlyOneToZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityExactlyOneToZeroOrOneDto>>, IRequestHandler<GetTestEntityExactlyOneToZeroOrOnesQuery, IQueryable<TestEntityExactlyOneToZeroOrOneDto>>
{
    public  GetTestEntityExactlyOneToZeroOrOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToZeroOrOneDto>> Handle(GetTestEntityExactlyOneToZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityExactlyOneToZeroOrOneDto>)DataDbContext.TestEntityExactlyOneToZeroOrOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}