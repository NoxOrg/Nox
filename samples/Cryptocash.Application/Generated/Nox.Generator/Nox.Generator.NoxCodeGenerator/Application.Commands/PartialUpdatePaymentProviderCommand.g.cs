// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdatePaymentProviderCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <PaymentProviderKeyDto>;

internal partial class PartialUpdatePaymentProviderCommandHandler : PartialUpdatePaymentProviderCommandHandlerBase
{
	public PartialUpdatePaymentProviderCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdatePaymentProviderCommandHandlerBase : CommandBase<PartialUpdatePaymentProviderCommand, PaymentProviderEntity>, IRequestHandler<PartialUpdatePaymentProviderCommand, PaymentProviderKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> EntityFactory { get; }
	
	public PartialUpdatePaymentProviderCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<PaymentProviderKeyDto> Handle(PartialUpdatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.PaymentProviderMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<PaymentProvider>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentProvider",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new PaymentProviderKeyDto(entity.Id.Value);
	}
}