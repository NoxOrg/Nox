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
public record CreateRefCurrencyUnitsToCurrencyCommand(CurrencyUnitsKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefCurrencyUnitsToCurrencyCommandHandler: CommandBase<CreateRefCurrencyUnitsToCurrencyCommand, CurrencyUnits>, 
	IRequestHandler <CreateRefCurrencyUnitsToCurrencyCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefCurrencyUnitsToCurrencyCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefCurrencyUnitsToCurrencyCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CurrencyUnits,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.CurrencyUnits.FindAsync(keyId);
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
		entity.Currencies.Add(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}