// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetThirdTestEntityExactlyOnesQuery() : IRequest<IQueryable<ThirdTestEntityExactlyOneDto>>;

internal partial class GetThirdTestEntityExactlyOnesQueryHandler: GetThirdTestEntityExactlyOnesQueryHandlerBase
{
    public GetThirdTestEntityExactlyOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetThirdTestEntityExactlyOnesQueryHandlerBase : QueryBase<IQueryable<ThirdTestEntityExactlyOneDto>>, IRequestHandler<GetThirdTestEntityExactlyOnesQuery, IQueryable<ThirdTestEntityExactlyOneDto>>
{
    public  GetThirdTestEntityExactlyOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ThirdTestEntityExactlyOneDto>> Handle(GetThirdTestEntityExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ThirdTestEntityExactlyOneDto>)DataDbContext.ThirdTestEntityExactlyOnes
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}