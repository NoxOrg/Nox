// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetVendingMachineByIdQuery(System.Guid keyId) : IRequest <IQueryable<VendingMachineDto>>;

public partial class GetVendingMachineByIdQueryHandler:  QueryBase<IQueryable<VendingMachineDto>>, IRequestHandler<GetVendingMachineByIdQuery, IQueryable<VendingMachineDto>>
{
    public  GetVendingMachineByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<VendingMachineDto>> Handle(GetVendingMachineByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.VendingMachines
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}