// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Commands;

public record DeleteVendingMachineOrderByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteVendingMachineOrderByIdCommandHandler: CommandBase<DeleteVendingMachineOrderByIdCommand,VendingMachineOrder>, IRequestHandler<DeleteVendingMachineOrderByIdCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public DeleteVendingMachineOrderByIdCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteVendingMachineOrderByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachineOrder,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.VendingMachineOrders.FindAsync(keyId);
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