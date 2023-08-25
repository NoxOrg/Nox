﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateCurrencyUnitsCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CurrencyUnitsKeyDto?>;

public class PartialUpdateCurrencyUnitsCommandHandler: CommandBase<PartialUpdateCurrencyUnitsCommand>, IRequestHandler<PartialUpdateCurrencyUnitsCommand, CurrencyUnitsKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<CurrencyUnits> EntityMapper { get; }

	public PartialUpdateCurrencyUnitsCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CurrencyUnits> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CurrencyUnitsKeyDto?> Handle(PartialUpdateCurrencyUnitsCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<CurrencyUnits,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CurrencyUnits.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CurrencyUnits>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CurrencyUnitsKeyDto(entity.Id.Value);
	}
}