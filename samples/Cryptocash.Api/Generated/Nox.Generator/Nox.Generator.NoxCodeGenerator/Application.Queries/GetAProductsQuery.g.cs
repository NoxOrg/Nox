// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetAProductsQuery() : IRequest<IQueryable<AProductDto>>;

internal partial class GetAProductsQueryHandler: GetAProductsQueryHandlerBase
{
    public GetAProductsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetAProductsQueryHandlerBase : QueryBase<IQueryable<AProductDto>>, IRequestHandler<GetAProductsQuery, IQueryable<AProductDto>>
{
    public  GetAProductsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<AProductDto>> Handle(GetAProductsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<AProductDto>)DataDbContext.AProducts
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}