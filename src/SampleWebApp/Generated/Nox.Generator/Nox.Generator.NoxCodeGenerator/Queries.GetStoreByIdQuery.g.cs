// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetStoreByIdQuery(System.String key) : IRequest<OStore?>;

public class GetStoreByIdQueryHandler: IRequestHandler<GetStoreByIdQuery, OStore?>
{
    public  GetStoreByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<OStore?> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Stores
            .AsNoTracking()
            .SingleOrDefault(r => !(r.Deleted == true) && r.Id.Equals(request.key));            
        return Task.FromResult(item);
    }
}