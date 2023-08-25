﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCurrencyBankNotesQuery() : IRequest<IQueryable<CurrencyBankNotesDto>>;

public partial class GetCurrencyBankNotesQueryHandler : QueryBase<IQueryable<CurrencyBankNotesDto>>, IRequestHandler<GetCurrencyBankNotesQuery, IQueryable<CurrencyBankNotesDto>>
{
    public  GetCurrencyBankNotesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CurrencyBankNotesDto>> Handle(GetCurrencyBankNotesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CurrencyBankNotesDto>)DataDbContext.CurrencyBankNotes
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}