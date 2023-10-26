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

public record CreatePaymentDetailCommand(PaymentDetailCreateDto EntityDto, System.String CultureCode) : IRequest<PaymentDetailKeyDto>;

internal partial class CreatePaymentDetailCommandHandler : CreatePaymentDetailCommandHandlerBase
{
	public CreatePaymentDetailCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> PaymentProviderFactory,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
		: base(dbContext, noxSolution,CustomerFactory, PaymentProviderFactory, entityFactory)
	{
	}
}


internal abstract class CreatePaymentDetailCommandHandlerBase : CommandBase<CreatePaymentDetailCommand,PaymentDetailEntity>, IRequestHandler <CreatePaymentDetailCommand, PaymentDetailKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> PaymentProviderFactory;

	public CreatePaymentDetailCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> PaymentProviderFactory,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CustomerFactory = CustomerFactory;
		this.PaymentProviderFactory = PaymentProviderFactory;
	}

	public virtual async Task<PaymentDetailKeyDto> Handle(CreatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.PaymentDetailsUsedByCustomerId is not null)
		{
			var relatedKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.PaymentDetailsUsedByCustomerId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.Customers.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToPaymentDetailsUsedByCustomer(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("PaymentDetailsUsedByCustomer", request.EntityDto.PaymentDetailsUsedByCustomerId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.PaymentDetailsUsedByCustomer is not null)
		{
			var relatedEntity = CustomerFactory.CreateEntity(request.EntityDto.PaymentDetailsUsedByCustomer);
			entityToCreate.CreateRefToPaymentDetailsUsedByCustomer(relatedEntity);
		}
		if(request.EntityDto.PaymentDetailsRelatedPaymentProviderId is not null)
		{
			var relatedKey = Cryptocash.Domain.PaymentProviderMetadata.CreateId(request.EntityDto.PaymentDetailsRelatedPaymentProviderId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.PaymentProviders.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToPaymentDetailsRelatedPaymentProvider(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("PaymentDetailsRelatedPaymentProvider", request.EntityDto.PaymentDetailsRelatedPaymentProviderId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.PaymentDetailsRelatedPaymentProvider is not null)
		{
			var relatedEntity = PaymentProviderFactory.CreateEntity(request.EntityDto.PaymentDetailsRelatedPaymentProvider);
			entityToCreate.CreateRefToPaymentDetailsRelatedPaymentProvider(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.PaymentDetails.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new PaymentDetailKeyDto(entityToCreate.Id.Value);
	}
}