// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using IamApi.Application.Dto;
using IamApi.Infrastructure.Persistence;

namespace IamApi.Application.Queries;

public record GetPhoneByIdQuery(System.String keyPhoneNumber) : IRequest <PhoneDto?>;

public partial class GetPhoneByIdQueryHandler:  QueryBase<PhoneDto?>, IRequestHandler<GetPhoneByIdQuery, PhoneDto?>
{
    public  GetPhoneByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<PhoneDto?> Handle(GetPhoneByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Phones
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.PhoneNumber.Equals(request.keyPhoneNumber) &&
                true
            );
        return Task.FromResult(OnResponse(item));
    }
}