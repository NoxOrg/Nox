// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToOneOrManiesQuery() : IRequest<IQueryable<TestEntityZeroOrOneToOneOrManyDto>>;

internal partial class GetTestEntityZeroOrOneToOneOrManiesQueryHandler: GetTestEntityZeroOrOneToOneOrManiesQueryHandlerBase
{
    public GetTestEntityZeroOrOneToOneOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrOneToOneOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrOneToOneOrManyDto>>, IRequestHandler<GetTestEntityZeroOrOneToOneOrManiesQuery, IQueryable<TestEntityZeroOrOneToOneOrManyDto>>
{
    public  GetTestEntityZeroOrOneToOneOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToOneOrManyDto>> Handle(GetTestEntityZeroOrOneToOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityZeroOrOneToOneOrManyDto>)DataDbContext.TestEntityZeroOrOneToOneOrManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}