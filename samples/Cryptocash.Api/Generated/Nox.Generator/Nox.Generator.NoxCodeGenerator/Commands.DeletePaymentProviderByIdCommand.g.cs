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

public record DeletePaymentProviderByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeletePaymentProviderByIdCommandHandler: CommandBase<DeletePaymentProviderByIdCommand>, IRequestHandler<DeletePaymentProviderByIdCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public DeletePaymentProviderByIdCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeletePaymentProviderByIdCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<PaymentProvider,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}