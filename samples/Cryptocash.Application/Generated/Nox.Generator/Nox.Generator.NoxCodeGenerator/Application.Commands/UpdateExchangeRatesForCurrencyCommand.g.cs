﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public partial record UpdateExchangeRatesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, IEnumerable<ExchangeRateUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<IEnumerable<ExchangeRateKeyDto>>;

internal partial class UpdateExchangeRatesForCurrencyCommandHandler : UpdateExchangeRatesForCurrencyCommandHandlerBase
{
	public UpdateExchangeRatesForCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateExchangeRatesForCurrencyCommandHandlerBase : CommandCollectionBase<UpdateExchangeRatesForCurrencyCommand, ExchangeRateEntity>, IRequestHandler <UpdateExchangeRatesForCurrencyCommand, IEnumerable<ExchangeRateKeyDto>>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> _entityFactory;

	protected UpdateExchangeRatesForCurrencyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<IEnumerable<ExchangeRateKeyDto>> Handle(UpdateExchangeRatesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<Cryptocash.Domain.Currency>(keys.ToArray(),e => e.ExchangeRates, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Currency",  "keyId");				
		List<ExchangeRateEntity> entities = new(request.EntitiesDto.Count());
		foreach(var entityDto in request.EntitiesDto)
		{
			ExchangeRateEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
				parentEntity.CreateRefToExchangeRates(entity);
			}
			else
			{
				var ownedId = Dto.ExchangeRateMetadata.CreateId(entityDto.Id.NonNullValue<System.Int64>());
				entity = parentEntity.ExchangeRates.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
				{
					throw new EntityNotFoundException("ExchangeRate",  $"ownedId");
				}
				else
				{
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);
				}
			}

			entities.Add(entity);
		}

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entities!);
		await _repository.SaveChangesAsync();

		return entities.Select(entity => new ExchangeRateKeyDto(entity.Id.Value));
	}
	
	private async Task<ExchangeRateEntity> CreateEntityAsync(ExchangeRateUpsertDto upsertDto, CurrencyEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToExchangeRates(entity);
		return entity;
	}
}

public class UpdateExchangeRatesForCurrencyCommandValidator : AbstractValidator<UpdateExchangeRatesForCurrencyCommand>
{
    public UpdateExchangeRatesForCurrencyCommandValidator()
    {
    }
}