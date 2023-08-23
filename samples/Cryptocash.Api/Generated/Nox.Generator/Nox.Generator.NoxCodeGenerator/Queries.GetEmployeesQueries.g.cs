// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetEmployeesQuery() : IRequest<IQueryable<EmployeeDto>>;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IQueryable<EmployeeDto>>
{
    public  GetEmployeesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<EmployeeDto>)DataDbContext.Employees
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}