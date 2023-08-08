// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetMultipleIdsTypesQuery() : IRequest<IQueryable<MultipleIdsTypeDto>>;

public class GetMultipleIdsTypesQueryHandler : IRequestHandler<GetMultipleIdsTypesQuery, IQueryable<MultipleIdsTypeDto>>
{
    public  GetMultipleIdsTypesQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<MultipleIdsTypeDto>> Handle(GetMultipleIdsTypesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<MultipleIdsTypeDto>)DataDbContext.MultipleIdsTypes
            .Where(r => !(r.Deleted == true))
            .AsNoTracking();
        return Task.FromResult(item);
    }
}