// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityZeroOrOneDto>>;

internal partial class GetSecondTestEntityZeroOrOneByIdQueryHandler:GetSecondTestEntityZeroOrOneByIdQueryHandlerBase
{
    public  GetSecondTestEntityZeroOrOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityZeroOrOneDto>>, IRequestHandler<GetSecondTestEntityZeroOrOneByIdQuery, IQueryable<SecondTestEntityZeroOrOneDto>>
{
    public  GetSecondTestEntityZeroOrOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityZeroOrOneDto>> Handle(GetSecondTestEntityZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.SecondTestEntityZeroOrOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}