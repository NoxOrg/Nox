﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryTimeZoneEntity = Cryptocash.Domain.CountryTimeZone;

namespace Cryptocash.Application.Commands;
public partial record Create CountryTimeZoneForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneCreateDto EntityDto, System.Guid? Etag) : IRequest <CountryTimeZoneKeyDto?>;

internal partial class CreateCountryTimeZoneForCountryCommandHandler : CreateCountryTimeZoneForCountryCommandHandlerBase
{
	public CreateCountryTimeZoneForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateCountryTimeZoneForCountryCommandHandlerBase : CommandBase<CreateCountryTimeZoneForCountryCommand, CountryTimeZoneEntity>, IRequestHandler<CreateCountryTimeZoneForCountryCommand, CountryTimeZoneKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> _entityFactory;

	public CreateCountryTimeZoneForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<CountryTimeZoneKeyDto?> Handle(CreateCountryTimeZoneForCountryCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CreateRefToCountryOwnedTimeZones(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryTimeZoneKeyDto(entity.Id.Value);
	}
}