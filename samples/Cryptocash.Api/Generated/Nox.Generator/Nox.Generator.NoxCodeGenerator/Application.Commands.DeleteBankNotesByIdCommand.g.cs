// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;

namespace Cryptocash.Application.Commands;

public record DeleteBankNotesByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteBankNotesByIdCommandHandler: CommandBase<DeleteBankNotesByIdCommand,BankNotes>, IRequestHandler<DeleteBankNotesByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteBankNotesByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteBankNotesByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<BankNotes,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.BankNotes.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}

		OnCompleted(entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}