// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityExactlyOneDto>>;

internal partial class GetSecondTestEntityExactlyOneByIdQueryHandler:GetSecondTestEntityExactlyOneByIdQueryHandlerBase
{
    public  GetSecondTestEntityExactlyOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityExactlyOneDto>>, IRequestHandler<GetSecondTestEntityExactlyOneByIdQuery, IQueryable<SecondTestEntityExactlyOneDto>>
{
    public  GetSecondTestEntityExactlyOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityExactlyOneDto>> Handle(GetSecondTestEntityExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.SecondTestEntityExactlyOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}