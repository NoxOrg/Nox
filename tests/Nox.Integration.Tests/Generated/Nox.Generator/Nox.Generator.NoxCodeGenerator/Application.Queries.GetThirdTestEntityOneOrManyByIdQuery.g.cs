// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetThirdTestEntityOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<ThirdTestEntityOneOrManyDto>>;

internal partial class GetThirdTestEntityOneOrManyByIdQueryHandler:GetThirdTestEntityOneOrManyByIdQueryHandlerBase
{
    public  GetThirdTestEntityOneOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetThirdTestEntityOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<ThirdTestEntityOneOrManyDto>>, IRequestHandler<GetThirdTestEntityOneOrManyByIdQuery, IQueryable<ThirdTestEntityOneOrManyDto>>
{
    public  GetThirdTestEntityOneOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ThirdTestEntityOneOrManyDto>> Handle(GetThirdTestEntityOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.ThirdTestEntityOneOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}