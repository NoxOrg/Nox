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
using Nox.Factories;
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
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> paymentdetailfactory,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory)
		: base(dbContext, noxSolution,paymentdetailfactory, entityFactory)
	{
	}
}


internal abstract class CreatePaymentProviderCommandHandlerBase : CommandBase<CreatePaymentProviderCommand,PaymentProviderEntity>, IRequestHandler <CreatePaymentProviderCommand, PaymentProviderKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> _entityFactory;
	private readonly IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> _paymentdetailfactory;

	public CreatePaymentProviderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> paymentdetailfactory,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_paymentdetailfactory = paymentdetailfactory;
	}

	public virtual async Task<PaymentProviderKeyDto> Handle(CreatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.PaymentProviderRelatedPaymentDetails)
		{
			var relatedEntity = _paymentdetailfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToPaymentProviderRelatedPaymentDetails(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.PaymentProviders.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new PaymentProviderKeyDto(entityToCreate.Id.Value);
	}
}