// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetSecondTestEntityOneOrManiesQuery() : IRequest<IQueryable<SecondTestEntityOneOrManyDto>>;

internal partial class GetSecondTestEntityOneOrManiesQueryHandler: GetSecondTestEntityOneOrManiesQueryHandlerBase
{
    public GetSecondTestEntityOneOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityOneOrManiesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityOneOrManyDto>>, IRequestHandler<GetSecondTestEntityOneOrManiesQuery, IQueryable<SecondTestEntityOneOrManyDto>>
{
    public  GetSecondTestEntityOneOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityOneOrManyDto>> Handle(GetSecondTestEntityOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<SecondTestEntityOneOrManyDto>)DataDbContext.SecondTestEntityOneOrManies
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}