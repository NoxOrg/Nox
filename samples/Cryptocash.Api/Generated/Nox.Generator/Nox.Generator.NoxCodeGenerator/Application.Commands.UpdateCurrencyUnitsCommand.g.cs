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

namespace Cryptocash.Application.Commands;

public record UpdateCurrencyUnitsCommand(System.Int64 keyId, CurrencyUnitsUpdateDto EntityDto) : IRequest<CurrencyUnitsKeyDto?>;

public class UpdateCurrencyUnitsCommandHandler: CommandBase<UpdateCurrencyUnitsCommand, CurrencyUnits>, IRequestHandler<UpdateCurrencyUnitsCommand, CurrencyUnitsKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CurrencyUnits> EntityMapper { get; }

	public UpdateCurrencyUnitsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CurrencyUnits> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<CurrencyUnitsKeyDto?> Handle(UpdateCurrencyUnitsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CurrencyUnits,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.CurrencyUnits.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<CurrencyUnits>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new CurrencyUnitsKeyDto(entity.Id.Value);
	}
}