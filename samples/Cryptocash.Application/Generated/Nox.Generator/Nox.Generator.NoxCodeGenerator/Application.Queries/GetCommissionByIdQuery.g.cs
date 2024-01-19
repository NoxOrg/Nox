// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetCommissionByIdQuery(System.Guid keyId) : IRequest <IQueryable<CommissionDto>>;

internal partial class GetCommissionByIdQueryHandler:GetCommissionByIdQueryHandlerBase
{
    public GetCommissionByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCommissionByIdQueryHandlerBase:  QueryBase<IQueryable<CommissionDto>>, IRequestHandler<GetCommissionByIdQuery, IQueryable<CommissionDto>>
{
    public  GetCommissionByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CommissionDto>> Handle(GetCommissionByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CommissionDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}