// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetAllNoxTypesQuery() : IRequest<IQueryable<AllNoxTypeDto>>;

public partial class GetAllNoxTypesQueryHandler : QueryBase<IQueryable<AllNoxTypeDto>>, IRequestHandler<GetAllNoxTypesQuery, IQueryable<AllNoxTypeDto>>
{
    public  GetAllNoxTypesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<AllNoxTypeDto>> Handle(GetAllNoxTypesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<AllNoxTypeDto>)DataDbContext.AllNoxTypes
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}