// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetEmployeePhoneNumberByIdQuery(System.Int64 keyId) : IRequest<EmployeePhoneNumberDto?>;

public class GetEmployeePhoneNumberByIdQueryHandler: IRequestHandler<GetEmployeePhoneNumberByIdQuery, EmployeePhoneNumberDto?>
{
    public  GetEmployeePhoneNumberByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<EmployeePhoneNumberDto?> Handle(GetEmployeePhoneNumberByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.EmployeePhoneNumbers
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                true
            );
        return Task.FromResult(item);
    }
}