// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record  GetWorkplaceTranslationsByIdQuery(System.UInt32 keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<WorkplaceLocalizedDto>>;

internal partial class GetWorkplaceTranslationsByIdQueryHandler:GetWorkplaceTranslationsByIdQueryHandlerBase
{
    public  GetWorkplaceTranslationsByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetWorkplaceTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<WorkplaceLocalizedDto>>, IRequestHandler<GetWorkplaceTranslationsByIdQuery, IQueryable<WorkplaceLocalizedDto>>
{
    public  GetWorkplaceTranslationsByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<WorkplaceLocalizedDto>> Handle(GetWorkplaceTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.WorkplacesLocalized
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}