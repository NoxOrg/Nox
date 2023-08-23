// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using IamApi.Application.Dto;
using IamApi.Infrastructure.Persistence;

namespace IamApi.Application.Queries;

public record GetApplicationIAMsQuery() : IRequest<IQueryable<ApplicationIAMDto>>;

public class GetApplicationIAMsQueryHandler : IRequestHandler<GetApplicationIAMsQuery, IQueryable<ApplicationIAMDto>>
{
    public  GetApplicationIAMsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<ApplicationIAMDto>> Handle(GetApplicationIAMsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ApplicationIAMDto>)DataDbContext.ApplicationIAMs
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}