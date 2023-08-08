// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetAllNoxTypeByIdQuery(System.UInt64 key) : IRequest<AllNoxTypeDto?>;

public class GetAllNoxTypeByIdQueryHandler: IRequestHandler<GetAllNoxTypeByIdQuery, AllNoxTypeDto?>
{
    public  GetAllNoxTypeByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<AllNoxTypeDto?> Handle(GetAllNoxTypeByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.AllNoxTypes
            .AsNoTracking()
            .SingleOrDefault(r => !(r.Deleted == true) && r.Id.Equals(request.key));            
        return Task.FromResult(item);
    }
}