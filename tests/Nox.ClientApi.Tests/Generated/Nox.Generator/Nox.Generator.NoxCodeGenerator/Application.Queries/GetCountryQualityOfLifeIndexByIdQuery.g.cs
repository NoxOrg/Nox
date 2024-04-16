// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record GetCountryQualityOfLifeIndexByIdQuery(System.Int64 keyCountryId, System.Int64 keyId) : IRequest <IQueryable<CountryQualityOfLifeIndexDto>>;

internal partial class GetCountryQualityOfLifeIndexByIdQueryHandler:GetCountryQualityOfLifeIndexByIdQueryHandlerBase
{
    public GetCountryQualityOfLifeIndexByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryQualityOfLifeIndexByIdQueryHandlerBase:  QueryBase<IQueryable<CountryQualityOfLifeIndexDto>>, IRequestHandler<GetCountryQualityOfLifeIndexByIdQuery, IQueryable<CountryQualityOfLifeIndexDto>>
{
    public  GetCountryQualityOfLifeIndexByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryQualityOfLifeIndexDto>> Handle(GetCountryQualityOfLifeIndexByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CountryQualityOfLifeIndexDto>()
            .Where(r =>
                r.CountryId.Equals(request.keyCountryId) &&
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}