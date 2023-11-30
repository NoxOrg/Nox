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
using FluentValidation;
using Microsoft.Extensions.Logging;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public partial record CreatePaymentProviderCommand(PaymentProviderCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<PaymentProviderKeyDto>;

internal partial class CreatePaymentProviderCommandHandler : CreatePaymentProviderCommandHandlerBase
{
	public CreatePaymentProviderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory)
		: base(dbContext, noxSolution,PaymentDetailFactory, entityFactory)
	{
	}
}


internal abstract class CreatePaymentProviderCommandHandlerBase : CommandBase<CreatePaymentProviderCommand,PaymentProviderEntity>, IRequestHandler <CreatePaymentProviderCommand, PaymentProviderKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory;

	public CreatePaymentProviderCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory,
		IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.PaymentDetailFactory = PaymentDetailFactory;
	}

	public virtual async Task<PaymentProviderKeyDto> Handle(CreatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.PaymentDetailsId.Any())
		{
			foreach(var relatedId in request.EntityDto.PaymentDetailsId)
			{
				var relatedKey = Cryptocash.Domain.PaymentDetailMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.PaymentDetails.FindAsync(relatedKey);

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
				var relatedEntity = PaymentDetailFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToPaymentDetails(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.PaymentProviders.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new PaymentProviderKeyDto(entityToCreate.Id.Value);
	}
}