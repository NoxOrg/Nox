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

namespace Cryptocash.Application.Commands;
public record DeleteRefCurrencyToExchangeRateCommand(CurrencyKeyDto EntityKeyDto, ExchangeRateKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class DeleteRefCurrencyToExchangeRateCommandHandler: CommandBase<DeleteRefCurrencyToExchangeRateCommand, Currency>, 
	IRequestHandler <DeleteRefCurrencyToExchangeRateCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteRefCurrencyToExchangeRateCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteRefCurrencyToExchangeRateCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<ExchangeRate,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.ExchangeRates.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.ExchangeRates.Remove(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}