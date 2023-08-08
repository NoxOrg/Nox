// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetStoreSecurityPasswordsByIdQuery(System.String Id) : IRequest<StoreSecurityPasswordsDto?>;

public class GetStoreSecurityPasswordsByIdQueryHandler: IRequestHandler<GetStoreSecurityPasswordsByIdQuery, StoreSecurityPasswordsDto?>
{
    public  GetStoreSecurityPasswordsByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<StoreSecurityPasswordsDto?> Handle(GetStoreSecurityPasswordsByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.StoreSecurityPasswords
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.Id) &&
                !(r.Deleted == true));
        return Task.FromResult(item);
    }
}