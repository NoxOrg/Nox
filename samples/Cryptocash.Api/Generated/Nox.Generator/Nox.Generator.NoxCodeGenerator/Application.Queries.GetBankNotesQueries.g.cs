// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetBankNotesQuery() : IRequest<IQueryable<BankNotesDto>>;

public partial class GetBankNotesQueryHandler : QueryBase<IQueryable<BankNotesDto>>, IRequestHandler<GetBankNotesQuery, IQueryable<BankNotesDto>>
{
    public  GetBankNotesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<BankNotesDto>> Handle(GetBankNotesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<BankNotesDto>)DataDbContext.BankNotes
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}