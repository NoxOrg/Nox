// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public partial record DeletePaymentProviderByIdCommand(IEnumerable<PaymentProviderKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeletePaymentProviderByIdCommandHandler : DeletePaymentProviderByIdCommandHandlerBase
{
	public DeletePaymentProviderByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeletePaymentProviderByIdCommandHandlerBase : CommandCollectionBase<DeletePaymentProviderByIdCommand, PaymentProviderEntity>, IRequestHandler<DeletePaymentProviderByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeletePaymentProviderByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeletePaymentProviderByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<PaymentProviderEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.PaymentProviderMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<PaymentProvider>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("PaymentProvider",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<PaymentProviderEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}