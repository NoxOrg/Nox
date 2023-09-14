﻿﻿// Generated

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
public record UpdateCountryTimeZoneForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneKeyDto EntityKeyDto, CountryTimeZoneUpdateDto EntityDto, System.Guid? Etag) : IRequest <CountryTimeZoneKeyDto?>;

public partial class UpdateCountryTimeZoneForCountryCommandHandler: CommandBase<UpdateCountryTimeZoneForCountryCommand, CountryTimeZone>, IRequestHandler <UpdateCountryTimeZoneForCountryCommand, CountryTimeZoneKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CountryTimeZone> EntityMapper { get; }

	public UpdateCountryTimeZoneForCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryTimeZone> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CountryTimeZoneKeyDto?> Handle(UpdateCountryTimeZoneForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<CountryTimeZone,AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryTimeZones.SingleOrDefault(x => x.Id == ownedId);		
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<CountryTimeZone>(), request.EntityDto);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
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