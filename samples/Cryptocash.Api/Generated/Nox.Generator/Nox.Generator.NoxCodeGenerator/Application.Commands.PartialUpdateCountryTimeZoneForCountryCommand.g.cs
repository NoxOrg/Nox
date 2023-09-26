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
public record PartialUpdateCountryTimeZoneForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CountryTimeZoneKeyDto?>;
internal partial class PartialUpdateCountryTimeZoneForCountryCommandHandler: PartialUpdateCountryTimeZoneForCountryCommandHandlerBase
{
	public PartialUpdateCountryTimeZoneForCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryTimeZone, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> entityFactory) : base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryTimeZoneForCountryCommandHandlerBase: CommandBase<PartialUpdateCountryTimeZoneForCountryCommand, CountryTimeZone>, IRequestHandler <PartialUpdateCountryTimeZoneForCountryCommand, CountryTimeZoneKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<CountryTimeZone, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> EntityFactory { get; }

	public PartialUpdateCountryTimeZoneForCountryCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryTimeZone, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryTimeZoneKeyDto?> Handle(PartialUpdateCountryTimeZoneForCountryCommand request, CancellationToken cancellationToken)
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
		var entity = parentEntity.CountryOwnedTimeZones.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
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