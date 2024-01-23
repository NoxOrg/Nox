// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetTransactionsQuery() : IRequest<IQueryable<TransactionDto>>;

internal partial class GetTransactionsQueryHandler: GetTransactionsQueryHandlerBase
{
    public GetTransactionsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTransactionsQueryHandlerBase : QueryBase<IQueryable<TransactionDto>>, IRequestHandler<GetTransactionsQuery, IQueryable<TransactionDto>>
{
    public  GetTransactionsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TransactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TransactionDto>();
       return Task.FromResult(OnResponse(query));
    }
}