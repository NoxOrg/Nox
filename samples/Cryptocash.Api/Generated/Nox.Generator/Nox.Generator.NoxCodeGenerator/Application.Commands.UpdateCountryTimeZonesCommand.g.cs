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

public record UpdateCountryTimeZonesCommand(System.Int64 keyId, CountryTimeZonesUpdateDto EntityDto) : IRequest<CountryTimeZonesKeyDto?>;

public class UpdateCountryTimeZonesCommandHandler: CommandBase<UpdateCountryTimeZonesCommand, CountryTimeZones>, IRequestHandler<UpdateCountryTimeZonesCommand, CountryTimeZonesKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CountryTimeZones> EntityMapper { get; }

	public UpdateCountryTimeZonesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryTimeZones> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<CountryTimeZonesKeyDto?> Handle(UpdateCountryTimeZonesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CountryTimeZones,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.CountryTimeZones.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<CountryTimeZones>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new CountryTimeZonesKeyDto(entity.Id.Value);
	}
}