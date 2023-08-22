// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Presentation.Api.OData;

namespace CryptocashApi.Application.Queries;

public record GetEmployeeByIdQuery(System.Int64 keyId) : IRequest<EmployeeDto?>;

public class GetEmployeeByIdQueryHandler: IRequestHandler<GetEmployeeByIdQuery, EmployeeDto?>
{
    public  GetEmployeeByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<EmployeeDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Employees
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}