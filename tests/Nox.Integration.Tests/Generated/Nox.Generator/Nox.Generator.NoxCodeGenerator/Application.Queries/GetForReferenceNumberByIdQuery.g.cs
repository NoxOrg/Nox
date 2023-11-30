// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetForReferenceNumberByIdQuery(System.String keyId) : IRequest <IQueryable<ForReferenceNumberDto>>;

internal partial class GetForReferenceNumberByIdQueryHandler:GetForReferenceNumberByIdQueryHandlerBase
{
    public  GetForReferenceNumberByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetForReferenceNumberByIdQueryHandlerBase:  QueryBase<IQueryable<ForReferenceNumberDto>>, IRequestHandler<GetForReferenceNumberByIdQuery, IQueryable<ForReferenceNumberDto>>
{
    public  GetForReferenceNumberByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ForReferenceNumberDto>> Handle(GetForReferenceNumberByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.ForReferenceNumbers
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}