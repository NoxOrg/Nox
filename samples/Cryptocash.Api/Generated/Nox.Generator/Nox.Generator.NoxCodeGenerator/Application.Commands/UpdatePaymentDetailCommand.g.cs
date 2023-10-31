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
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public record UpdatePaymentDetailCommand(System.Int64 keyId, PaymentDetailUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<PaymentDetailKeyDto?>;

internal partial class UpdatePaymentDetailCommandHandler : UpdatePaymentDetailCommandHandlerBase
{
	public UpdatePaymentDetailCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdatePaymentDetailCommandHandlerBase : CommandBase<UpdatePaymentDetailCommand, PaymentDetailEntity>, IRequestHandler<UpdatePaymentDetailCommand, PaymentDetailKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> _entityFactory;

	public UpdatePaymentDetailCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<PaymentDetailKeyDto?> Handle(UpdatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.PaymentDetailMetadata.CreateId(request.keyId);

		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var paymentDetailsUsedByCustomerKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.PaymentDetailsUsedByCustomerId);
		var paymentDetailsUsedByCustomerEntity = await DbContext.Customers.FindAsync(paymentDetailsUsedByCustomerKey);
						
		if(paymentDetailsUsedByCustomerEntity is not null)
			entity.CreateRefToPaymentDetailsUsedByCustomer(paymentDetailsUsedByCustomerEntity);
		else
			throw new RelatedEntityNotFoundException("PaymentDetailsUsedByCustomer", request.EntityDto.PaymentDetailsUsedByCustomerId.ToString());

		var paymentDetailsRelatedPaymentProviderKey = Cryptocash.Domain.PaymentProviderMetadata.CreateId(request.EntityDto.PaymentDetailsRelatedPaymentProviderId);
		var paymentDetailsRelatedPaymentProviderEntity = await DbContext.PaymentProviders.FindAsync(paymentDetailsRelatedPaymentProviderKey);
						
		if(paymentDetailsRelatedPaymentProviderEntity is not null)
			entity.CreateRefToPaymentDetailsRelatedPaymentProvider(paymentDetailsRelatedPaymentProviderEntity);
		else
			throw new RelatedEntityNotFoundException("PaymentDetailsRelatedPaymentProvider", request.EntityDto.PaymentDetailsRelatedPaymentProviderId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new PaymentDetailKeyDto(entity.Id.Value);
	}
}