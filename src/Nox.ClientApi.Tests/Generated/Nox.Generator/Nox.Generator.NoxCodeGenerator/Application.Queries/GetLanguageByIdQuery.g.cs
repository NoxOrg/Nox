// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetLanguageByIdQuery(System.String keyId) : IRequest <IQueryable<LanguageDto>>;

internal partial class GetLanguageByIdQueryHandler:GetLanguageByIdQueryHandlerBase
{
    public  GetLanguageByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetLanguageByIdQueryHandlerBase:  QueryBase<IQueryable<LanguageDto>>, IRequestHandler<GetLanguageByIdQuery, IQueryable<LanguageDto>>
{
    public  GetLanguageByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<LanguageDto>> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Languages
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}