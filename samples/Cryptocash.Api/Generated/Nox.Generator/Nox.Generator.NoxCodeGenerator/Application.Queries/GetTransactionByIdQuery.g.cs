// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record Get TransactionByIdQuery(System.Int64 keyId) : IRequest <IQueryable<TransactionDto>>;

internal partial class GetTransactionByIdQueryHandler:GetTransactionByIdQueryHandlerBase
{
    public  GetTransactionByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTransactionByIdQueryHandlerBase:  QueryBase<IQueryable<TransactionDto>>, IRequestHandler<GetTransactionByIdQuery, IQueryable<TransactionDto>>
{
    public  GetTransactionByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TransactionDto>> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Transactions
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}