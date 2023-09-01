// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetBankNotesByIdQuery(System.Int64 keyId) : IRequest <BankNotesDto?>;

public partial class GetBankNotesByIdQueryHandler:  QueryBase<BankNotesDto?>, IRequestHandler<GetBankNotesByIdQuery, BankNotesDto?>
{
    public  GetBankNotesByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<BankNotesDto?> Handle(GetBankNotesByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.BankNotes
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}