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
using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public partial record DeletePaymentProviderByIdCommand(IEnumerable<PaymentProviderKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeletePaymentProviderByIdCommandHandler : DeletePaymentProviderByIdCommandHandlerBase
{
	public DeletePaymentProviderByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeletePaymentProviderByIdCommandHandlerBase : CommandCollectionBase<DeletePaymentProviderByIdCommand, PaymentProviderEntity>, IRequestHandler<DeletePaymentProviderByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeletePaymentProviderByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeletePaymentProviderByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<PaymentProviderEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Cryptocash.Domain.PaymentProviderMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.PaymentProviders.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("PaymentProvider",  $"{keyId.ToString()}");
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