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
using CountryTimeZones = CryptocashApi.Domain.CountryTimeZones;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateCountryTimeZonesCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CountryTimeZonesKeyDto?>;

public class PartialUpdateCountryTimeZonesCommandHandler: CommandBase<PartialUpdateCountryTimeZonesCommand, CountryTimeZones>, IRequestHandler<PartialUpdateCountryTimeZonesCommand, CountryTimeZonesKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<CountryTimeZones> EntityMapper { get; }

	public PartialUpdateCountryTimeZonesCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryTimeZones> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CountryTimeZonesKeyDto?> Handle(PartialUpdateCountryTimeZonesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CountryTimeZones,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CountryTimeZones.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CountryTimeZones>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CountryTimeZonesKeyDto(entity.Id.Value);
	}
}