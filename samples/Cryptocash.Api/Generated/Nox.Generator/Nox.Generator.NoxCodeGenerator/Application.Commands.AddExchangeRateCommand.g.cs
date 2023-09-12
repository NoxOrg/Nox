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
public record AddExchangeRateCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateCreateDto EntityDto) : IRequest <ExchangeRateKeyDto?>;

public partial class AddExchangeRateCommandHandler: CommandBase<AddExchangeRateCommand, ExchangeRate>, IRequestHandler <AddExchangeRateCommand, ExchangeRateKeyDto?>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<ExchangeRateCreateDto,ExchangeRate> _entityFactory;

	public AddExchangeRateCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<ExchangeRateCreateDto,ExchangeRate> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;	
	}

	public async Task<ExchangeRateKeyDto?> Handle(AddExchangeRateCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		
		parentEntity.ExchangeRates.Add(entity);

		OnCompleted(entity);
	
		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new ExchangeRateKeyDto(entity.Id.Value);
	}
}