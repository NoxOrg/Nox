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

public record DeleteCustomerPaymentDetailsByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteCustomerPaymentDetailsByIdCommandHandler: CommandBase<DeleteCustomerPaymentDetailsByIdCommand,CustomerPaymentDetails>, IRequestHandler<DeleteCustomerPaymentDetailsByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteCustomerPaymentDetailsByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteCustomerPaymentDetailsByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CustomerPaymentDetails,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CustomerPaymentDetails.FindAsync(keyId);
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