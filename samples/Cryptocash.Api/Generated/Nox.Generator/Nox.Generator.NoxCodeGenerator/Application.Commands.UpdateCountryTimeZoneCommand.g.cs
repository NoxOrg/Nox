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
public record UpdateCountryTimeZoneCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneKeyDto EntityKeyDto, CountryTimeZoneUpdateDto EntityDto) : IRequest <CountryTimeZoneKeyDto?>;

public partial class UpdateCountryTimeZoneCommandHandler: CommandBase<UpdateCountryTimeZoneCommand, CountryTimeZone>, IRequestHandler <UpdateCountryTimeZoneCommand, CountryTimeZoneKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CountryTimeZone> EntityMapper { get; }

	public UpdateCountryTimeZoneCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryTimeZone> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CountryTimeZoneKeyDto?> Handle(UpdateCountryTimeZoneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.CountryCode2>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<CountryTimeZone,Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryTimeZones.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<CountryTimeZone>(), request.EntityDto);
		
		OnCompleted(request, entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryTimeZoneKeyDto(entity.Id.Value);
	}
}