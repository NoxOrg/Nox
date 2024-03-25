﻿﻿﻿// Generated

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

public partial record UpdateExchangeRateForSingleCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ExchangeRateKeyDto>;

internal partial class UpdateExchangeRateForSingleCurrencyCommandHandler : UpdateExchangeRateForSingleCurrencyCommandHandlerBase
{
	public UpdateExchangeRateForSingleCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateExchangeRateForSingleCurrencyCommandHandlerBase : CommandBase<UpdateExchangeRateForSingleCurrencyCommand, ExchangeRateEntity>, IRequestHandler <UpdateExchangeRateForSingleCurrencyCommand, ExchangeRateKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> _entityFactory;

	protected UpdateExchangeRateForSingleCurrencyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<ExchangeRateKeyDto> Handle(UpdateExchangeRateForSingleCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<Cryptocash.Domain.Currency>(keys.ToArray(),e => e.ExchangeRates, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Currency",  "keyId");
		var entity = parentEntity.ExchangeRates.Find(e => e.Id == Dto.ExchangeRateMetadata.CreateId(request.EntityDto.Id!.Value )); 
		EntityNotFoundException.ThrowIfNull(entity, "ExchangeRate",  "keyId");
		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new ExchangeRateKeyDto(entity.Id.Value);
	}
}

public class UpdateExchangeRateForSingleCurrencyCommandValidator : AbstractValidator<UpdateExchangeRateForSingleCurrencyCommand>
{
    public UpdateExchangeRateForSingleCurrencyCommandValidator()
    {
    }
}