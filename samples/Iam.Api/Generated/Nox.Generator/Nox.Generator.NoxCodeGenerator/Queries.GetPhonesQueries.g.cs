// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using IamApi.Application.Dto;
using IamApi.Infrastructure.Persistence;

namespace IamApi.Application.Queries;

public record GetPhonesQuery() : IRequest<IQueryable<PhoneDto>>;

public partial class GetPhonesQueryHandler : QueryBase<IQueryable<PhoneDto>>, IRequestHandler<GetPhonesQuery, IQueryable<PhoneDto>>
{
    public  GetPhonesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<PhoneDto>> Handle(GetPhonesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<PhoneDto>)DataDbContext.Phones
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}