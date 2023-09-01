// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using CustomerTransaction = Cryptocash.Domain.CustomerTransaction;

namespace Cryptocash.Application.Commands;

public record DeleteCustomerTransactionByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteCustomerTransactionByIdCommandHandler: CommandBase<DeleteCustomerTransactionByIdCommand,CustomerTransaction>, IRequestHandler<DeleteCustomerTransactionByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteCustomerTransactionByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteCustomerTransactionByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CustomerTransaction,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CustomerTransactions.FindAsync(keyId);
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