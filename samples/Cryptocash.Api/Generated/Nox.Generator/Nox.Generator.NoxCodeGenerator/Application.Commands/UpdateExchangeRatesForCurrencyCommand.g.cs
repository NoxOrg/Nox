﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public partial record UpdateExchangeRatesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ExchangeRateKeyDto>;

internal partial class UpdateExchangeRatesForCurrencyCommandHandler : UpdateExchangeRatesForCurrencyCommandHandlerBase
{
	public UpdateExchangeRatesForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateExchangeRatesForCurrencyCommandHandlerBase : CommandBase<UpdateExchangeRatesForCurrencyCommand, ExchangeRateEntity>, IRequestHandler <UpdateExchangeRatesForCurrencyCommand, ExchangeRateKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> _entityFactory;

	protected UpdateExchangeRatesForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<ExchangeRateKeyDto> Handle(UpdateExchangeRatesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await _dbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Collection(p => p.ExchangeRates).LoadAsync(cancellationToken);
		
		ExchangeRateEntity? entity;
		if(request.EntityDto.Id is null)
		{
			entity = await CreateEntityAsync(request.EntityDto, parentEntity);
		}
		else
		{
			var ownedId = Cryptocash.Domain.ExchangeRateMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.Int64>());
			entity = parentEntity.ExchangeRates.SingleOrDefault(x => x.Id == ownedId);
			if (entity is null)
				throw new EntityNotFoundException("ExchangeRate",  $"{ownedId.ToString()}");
			else
				await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity!);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;


		var result = await _dbContext.SaveChangesAsync();

		return new ExchangeRateKeyDto(entity.Id.Value);
	}
	
	private async Task<ExchangeRateEntity> CreateEntityAsync(ExchangeRateUpsertDto upsertDto, CurrencyEntity parent)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto);
		parent.CreateRefToExchangeRates(entity);
		return entity;
	}
}

public class UpdateExchangeRatesForCurrencyValidator : AbstractValidator<UpdateExchangeRatesForCurrencyCommand>
{
    public UpdateExchangeRatesForCurrencyValidator()
    {
    }
}