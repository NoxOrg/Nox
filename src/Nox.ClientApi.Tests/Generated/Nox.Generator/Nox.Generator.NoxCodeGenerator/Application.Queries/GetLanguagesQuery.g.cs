// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetLanguagesQuery() : IRequest<IQueryable<LanguageDto>>;

internal partial class GetLanguagesQueryHandler: GetLanguagesQueryHandlerBase
{
    public GetLanguagesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetLanguagesQueryHandlerBase : QueryBase<IQueryable<LanguageDto>>, IRequestHandler<GetLanguagesQuery, IQueryable<LanguageDto>>
{
    public  GetLanguagesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<LanguageDto>> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<LanguageDto>)DataDbContext.Languages
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}