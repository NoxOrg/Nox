﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public partial record Update PaymentProviderCommand(System.Int64 keyId, PaymentProviderUpdateDto EntityDto, System.Guid? Etag) : IRequest<PaymentProviderKeyDto?>;

internal partial class UpdatePaymentProviderCommandHandler : UpdatePaymentProviderCommandHandlerBase
{
	public UpdatePaymentProviderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdatePaymentProviderCommandHandlerBase : CommandBase<UpdatePaymentProviderCommand, PaymentProviderEntity>, IRequestHandler<UpdatePaymentProviderCommand, PaymentProviderKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> _entityFactory;

	public UpdatePaymentProviderCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<PaymentProviderKeyDto?> Handle(UpdatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.PaymentProviderMetadata.CreateId(request.keyId);

		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.PaymentProviderRelatedPaymentDetails).LoadAsync();
		var paymentProviderRelatedPaymentDetailsEntities = new List<PaymentDetail>();
		foreach(var relatedEntityId in request.EntityDto.PaymentProviderRelatedPaymentDetailsId)
		{
			var relatedKey = Cryptocash.Domain.PaymentDetailMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.PaymentDetails.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				paymentProviderRelatedPaymentDetailsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("PaymentProviderRelatedPaymentDetails", relatedEntityId.ToString());
		}
		entity.UpdateRefToPaymentProviderRelatedPaymentDetails(paymentProviderRelatedPaymentDetailsEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new PaymentProviderKeyDto(entity.Id.Value);
	}
}