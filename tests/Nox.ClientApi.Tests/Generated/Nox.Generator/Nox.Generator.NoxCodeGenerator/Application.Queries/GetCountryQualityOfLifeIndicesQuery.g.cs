// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record GetCountryQualityOfLifeIndicesQuery() : IRequest<IQueryable<CountryQualityOfLifeIndexDto>>;

internal partial class GetCountryQualityOfLifeIndicesQueryHandler: GetCountryQualityOfLifeIndicesQueryHandlerBase
{
    public GetCountryQualityOfLifeIndicesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryQualityOfLifeIndicesQueryHandlerBase : QueryBase<IQueryable<CountryQualityOfLifeIndexDto>>, IRequestHandler<GetCountryQualityOfLifeIndicesQuery, IQueryable<CountryQualityOfLifeIndexDto>>
{
    public  GetCountryQualityOfLifeIndicesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryQualityOfLifeIndexDto>> Handle(GetCountryQualityOfLifeIndicesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<CountryQualityOfLifeIndexDto>();
       return Task.FromResult(OnResponse(query));
    }
}