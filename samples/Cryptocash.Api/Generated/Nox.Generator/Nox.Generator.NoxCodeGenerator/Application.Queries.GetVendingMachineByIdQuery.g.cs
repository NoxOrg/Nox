// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetVendingMachineByIdQuery(System.Guid keyId) : IRequest <VendingMachineDto?>;

public partial class GetVendingMachineByIdQueryHandler:  QueryBase<VendingMachineDto?>, IRequestHandler<GetVendingMachineByIdQuery, VendingMachineDto?>
{
    public  GetVendingMachineByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<VendingMachineDto?> Handle(GetVendingMachineByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.VendingMachines
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}