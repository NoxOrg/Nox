// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;
public partial record GetCountriesContinentsQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.CountryContinentDto>>;

internal partial class GetCountriesContinentsQueryHandler: GetCountriesContinentsQueryHandlerBase
{
    public GetCountriesContinentsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountriesContinentsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.CountryContinentDto>>, IRequestHandler<GetCountriesContinentsQuery, IQueryable<DtoNameSpace.CountryContinentDto>>
{
    public  GetCountriesContinentsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.CountryContinentDto>> Handle(GetCountriesContinentsQuery request, CancellationToken cancellationToken)
    {
        {
            var cultureCode = request.cultureCode.Value;
            IQueryable<DtoNameSpace.CountryContinentDto> queryBuilder =
            from enumValues in ReadOnlyRepository.Query<DtoNameSpace.CountryContinentDto>()
            from enumLocalized in ReadOnlyRepository.Query<DtoNameSpace.CountryContinentLocalizedDto>()
                .Where(l => enumValues.Id == l.Id && l.CultureCode == cultureCode).DefaultIfEmpty()
            select new DtoNameSpace.CountryContinentDto()
            {
                Id = enumValues.Id,
                Name = enumLocalized.Name ?? "[" + enumValues.Name + "]",
            };
            return Task.FromResult(OnResponse(queryBuilder));
        }
    }
}