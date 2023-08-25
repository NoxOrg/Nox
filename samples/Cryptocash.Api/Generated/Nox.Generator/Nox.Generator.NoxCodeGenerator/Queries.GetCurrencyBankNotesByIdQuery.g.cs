// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCurrencyBankNotesByIdQuery(System.Int64 keyId) : IRequest<CurrencyBankNotesDto?>;

public class GetCurrencyBankNotesByIdQueryHandler: IRequestHandler<GetCurrencyBankNotesByIdQuery, CurrencyBankNotesDto?>
{
    public  GetCurrencyBankNotesByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CurrencyBankNotesDto?> Handle(GetCurrencyBankNotesByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CurrencyBankNotes
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}