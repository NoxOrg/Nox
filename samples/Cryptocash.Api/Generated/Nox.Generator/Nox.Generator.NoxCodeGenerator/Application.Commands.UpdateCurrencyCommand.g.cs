﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Currency = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public record UpdateCurrencyCommand(System.String keyId, CurrencyUpdateDto EntityDto) : IRequest<CurrencyKeyDto?>;

public class UpdateCurrencyCommandHandler: CommandBase<UpdateCurrencyCommand, Currency>, IRequestHandler<UpdateCurrencyCommand, CurrencyKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Currency> EntityMapper { get; }
	public IEntityMapper<BankNote> BankNoteEntityMapper { get; }
	public IEntityMapper<ExchangeRate> ExchangeRateEntityMapper { get; }

	public UpdateCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,	
			IEntityMapper<BankNote> entityMapperBankNote,	
			IEntityMapper<ExchangeRate> entityMapperExchangeRate,
		IEntityMapper<Currency> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;	
		BankNoteEntityMapper = entityMapperBankNote;	
		ExchangeRateEntityMapper = entityMapperExchangeRate;
		EntityMapper = entityMapper;
	}
	
	public async Task<CurrencyKeyDto?> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.keyId);
	
		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<Currency>(), request.EntityDto);
		foreach(var ownedEntity in request.EntityDto.BankNotes)
		{
			UpdateBankNote(entity, ownedEntity);
		}
		foreach(var ownedEntity in request.EntityDto.ExchangeRates)
		{
			UpdateExchangeRate(entity, ownedEntity);
		}

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CurrencyKeyDto(entity.Id.Value);
	}
	private void UpdateBankNote(Currency parent, BankNoteDto child)
	{
		var ownedId = CreateNoxTypeForKey<BankNote,DatabaseNumber>("Id", child.Id);

		var entity = parent.BankNotes.SingleOrDefault(x =>
			x.Id.Equals(ownedId) &&
			true);
		if (entity == null)
		{
			return;
		}

		BankNoteEntityMapper.MapToEntity(entity, GetEntityDefinition<BankNote>(), child);		
	}
	private void UpdateExchangeRate(Currency parent, ExchangeRateDto child)
	{
		var ownedId = CreateNoxTypeForKey<ExchangeRate,DatabaseNumber>("Id", child.Id);

		var entity = parent.ExchangeRates.SingleOrDefault(x =>
			x.Id.Equals(ownedId) &&
			true);
		if (entity == null)
		{
			return;
		}

		ExchangeRateEntityMapper.MapToEntity(entity, GetEntityDefinition<ExchangeRate>(), child);		
	}
}