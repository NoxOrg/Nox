// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCommissionByIdQuery(System.Int64 keyId) : IRequest <IQueryable<CommissionDto>>;

internal partial class GetCommissionByIdQueryHandler:GetCommissionByIdQueryHandlerBase
{
    public  GetCommissionByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCommissionByIdQueryHandlerBase:  QueryBase<IQueryable<CommissionDto>>, IRequestHandler<GetCommissionByIdQuery, IQueryable<CommissionDto>>
{
    public  GetCommissionByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CommissionDto>> Handle(GetCommissionByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Commissions
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}