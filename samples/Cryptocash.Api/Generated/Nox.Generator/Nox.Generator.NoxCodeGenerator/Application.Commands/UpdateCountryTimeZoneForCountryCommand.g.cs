﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryTimeZoneEntity = Cryptocash.Domain.CountryTimeZone;

namespace Cryptocash.Application.Commands;
public record UpdateCountryTimeZoneForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneKeyDto EntityKeyDto, CountryTimeZoneUpdateDto EntityDto, System.Guid? Etag) : IRequest <CountryTimeZoneKeyDto?>;

internal partial class UpdateCountryTimeZoneForCountryCommandHandler : UpdateCountryTimeZoneForCountryCommandHandlerBase
{
	public UpdateCountryTimeZoneForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateCountryTimeZoneForCountryCommandHandlerBase : CommandBase<UpdateCountryTimeZoneForCountryCommand, CountryTimeZoneEntity>, IRequestHandler <UpdateCountryTimeZoneForCountryCommand, CountryTimeZoneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> _entityFactory;

	public UpdateCountryTimeZoneForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryTimeZoneKeyDto?> Handle(UpdateCountryTimeZoneForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = Cryptocash.Domain.CountryTimeZoneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryOwnedTimeZones.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, DefaultCultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryTimeZoneKeyDto(entity.Id.Value);
	}
}