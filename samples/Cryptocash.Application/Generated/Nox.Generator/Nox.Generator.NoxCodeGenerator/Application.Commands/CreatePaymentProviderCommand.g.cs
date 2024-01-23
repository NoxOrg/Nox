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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public partial record CreatePaymentProviderCommand(PaymentProviderCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<PaymentProviderKeyDto>;

internal partial class CreatePaymentProviderCommandHandler : CreatePaymentProviderCommandHandlerBase
{
	public CreatePaymentProviderCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory)
		: base(repository, noxSolution,PaymentDetailFactory, entityFactory)
	{
	}
}


internal abstract class CreatePaymentProviderCommandHandlerBase : CommandBase<CreatePaymentProviderCommand,PaymentProviderEntity>, IRequestHandler <CreatePaymentProviderCommand, PaymentProviderKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory;

	protected CreatePaymentProviderCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.PaymentDetailFactory = PaymentDetailFactory;
	}

	public virtual async Task<PaymentProviderKeyDto> Handle(CreatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.PaymentDetailsId.Any())
		{
			foreach(var relatedId in request.EntityDto.PaymentDetailsId)
			{
				var relatedKey = Dto.PaymentDetailMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<PaymentDetail>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToPaymentDetails(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("PaymentDetails", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.PaymentDetails)
			{
				var relatedEntity = await PaymentDetailFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToPaymentDetails(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<PaymentProvider>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new PaymentProviderKeyDto(entityToCreate.Id.Value);
	}
}