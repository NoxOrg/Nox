// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetAllNoxTypesQuery() : IRequest<IQueryable<AllNoxTypeDto>>;

public class GetAllNoxTypesQueryHandler : IRequestHandler<GetAllNoxTypesQuery, IQueryable<AllNoxTypeDto>>
{
    public  GetAllNoxTypesQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<AllNoxTypeDto>> Handle(GetAllNoxTypesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<AllNoxTypeDto>)DataDbContext.AllNoxTypes
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}