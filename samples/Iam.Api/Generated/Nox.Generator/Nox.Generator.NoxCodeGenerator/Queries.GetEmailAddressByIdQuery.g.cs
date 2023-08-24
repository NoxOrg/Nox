// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using IamApi.Application.Dto;
using IamApi.Infrastructure.Persistence;

namespace IamApi.Application.Queries;

public record GetEmailAddressByIdQuery(System.String keyEmail) : IRequest <EmailAddressDto?>;

public partial class GetEmailAddressByIdQueryHandler:  QueryBase<EmailAddressDto?>, IRequestHandler<GetEmailAddressByIdQuery, EmailAddressDto?>
{
    public  GetEmailAddressByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<EmailAddressDto?> Handle(GetEmailAddressByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.EmailAddresses
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Email.Equals(request.keyEmail) &&
                true
            );
        return Task.FromResult(OnResponse(item));
    }
}