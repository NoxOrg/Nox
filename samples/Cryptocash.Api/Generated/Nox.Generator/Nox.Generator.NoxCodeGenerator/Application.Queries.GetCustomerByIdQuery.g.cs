// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCustomerByIdQuery(System.Int64 keyId) : IRequest <IQueryable<CustomerDto>>;

public partial class GetCustomerByIdQueryHandler:GetCustomerByIdQueryHandlerBase
{
    public  GetCustomerByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public partial class GetCustomerByIdQueryHandlerBase:  QueryBase<IQueryable<CustomerDto>>, IRequestHandler<GetCustomerByIdQuery, IQueryable<CustomerDto>>
{
    public  GetCustomerByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Customers
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}