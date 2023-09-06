// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using PaymentDetail = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public record DeletePaymentDetailByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeletePaymentDetailByIdCommandHandler: CommandBase<DeletePaymentDetailByIdCommand,PaymentDetail>, IRequestHandler<DeletePaymentDetailByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeletePaymentDetailByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeletePaymentDetailByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentDetail,AutoNumber>("Id", request.keyId);

		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
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