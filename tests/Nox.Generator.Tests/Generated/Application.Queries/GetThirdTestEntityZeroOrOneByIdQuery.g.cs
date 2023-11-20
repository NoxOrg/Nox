// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<ThirdTestEntityZeroOrOneDto>>;

internal partial class GetThirdTestEntityZeroOrOneByIdQueryHandler:GetThirdTestEntityZeroOrOneByIdQueryHandlerBase
{
    public  GetThirdTestEntityZeroOrOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetThirdTestEntityZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<ThirdTestEntityZeroOrOneDto>>, IRequestHandler<GetThirdTestEntityZeroOrOneByIdQuery, IQueryable<ThirdTestEntityZeroOrOneDto>>
{
    public  GetThirdTestEntityZeroOrOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ThirdTestEntityZeroOrOneDto>> Handle(GetThirdTestEntityZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.ThirdTestEntityZeroOrOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}