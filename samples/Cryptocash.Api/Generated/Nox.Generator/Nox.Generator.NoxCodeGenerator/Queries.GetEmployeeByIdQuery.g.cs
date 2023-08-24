// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetEmployeeByIdQuery(System.Int64 keyId) : IRequest <EmployeeDto?>;

public partial class GetEmployeeByIdQueryHandler:  QueryBase<EmployeeDto?>, IRequestHandler<GetEmployeeByIdQuery, EmployeeDto?>
{
    public  GetEmployeeByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<EmployeeDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Employees
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}