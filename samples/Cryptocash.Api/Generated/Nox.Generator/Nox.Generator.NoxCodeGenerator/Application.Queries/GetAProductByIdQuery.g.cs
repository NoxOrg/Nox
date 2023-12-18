// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetAProductByIdQuery(System.Int64 keyId) : IRequest <IQueryable<AProductDto>>;

internal partial class GetAProductByIdQueryHandler:GetAProductByIdQueryHandlerBase
{
    public  GetAProductByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetAProductByIdQueryHandlerBase:  QueryBase<IQueryable<AProductDto>>, IRequestHandler<GetAProductByIdQuery, IQueryable<AProductDto>>
{
    public  GetAProductByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<AProductDto>> Handle(GetAProductByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.AProducts
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}