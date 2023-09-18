﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using ExchangeRate = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Commands;
public record CreateExchangeRateForCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateCreateDto EntityDto, System.Guid? Etag) : IRequest <ExchangeRateKeyDto?>;

public partial class CreateExchangeRateForCurrencyCommandHandler: CreateExchangeRateForCurrencyCommandHandlerBase
{
	public CreateExchangeRateForCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<ExchangeRate,ExchangeRateCreateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution, entityFactory, serviceProvider)
	{
	}
}
public abstract class CreateExchangeRateForCurrencyCommandHandlerBase: CommandBase<CreateExchangeRateForCurrencyCommand, ExchangeRate>, IRequestHandler<CreateExchangeRateForCurrencyCommand, ExchangeRateKeyDto?>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<ExchangeRate,ExchangeRateCreateDto> _entityFactory;

	public CreateExchangeRateForCurrencyCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<ExchangeRate,ExchangeRateCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;	
	}

	public virtual  async Task<ExchangeRateKeyDto?> Handle(CreateExchangeRateForCurrencyCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CurrencyExchangedFromRates.Add(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);
	
		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new ExchangeRateKeyDto(entity.Id.Value);
	}
}