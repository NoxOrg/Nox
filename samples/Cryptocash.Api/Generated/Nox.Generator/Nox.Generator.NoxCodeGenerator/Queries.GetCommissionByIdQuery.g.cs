// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCommissionByIdQuery(System.Int64 keyId) : IRequest<CommissionDto?>;

public class GetCommissionByIdQueryHandler: IRequestHandler<GetCommissionByIdQuery, CommissionDto?>
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
        return Task.FromResult(item);
    }
}