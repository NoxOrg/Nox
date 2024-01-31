// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Queries;

public partial record GetVendingMachinesQuery() : IRequest<IQueryable<VendingMachineDto>>;

internal partial class GetVendingMachinesQueryHandler: GetVendingMachinesQueryHandlerBase
{
    public GetVendingMachinesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetVendingMachinesQueryHandlerBase : QueryBase<IQueryable<VendingMachineDto>>, IRequestHandler<GetVendingMachinesQuery, IQueryable<VendingMachineDto>>
{
    public  GetVendingMachinesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<VendingMachineDto>> Handle(GetVendingMachinesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<VendingMachineDto>();
       return Task.FromResult(OnResponse(query));
    }
}