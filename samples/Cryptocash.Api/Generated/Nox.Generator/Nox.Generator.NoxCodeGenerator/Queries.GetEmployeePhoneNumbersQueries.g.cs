// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetEmployeePhoneNumbersQuery() : IRequest<IQueryable<EmployeePhoneNumberDto>>;

public class GetEmployeePhoneNumbersQueryHandler : IRequestHandler<GetEmployeePhoneNumbersQuery, IQueryable<EmployeePhoneNumberDto>>
{
    public  GetEmployeePhoneNumbersQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<EmployeePhoneNumberDto>> Handle(GetEmployeePhoneNumbersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<EmployeePhoneNumberDto>)DataDbContext.EmployeePhoneNumbers
            .AsNoTracking();
        return Task.FromResult(item);
    }
}