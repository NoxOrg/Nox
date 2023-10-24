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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Commands;
public record CreateExchangeRateForCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateCreateDto EntityDto, System.Guid? Etag) : IRequest <ExchangeRateKeyDto?>;

internal partial class CreateExchangeRateForCurrencyCommandHandler : CreateExchangeRateForCurrencyCommandHandlerBase
{
	public CreateExchangeRateForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateCreateDto, ExchangeRateUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateExchangeRateForCurrencyCommandHandlerBase : CommandBase<CreateExchangeRateForCurrencyCommand, ExchangeRateEntity>, IRequestHandler<CreateExchangeRateForCurrencyCommand, ExchangeRateKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<ExchangeRateEntity, ExchangeRateCreateDto, ExchangeRateUpdateDto> _entityFactory;

	public CreateExchangeRateForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateCreateDto, ExchangeRateUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<ExchangeRateKeyDto?> Handle(CreateExchangeRateForCurrencyCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CreateRefToCurrencyExchangedFromRates(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new ExchangeRateKeyDto(entity.Id.Value);
	}
}