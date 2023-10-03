// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetThirdTestEntityZeroOrManiesQuery() : IRequest<IQueryable<ThirdTestEntityZeroOrManyDto>>;

internal partial class GetThirdTestEntityZeroOrManiesQueryHandler: GetThirdTestEntityZeroOrManiesQueryHandlerBase
{
    public GetThirdTestEntityZeroOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetThirdTestEntityZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<ThirdTestEntityZeroOrManyDto>>, IRequestHandler<GetThirdTestEntityZeroOrManiesQuery, IQueryable<ThirdTestEntityZeroOrManyDto>>
{
    public  GetThirdTestEntityZeroOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ThirdTestEntityZeroOrManyDto>> Handle(GetThirdTestEntityZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ThirdTestEntityZeroOrManyDto>)DataDbContext.ThirdTestEntityZeroOrManies
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}