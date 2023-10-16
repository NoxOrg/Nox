﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public record CreatePaymentDetailCommand(PaymentDetailCreateDto EntityDto) : IRequest<PaymentDetailKeyDto>;

internal partial class CreatePaymentDetailCommandHandler : CreatePaymentDetailCommandHandlerBase
{
	public CreatePaymentDetailCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
		IEntityFactory<Cryptocash.Domain.PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> paymentproviderfactory,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
		: base(dbContext, noxSolution,customerfactory, paymentproviderfactory, entityFactory)
	{
	}
}


internal abstract class CreatePaymentDetailCommandHandlerBase : CommandBase<CreatePaymentDetailCommand,PaymentDetailEntity>, IRequestHandler <CreatePaymentDetailCommand, PaymentDetailKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> _entityFactory;
	private readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> _customerfactory;
	private readonly IEntityFactory<Cryptocash.Domain.PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> _paymentproviderfactory;

	public CreatePaymentDetailCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
		IEntityFactory<Cryptocash.Domain.PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> paymentproviderfactory,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_customerfactory = customerfactory;
		_paymentproviderfactory = paymentproviderfactory;
	}

	public virtual async Task<PaymentDetailKeyDto> Handle(CreatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.PaymentDetailsUsedByCustomerId is not null)
		{
			var relatedKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.PaymentDetailsUsedByCustomerId.NonNullValue<System.Int64>());
			var relatedEntity = await _dbContext.Customers.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToPaymentDetailsUsedByCustomer(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("PaymentDetailsUsedByCustomer", request.EntityDto.PaymentDetailsUsedByCustomerId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.PaymentDetailsUsedByCustomer is not null)
		{
			var relatedEntity = _customerfactory.CreateEntity(request.EntityDto.PaymentDetailsUsedByCustomer);
			entityToCreate.CreateRefToPaymentDetailsUsedByCustomer(relatedEntity);
		}
		if(request.EntityDto.PaymentDetailsRelatedPaymentProviderId is not null)
		{
			var relatedKey = Cryptocash.Domain.PaymentProviderMetadata.CreateId(request.EntityDto.PaymentDetailsRelatedPaymentProviderId.NonNullValue<System.Int64>());
			var relatedEntity = await _dbContext.PaymentProviders.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToPaymentDetailsRelatedPaymentProvider(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("PaymentDetailsRelatedPaymentProvider", request.EntityDto.PaymentDetailsRelatedPaymentProviderId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.PaymentDetailsRelatedPaymentProvider is not null)
		{
			var relatedEntity = _paymentproviderfactory.CreateEntity(request.EntityDto.PaymentDetailsRelatedPaymentProvider);
			entityToCreate.CreateRefToPaymentDetailsRelatedPaymentProvider(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.PaymentDetails.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new PaymentDetailKeyDto(entityToCreate.Id.Value);
	}
}