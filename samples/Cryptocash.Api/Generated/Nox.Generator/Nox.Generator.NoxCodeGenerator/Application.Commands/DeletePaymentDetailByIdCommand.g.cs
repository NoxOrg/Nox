// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public partial record DeletePaymentDetailByIdCommand(IEnumerable<PaymentDetailKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeletePaymentDetailByIdCommandHandler : DeletePaymentDetailByIdCommandHandlerBase
{
	public DeletePaymentDetailByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeletePaymentDetailByIdCommandHandlerBase : CommandCollectionBase<DeletePaymentDetailByIdCommand, PaymentDetailEntity>, IRequestHandler<DeletePaymentDetailByIdCommand, bool>
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
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<PaymentDetailEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Cryptocash.Domain.PaymentDetailMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.PaymentDetails.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("PaymentDetail",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}