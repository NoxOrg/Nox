// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public partial record DeletePaymentDetailByIdCommand(IEnumerable<PaymentDetailKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeletePaymentDetailByIdCommandHandler : DeletePaymentDetailByIdCommandHandlerBase
{
	public DeletePaymentDetailByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeletePaymentDetailByIdCommandHandlerBase : CommandBase<DeletePaymentDetailByIdCommand, PaymentDetailEntity>, IRequestHandler<DeletePaymentDetailByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeletePaymentDetailByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeletePaymentDetailByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = Cryptocash.Domain.PaymentDetailMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.PaymentDetails.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new PaymentDetailEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}