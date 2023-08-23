// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using IamApi.Application.Dto;
using IamApi.Infrastructure.Persistence;

namespace IamApi.Application.Queries;

public record GetUserIamsQuery() : IRequest<IQueryable<UserIamDto>>;

public class GetUserIamsQueryHandler : IRequestHandler<GetUserIamsQuery, IQueryable<UserIamDto>>
{
    public  GetUserIamsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<UserIamDto>> Handle(GetUserIamsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<UserIamDto>)DataDbContext.UserIams
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}