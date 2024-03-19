// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Nox.Exceptions;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public record  GetCountryLocalNameTranslationsByParentIdQuery(System.Int64 CountryId,System.Int64 CountryLocalNameId) : IRequest <IQueryable<CountryLocalNameLocalizedDto>>;

internal partial class GetCountryLocalNameTranslationsByParentIdQueryHandler:GetCountryLocalNameTranslationsByParentIdQueryHandlerBase
{
    public  GetCountryLocalNameTranslationsByParentIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryLocalNameTranslationsByParentIdQueryHandlerBase:  QueryBase<IQueryable<CountryLocalNameLocalizedDto>>, IRequestHandler<GetCountryLocalNameTranslationsByParentIdQuery, IQueryable<CountryLocalNameLocalizedDto>>
{
    public  GetCountryLocalNameTranslationsByParentIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual async Task<IQueryable<CountryLocalNameLocalizedDto>> Handle(GetCountryLocalNameTranslationsByParentIdQuery request, CancellationToken cancellationToken)
    {    
        var parentEntity = await ReadOnlyRepository.Query<CountryDto>()
                    .Include(e => e.CountryLocalNames)
                    .Where(r =>
                            r.Id.Equals(request.CountryId)
                            && r.CountryLocalNames.Any(e => e.Id.Equals(request.CountryLocalNameId))
                    ).FirstOrDefaultAsync();
        if (parentEntity is null)
        {
            EntityNotFoundException.ThrowIfNull(parentEntity, "Country", request.CountryId.ToString());
        }
        
        var query = ReadOnlyRepository.Query<CountryLocalNameLocalizedDto>()
           .Where(r =>
                r.Id.Equals(request.CountryLocalNameId) 
           );
           
        
        return OnResponse(query);
        
    }
}