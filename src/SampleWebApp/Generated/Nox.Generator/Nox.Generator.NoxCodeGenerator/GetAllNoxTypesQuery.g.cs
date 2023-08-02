// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetAllNoxTypesQuery() : IRequest<IQueryable<OAllNoxType>>;

public class GetAllNoxTypesQueryHandler : IRequestHandler<GetAllNoxTypesQuery, IQueryable<OAllNoxType>>
{
    public  GetAllNoxTypesQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<OAllNoxType>> Handle(GetAllNoxTypesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<OAllNoxType>)DataDbContext.AllNoxTypes.Where(r => !(r.Deleted == true));
        return Task.FromResult(item);
    }
}