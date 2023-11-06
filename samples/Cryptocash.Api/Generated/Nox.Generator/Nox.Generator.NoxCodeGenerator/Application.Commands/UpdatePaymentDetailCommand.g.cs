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

public partial record UpdatePaymentDetailCommand(System.Int64 keyId, PaymentDetailUpdateDto EntityDto, System.Guid? Etag) : IRequest<PaymentDetailKeyDto?>;

internal partial class UpdatePaymentDetailCommandHandler : UpdatePaymentDetailCommandHandlerBase
{
	public UpdatePaymentDetailCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
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
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<PaymentDetailKeyDto?> Handle(UpdatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.PaymentDetailMetadata.CreateId(request.keyId);

		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var customerKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.CustomerId);
		var customerEntity = await DbContext.Customers.FindAsync(customerKey);
						
		if(customerEntity is not null)
			entity.CreateRefToCustomer(customerEntity);
		else
			throw new RelatedEntityNotFoundException("Customer", request.EntityDto.CustomerId.ToString());

		var paymentProviderKey = Cryptocash.Domain.PaymentProviderMetadata.CreateId(request.EntityDto.PaymentProviderId);
		var paymentProviderEntity = await DbContext.PaymentProviders.FindAsync(paymentProviderKey);
						
		if(paymentProviderEntity is not null)
			entity.CreateRefToPaymentProvider(paymentProviderEntity);
		else
			throw new RelatedEntityNotFoundException("PaymentProvider", request.EntityDto.PaymentProviderId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto);
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