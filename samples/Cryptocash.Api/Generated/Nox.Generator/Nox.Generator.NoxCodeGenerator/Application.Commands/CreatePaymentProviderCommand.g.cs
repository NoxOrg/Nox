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
using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public record CreatePaymentProviderCommand(PaymentProviderCreateDto EntityDto) : IRequest<PaymentProviderKeyDto>;

internal partial class CreatePaymentProviderCommandHandler : CreatePaymentProviderCommandHandlerBase
{
	public CreatePaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory)
		: base(dbContext, noxSolution,PaymentDetailFactory, entityFactory)
	{
	}
}


internal abstract class CreatePaymentProviderCommandHandlerBase : CommandBase<CreatePaymentProviderCommand,PaymentProviderEntity>, IRequestHandler <CreatePaymentProviderCommand, PaymentProviderKeyDto>
{
	protected readonly CryptocashDbContext DbContext;
	protected readonly IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory;

	public CreatePaymentProviderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.PaymentDetailFactory = PaymentDetailFactory;
	}

	public virtual async Task<PaymentProviderKeyDto> Handle(CreatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.PaymentProviderRelatedPaymentDetails)
		{
			var relatedEntity = PaymentDetailFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToPaymentProviderRelatedPaymentDetails(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.PaymentProviders.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new PaymentProviderKeyDto(entityToCreate.Id.Value);
	}
}