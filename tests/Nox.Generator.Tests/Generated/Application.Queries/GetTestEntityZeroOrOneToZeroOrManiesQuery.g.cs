// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToZeroOrManiesQuery() : IRequest<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>;

internal partial class GetTestEntityZeroOrOneToZeroOrManiesQueryHandler: GetTestEntityZeroOrOneToZeroOrManiesQueryHandlerBase
{
    public GetTestEntityZeroOrOneToZeroOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrOneToZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>, IRequestHandler<GetTestEntityZeroOrOneToZeroOrManiesQuery, IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>
{
    public  GetTestEntityZeroOrOneToZeroOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>> Handle(GetTestEntityZeroOrOneToZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityZeroOrOneToZeroOrManyDto>)DataDbContext.TestEntityZeroOrOneToZeroOrManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}