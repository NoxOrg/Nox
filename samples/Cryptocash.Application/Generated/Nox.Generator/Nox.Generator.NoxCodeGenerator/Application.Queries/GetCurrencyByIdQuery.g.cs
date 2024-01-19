// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetCurrencyByIdQuery(System.String keyId) : IRequest <IQueryable<CurrencyDto>>;

internal partial class GetCurrencyByIdQueryHandler:GetCurrencyByIdQueryHandlerBase
{
    public GetCurrencyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCurrencyByIdQueryHandlerBase:  QueryBase<IQueryable<CurrencyDto>>, IRequestHandler<GetCurrencyByIdQuery, IQueryable<CurrencyDto>>
{
    public  GetCurrencyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CurrencyDto>> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CurrencyDto >()
            .Include(e => e.BankNotes)
            .Include(e => e.ExchangeRates)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}