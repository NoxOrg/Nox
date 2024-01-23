// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetTransactionByIdQuery(System.Guid keyId) : IRequest <IQueryable<TransactionDto>>;

internal partial class GetTransactionByIdQueryHandler:GetTransactionByIdQueryHandlerBase
{
    public GetTransactionByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTransactionByIdQueryHandlerBase:  QueryBase<IQueryable<TransactionDto>>, IRequestHandler<GetTransactionByIdQuery, IQueryable<TransactionDto>>
{
    public  GetTransactionByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TransactionDto>> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TransactionDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}