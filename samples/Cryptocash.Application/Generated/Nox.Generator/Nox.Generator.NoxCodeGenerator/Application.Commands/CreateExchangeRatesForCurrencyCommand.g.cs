﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;

using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Commands;
public partial record CreateExchangeRatesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ExchangeRateKeyDto>;

internal partial class CreateExchangeRatesForCurrencyCommandHandler : CreateExchangeRatesForCurrencyCommandHandlerBase
{
	public CreateExchangeRatesForCurrencyCommandHandler(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateExchangeRatesForCurrencyCommandHandlerBase : CommandBase<CreateExchangeRatesForCurrencyCommand, ExchangeRateEntity>, IRequestHandler<CreateExchangeRatesForCurrencyCommand, ExchangeRateKeyDto?>
{
	protected readonly Nox.Domain.IRepository Repository;
	protected readonly IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> RntityFactory;
	
	protected CreateExchangeRatesForCurrencyCommandHandlerBase(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		RntityFactory = entityFactory;
	}

	public virtual  async Task<ExchangeRateKeyDto?> Handle(CreateExchangeRatesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await Repository.FindAsync<Currency> (keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{keyId.ToString()}");
		}

		var entity = await RntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToExchangeRates(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);		
		await Repository.SaveChangesAsync();

		return new ExchangeRateKeyDto(entity.Id.Value);
	}
}

public class CreateExchangeRatesForCurrencyValidator : AbstractValidator<CreateExchangeRatesForCurrencyCommand>
{
    public CreateExchangeRatesForCurrencyValidator()
    {
		RuleFor(x => x.EntityDto.Id).Null().WithMessage("Id must be null as it is auto generated.");
    }
}