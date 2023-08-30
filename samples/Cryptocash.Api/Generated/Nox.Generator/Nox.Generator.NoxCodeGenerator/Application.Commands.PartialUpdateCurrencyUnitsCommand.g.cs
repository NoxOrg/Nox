﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;

public record PartialUpdateCurrencyUnitsCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CurrencyUnitsKeyDto?>;

public class PartialUpdateCurrencyUnitsCommandHandler: CommandBase<PartialUpdateCurrencyUnitsCommand, CurrencyUnits>, IRequestHandler<PartialUpdateCurrencyUnitsCommand, CurrencyUnitsKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CurrencyUnits> EntityMapper { get; }

	public PartialUpdateCurrencyUnitsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CurrencyUnits> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CurrencyUnitsKeyDto?> Handle(PartialUpdateCurrencyUnitsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CurrencyUnits,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CurrencyUnits.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CurrencyUnits>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CurrencyUnitsKeyDto(entity.Id.Value);
	}
}