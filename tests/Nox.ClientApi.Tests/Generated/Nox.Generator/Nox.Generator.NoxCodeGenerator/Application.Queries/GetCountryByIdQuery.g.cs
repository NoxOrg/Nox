// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetCountryByIdQuery(System.Int64 keyId) : IRequest <IQueryable<CountryDto>>;

internal partial class GetCountryByIdQueryHandler:GetCountryByIdQueryHandlerBase
{
    public GetCountryByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryByIdQueryHandlerBase:  QueryBase<IQueryable<CountryDto>>, IRequestHandler<GetCountryByIdQuery, IQueryable<CountryDto>>
{
    public  GetCountryByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CountryDto >()
            .Include(e => e.CountryLocalNames)
            .Include(e => e.CountryBarCode)
            .Include(e => e.CountryTimeZones)
            .Include(e => e.Holidays)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}