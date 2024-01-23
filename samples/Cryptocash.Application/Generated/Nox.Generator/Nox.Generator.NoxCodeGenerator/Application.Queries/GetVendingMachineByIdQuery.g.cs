// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetVendingMachineByIdQuery(System.Guid keyId) : IRequest <IQueryable<VendingMachineDto>>;

internal partial class GetVendingMachineByIdQueryHandler:GetVendingMachineByIdQueryHandlerBase
{
    public GetVendingMachineByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetVendingMachineByIdQueryHandlerBase:  QueryBase<IQueryable<VendingMachineDto>>, IRequestHandler<GetVendingMachineByIdQuery, IQueryable<VendingMachineDto>>
{
    public  GetVendingMachineByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<VendingMachineDto>> Handle(GetVendingMachineByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<VendingMachineDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}