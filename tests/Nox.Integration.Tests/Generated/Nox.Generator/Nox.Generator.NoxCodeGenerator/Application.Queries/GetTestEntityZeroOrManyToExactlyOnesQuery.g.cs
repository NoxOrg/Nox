// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityZeroOrManyToExactlyOnesQuery() : IRequest<IQueryable<TestEntityZeroOrManyToExactlyOneDto>>;

internal partial class GetTestEntityZeroOrManyToExactlyOnesQueryHandler: GetTestEntityZeroOrManyToExactlyOnesQueryHandlerBase
{
    public GetTestEntityZeroOrManyToExactlyOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrManyToExactlyOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrManyToExactlyOneDto>>, IRequestHandler<GetTestEntityZeroOrManyToExactlyOnesQuery, IQueryable<TestEntityZeroOrManyToExactlyOneDto>>
{
    public  GetTestEntityZeroOrManyToExactlyOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToExactlyOneDto>> Handle(GetTestEntityZeroOrManyToExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityZeroOrManyToExactlyOneDto>)DataDbContext.TestEntityZeroOrManyToExactlyOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}