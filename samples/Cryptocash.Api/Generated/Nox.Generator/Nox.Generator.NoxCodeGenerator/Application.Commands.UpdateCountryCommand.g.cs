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
using Country = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public record UpdateCountryCommand(System.String keyId, CountryUpdateDto EntityDto, System.Guid? Etag) : IRequest<CountryKeyDto?>;

public class UpdateCountryCommandHandler: CommandBase<UpdateCountryCommand, Country>, IRequestHandler<UpdateCountryCommand, CountryKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Country> EntityMapper { get; }
	public IEntityMapper<CountryTimeZone> CountryTimeZoneEntityMapper { get; }
	public IEntityMapper<Holiday> HolidayEntityMapper { get; }

	public UpdateCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,	
			IEntityMapper<CountryTimeZone> entityMapperCountryTimeZone,	
			IEntityMapper<Holiday> entityMapperHoliday,
		IEntityMapper<Country> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;	
		CountryTimeZoneEntityMapper = entityMapperCountryTimeZone;	
		HolidayEntityMapper = entityMapperHoliday;
		EntityMapper = entityMapper;
	}
	
	public async Task<CountryKeyDto?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.keyId);
	
		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<Country>(), request.EntityDto);
		foreach(var ownedEntity in request.EntityDto.CountryTimeZones)
		{
			UpdateCountryTimeZone(entity, ownedEntity);
		}
		foreach(var ownedEntity in request.EntityDto.Holidays)
		{
			UpdateHoliday(entity, ownedEntity);
		}
		entity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryKeyDto(entity.Id.Value);
	}
	private void UpdateCountryTimeZone(Country parent, CountryTimeZoneDto child)
	{
		var ownedId = CreateNoxTypeForKey<CountryTimeZone,DatabaseNumber>("Id", child.Id);

		var entity = parent.CountryTimeZones.SingleOrDefault(x =>
			x.Id.Equals(ownedId) &&
			true);
		if (entity == null)
		{
			return;
		}

		CountryTimeZoneEntityMapper.MapToEntity(entity, GetEntityDefinition<CountryTimeZone>(), child);		
	}
	private void UpdateHoliday(Country parent, HolidayDto child)
	{
		var ownedId = CreateNoxTypeForKey<Holiday,DatabaseNumber>("Id", child.Id);

		var entity = parent.Holidays.SingleOrDefault(x =>
			x.Id.Equals(ownedId) &&
			true);
		if (entity == null)
		{
			return;
		}

		HolidayEntityMapper.MapToEntity(entity, GetEntityDefinition<Holiday>(), child);		
	}
}