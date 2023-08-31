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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateRefMinimumCashStockToCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefMinimumCashStockToCurrencyCommandHandler: CommandBase<CreateRefMinimumCashStockToCurrencyCommand, MinimumCashStock>, 
	IRequestHandler <CreateRefMinimumCashStockToCurrencyCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefMinimumCashStockToCurrencyCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefMinimumCashStockToCurrencyCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<MinimumCashStock,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.Currencies.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.Currency = relatedEntity;
		

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}