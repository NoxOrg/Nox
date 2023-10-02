// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using VendingMachine = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public record DeleteVendingMachineByIdCommand(System.Guid keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteVendingMachineByIdCommandHandler:DeleteVendingMachineByIdCommandHandlerBase
{
	public DeleteVendingMachineByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution): base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteVendingMachineByIdCommandHandlerBase: CommandBase<DeleteVendingMachineByIdCommand,VendingMachine>, IRequestHandler<DeleteVendingMachineByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteVendingMachineByIdCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteVendingMachineByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.keyId);

		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null || entity.IsDeleted == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}