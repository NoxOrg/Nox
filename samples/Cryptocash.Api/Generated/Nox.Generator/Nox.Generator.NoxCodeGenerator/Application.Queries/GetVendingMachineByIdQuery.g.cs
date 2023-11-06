// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetVendingMachineByIdQuery(System.Guid keyId) : IRequest <IQueryable<VendingMachineDto>>;

internal partial class GetVendingMachineByIdQueryHandler:GetVendingMachineByIdQueryHandlerBase
{
    public  GetVendingMachineByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetVendingMachineByIdQueryHandlerBase:  QueryBase<IQueryable<VendingMachineDto>>, IRequestHandler<GetVendingMachineByIdQuery, IQueryable<VendingMachineDto>>
{
    public  GetVendingMachineByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<VendingMachineDto>> Handle(GetVendingMachineByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.VendingMachines
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}