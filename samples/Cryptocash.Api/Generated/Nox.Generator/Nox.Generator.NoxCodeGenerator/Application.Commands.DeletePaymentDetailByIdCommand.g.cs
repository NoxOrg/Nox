// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public record DeletePaymentDetailByIdCommand(System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeletePaymentDetailByIdCommandHandler : DeletePaymentDetailByIdCommandHandlerBase
{
	public DeletePaymentDetailByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution): base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeletePaymentDetailByIdCommandHandlerBase : CommandBase<DeletePaymentDetailByIdCommand, PaymentDetailEntity>, IRequestHandler<DeletePaymentDetailByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeletePaymentDetailByIdCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeletePaymentDetailByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.PaymentDetailMetadata.CreateId(request.keyId);

		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
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