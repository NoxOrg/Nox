// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<ThirdTestEntityZeroOrManyDto>>;

internal partial class GetThirdTestEntityZeroOrManyByIdQueryHandler:GetThirdTestEntityZeroOrManyByIdQueryHandlerBase
{
    public  GetThirdTestEntityZeroOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetThirdTestEntityZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<ThirdTestEntityZeroOrManyDto>>, IRequestHandler<GetThirdTestEntityZeroOrManyByIdQuery, IQueryable<ThirdTestEntityZeroOrManyDto>>
{
    public  GetThirdTestEntityZeroOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ThirdTestEntityZeroOrManyDto>> Handle(GetThirdTestEntityZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.ThirdTestEntityZeroOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}