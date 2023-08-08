// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetAllNoxTypeByIdQuery(System.UInt64 Id) : IRequest<AllNoxTypeDto?>;

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
            .SingleOrDefault(r =>
                r.Id.Equals(request.Id) &&
                !(r.Deleted == true));
        return Task.FromResult(item);
    }
}