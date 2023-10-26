// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetCountriesContinentsQuery() : IRequest<IQueryable<DtoNameSpace.CountryContinentDto>>;

internal partial class GetCountriesContinentsQueryHandler: GetCountriesContinentsQueryHandlerBase
{
    public GetCountriesContinentsQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class GetCountriesContinentsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.CountryContinentDto>>, IRequestHandler<GetCountriesContinentsQuery, IQueryable<DtoNameSpace.CountryContinentDto>>
{
    public  GetCountriesContinentsQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.CountryContinentDto>> Handle(GetCountriesContinentsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<DtoNameSpace.CountryContinentDto>)DataDbContext.CountriesContinents
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}