// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record Get CustomersQuery() : IRequest<IQueryable<CustomerDto>>;

internal partial class GetCustomersQueryHandler: GetCustomersQueryHandlerBase
{
    public GetCustomersQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCustomersQueryHandlerBase : QueryBase<IQueryable<CustomerDto>>, IRequestHandler<GetCustomersQuery, IQueryable<CustomerDto>>
{
    public  GetCustomersQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CustomerDto>)DataDbContext.Customers
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}