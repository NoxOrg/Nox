﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public partial record CreatePaymentDetailCommand(PaymentDetailCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<PaymentDetailKeyDto>;

internal partial class CreatePaymentDetailCommandHandler : CreatePaymentDetailCommandHandlerBase
{
	public CreatePaymentDetailCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> PaymentProviderFactory,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
		: base(repository, noxSolution,CustomerFactory, PaymentProviderFactory, entityFactory)
	{
	}
}


internal abstract class CreatePaymentDetailCommandHandlerBase : CommandBase<CreatePaymentDetailCommand,PaymentDetailEntity>, IRequestHandler <CreatePaymentDetailCommand, PaymentDetailKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> PaymentProviderFactory;

	protected CreatePaymentDetailCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> PaymentProviderFactory,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.CustomerFactory = CustomerFactory;
		this.PaymentProviderFactory = PaymentProviderFactory;
	}

	public virtual async Task<PaymentDetailKeyDto> Handle(CreatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.CustomerId is not null)
		{
			var relatedKey = Dto.CustomerMetadata.CreateId(request.EntityDto.CustomerId.NonNullValue<System.Guid>());
			var relatedEntity = await Repository.FindAsync<Cryptocash.Domain.Customer>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCustomer(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Customer", request.EntityDto.CustomerId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.Customer is not null)
		{
			var relatedEntity = await CustomerFactory.CreateEntityAsync(request.EntityDto.Customer, request.CultureCode);
			entityToCreate.CreateRefToCustomer(relatedEntity);
		}
		if(request.EntityDto.PaymentProviderId is not null)
		{
			var relatedKey = Dto.PaymentProviderMetadata.CreateId(request.EntityDto.PaymentProviderId.NonNullValue<System.Guid>());
			var relatedEntity = await Repository.FindAsync<Cryptocash.Domain.PaymentProvider>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToPaymentProvider(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("PaymentProvider", request.EntityDto.PaymentProviderId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.PaymentProvider is not null)
		{
			var relatedEntity = await PaymentProviderFactory.CreateEntityAsync(request.EntityDto.PaymentProvider, request.CultureCode);
			entityToCreate.CreateRefToPaymentProvider(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<Cryptocash.Domain.PaymentDetail>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new PaymentDetailKeyDto(entityToCreate.Id.Value);
	}
}