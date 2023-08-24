// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetAllNoxTypeByIdQuery(System.Int64 keyId, System.String keyTextId) : IRequest <AllNoxTypeDto?>;

public partial class GetAllNoxTypeByIdQueryHandler:  QueryBase<AllNoxTypeDto?>, IRequestHandler<GetAllNoxTypeByIdQuery, AllNoxTypeDto?>
{
    public  GetAllNoxTypeByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<AllNoxTypeDto?> Handle(GetAllNoxTypeByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.AllNoxTypes
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.TextId.Equals(request.keyTextId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}