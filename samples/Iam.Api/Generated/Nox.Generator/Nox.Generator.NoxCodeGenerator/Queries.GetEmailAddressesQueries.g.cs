// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using IamApi.Application.Dto;
using IamApi.Infrastructure.Persistence;

namespace IamApi.Application.Queries;

public record GetEmailAddressesQuery() : IRequest<IQueryable<EmailAddressDto>>;

public partial class GetEmailAddressesQueryHandler : QueryBase<IQueryable<EmailAddressDto>>, IRequestHandler<GetEmailAddressesQuery, IQueryable<EmailAddressDto>>
{
    public  GetEmailAddressesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<EmailAddressDto>> Handle(GetEmailAddressesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<EmailAddressDto>)DataDbContext.EmailAddresses
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}