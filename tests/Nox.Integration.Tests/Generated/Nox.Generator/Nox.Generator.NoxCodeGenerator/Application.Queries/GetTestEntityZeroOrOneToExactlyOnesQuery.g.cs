// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToExactlyOnesQuery() : IRequest<IQueryable<TestEntityZeroOrOneToExactlyOneDto>>;

internal partial class GetTestEntityZeroOrOneToExactlyOnesQueryHandler: GetTestEntityZeroOrOneToExactlyOnesQueryHandlerBase
{
    public GetTestEntityZeroOrOneToExactlyOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrOneToExactlyOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrOneToExactlyOneDto>>, IRequestHandler<GetTestEntityZeroOrOneToExactlyOnesQuery, IQueryable<TestEntityZeroOrOneToExactlyOneDto>>
{
    public  GetTestEntityZeroOrOneToExactlyOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToExactlyOneDto>> Handle(GetTestEntityZeroOrOneToExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityZeroOrOneToExactlyOneDto>)DataDbContext.TestEntityZeroOrOneToExactlyOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}