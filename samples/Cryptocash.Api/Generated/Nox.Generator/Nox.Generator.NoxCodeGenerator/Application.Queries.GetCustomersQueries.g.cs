// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCustomersQuery() : IRequest<IQueryable<CustomerDto>>;

public partial class GetCustomersQueryHandler: GetCustomersQueryHandlerBase
{
    public GetCustomersQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public partial class GetCustomersQueryHandlerBase : QueryBase<IQueryable<CustomerDto>>, IRequestHandler<GetCustomersQuery, IQueryable<CustomerDto>>
{
    public  GetCustomersQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CustomerDto>)DataDbContext.Customers
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}