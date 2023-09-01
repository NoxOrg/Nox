// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCommissionByIdQuery(System.Int64 keyId) : IRequest <CommissionDto?>;

public partial class GetCommissionByIdQueryHandler:  QueryBase<CommissionDto?>, IRequestHandler<GetCommissionByIdQuery, CommissionDto?>
{
    public  GetCommissionByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CommissionDto?> Handle(GetCommissionByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Commissions
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}