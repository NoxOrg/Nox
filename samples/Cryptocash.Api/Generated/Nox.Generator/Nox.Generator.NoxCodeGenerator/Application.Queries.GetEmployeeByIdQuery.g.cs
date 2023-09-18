// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetEmployeeByIdQuery(System.Int64 keyId) : IRequest <IQueryable<EmployeeDto>>;

public partial class GetEmployeeByIdQueryHandler:  QueryBase<IQueryable<EmployeeDto>>, IRequestHandler<GetEmployeeByIdQuery, IQueryable<EmployeeDto>>
{
    public  GetEmployeeByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Employees
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}