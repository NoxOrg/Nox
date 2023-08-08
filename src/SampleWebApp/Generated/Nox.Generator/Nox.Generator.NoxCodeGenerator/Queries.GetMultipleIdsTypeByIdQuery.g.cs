// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetMultipleIdsTypeByIdQuery(System.String Id1, System.String Id2) : IRequest<MultipleIdsTypeDto?>;

public class GetMultipleIdsTypeByIdQueryHandler: IRequestHandler<GetMultipleIdsTypeByIdQuery, MultipleIdsTypeDto?>
{
    public  GetMultipleIdsTypeByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<MultipleIdsTypeDto?> Handle(GetMultipleIdsTypeByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.MultipleIdsTypes
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id1.Equals(request.Id1) &&
                r.Id2.Equals(request.Id2) &&
                !(r.Deleted == true));
        return Task.FromResult(item);
    }
}