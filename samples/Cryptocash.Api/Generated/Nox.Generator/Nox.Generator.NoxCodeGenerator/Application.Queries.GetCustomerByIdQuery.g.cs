// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCustomerByIdQuery(System.Int64 keyId) : IRequest <IQueryable<CustomerDto>>;

public partial class GetCustomerByIdQueryHandler:  QueryBase<IQueryable<CustomerDto>>, IRequestHandler<GetCustomerByIdQuery, IQueryable<CustomerDto>>
{
    public  GetCustomerByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Customers
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}