// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetTransactionByIdQuery(System.Int64 keyId) : IRequest <IQueryable<TransactionDto>>;

public partial class GetTransactionByIdQueryHandler:GetTransactionByIdQueryHandlerBase
{
    public  GetTransactionByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public partial class GetTransactionByIdQueryHandlerBase:  QueryBase<IQueryable<TransactionDto>>, IRequestHandler<GetTransactionByIdQuery, IQueryable<TransactionDto>>
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
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}