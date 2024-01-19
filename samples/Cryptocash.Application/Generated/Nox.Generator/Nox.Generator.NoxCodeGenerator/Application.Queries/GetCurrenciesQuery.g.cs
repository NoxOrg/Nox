// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetCurrenciesQuery() : IRequest<IQueryable<CurrencyDto>>;

internal partial class GetCurrenciesQueryHandler: GetCurrenciesQueryHandlerBase
{
    public GetCurrenciesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCurrenciesQueryHandlerBase : QueryBase<IQueryable<CurrencyDto>>, IRequestHandler<GetCurrenciesQuery, IQueryable<CurrencyDto>>
{
    public  GetCurrenciesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CurrencyDto>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<CurrencyDto>()
            .Include(e => e.BankNotes)
            .Include(e => e.ExchangeRates);
       return Task.FromResult(OnResponse(query));
    }
}