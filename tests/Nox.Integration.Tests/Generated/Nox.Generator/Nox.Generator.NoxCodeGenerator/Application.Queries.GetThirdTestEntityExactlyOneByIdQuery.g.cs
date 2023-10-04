// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetThirdTestEntityExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<ThirdTestEntityExactlyOneDto>>;

internal partial class GetThirdTestEntityExactlyOneByIdQueryHandler:GetThirdTestEntityExactlyOneByIdQueryHandlerBase
{
    public  GetThirdTestEntityExactlyOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetThirdTestEntityExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<ThirdTestEntityExactlyOneDto>>, IRequestHandler<GetThirdTestEntityExactlyOneByIdQuery, IQueryable<ThirdTestEntityExactlyOneDto>>
{
    public  GetThirdTestEntityExactlyOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ThirdTestEntityExactlyOneDto>> Handle(GetThirdTestEntityExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.ThirdTestEntityExactlyOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}