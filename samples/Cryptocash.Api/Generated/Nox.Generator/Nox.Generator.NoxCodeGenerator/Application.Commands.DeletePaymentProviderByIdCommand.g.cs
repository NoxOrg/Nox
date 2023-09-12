// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using PaymentProvider = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public record DeletePaymentProviderByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeletePaymentProviderByIdCommandHandler: CommandBase<DeletePaymentProviderByIdCommand,PaymentProvider>, IRequestHandler<DeletePaymentProviderByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeletePaymentProviderByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeletePaymentProviderByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentProvider,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}

		OnCompleted(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}