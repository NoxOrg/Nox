// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCommissionsQuery() : IRequest<IQueryable<CommissionDto>>;

public class GetCommissionsQueryHandler : IRequestHandler<GetCommissionsQuery, IQueryable<CommissionDto>>
{
    public  GetCommissionsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CommissionDto>> Handle(GetCommissionsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CommissionDto>)DataDbContext.Commissions
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}