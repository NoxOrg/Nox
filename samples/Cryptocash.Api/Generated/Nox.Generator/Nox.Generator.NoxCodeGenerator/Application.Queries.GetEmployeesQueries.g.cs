﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetEmployeesQuery() : IRequest<IQueryable<EmployeeDto>>;

public partial class GetEmployeesQueryHandler: GetEmployeesQueryHandlerBase
{
    public GetEmployeesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public partial class GetEmployeesQueryHandlerBase : QueryBase<IQueryable<EmployeeDto>>, IRequestHandler<GetEmployeesQuery, IQueryable<EmployeeDto>>
{
    public  GetEmployeesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<EmployeeDto>)DataDbContext.Employees
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}