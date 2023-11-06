// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record Get EmployeesQuery() : IRequest<IQueryable<EmployeeDto>>;

internal partial class GetEmployeesQueryHandler: GetEmployeesQueryHandlerBase
{
    public GetEmployeesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetEmployeesQueryHandlerBase : QueryBase<IQueryable<EmployeeDto>>, IRequestHandler<GetEmployeesQuery, IQueryable<EmployeeDto>>
{
    public  GetEmployeesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<EmployeeDto>)DataDbContext.Employees
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}