// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityOneOrManiesQuery() : IRequest<IQueryable<ThirdTestEntityOneOrManyDto>>;

internal partial class GetThirdTestEntityOneOrManiesQueryHandler: GetThirdTestEntityOneOrManiesQueryHandlerBase
{
    public GetThirdTestEntityOneOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetThirdTestEntityOneOrManiesQueryHandlerBase : QueryBase<IQueryable<ThirdTestEntityOneOrManyDto>>, IRequestHandler<GetThirdTestEntityOneOrManiesQuery, IQueryable<ThirdTestEntityOneOrManyDto>>
{
    public  GetThirdTestEntityOneOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ThirdTestEntityOneOrManyDto>> Handle(GetThirdTestEntityOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ThirdTestEntityOneOrManyDto>)DataDbContext.ThirdTestEntityOneOrManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}