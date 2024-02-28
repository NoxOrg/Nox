﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CountryTimeZoneEntity = Cryptocash.Domain.CountryTimeZone;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public partial record UpdateCountryTimeZonesForCountryCommand(CountryKeyDto ParentKeyDto, IEnumerable<CountryTimeZoneUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<bool>;

internal partial class UpdateCountryTimeZonesForCountryCommandHandler : UpdateCountryTimeZonesForCountryCommandHandlerBase
{
	public UpdateCountryTimeZonesForCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateCountryTimeZonesForCountryCommandHandlerBase : CommandBase<UpdateCountryTimeZonesForCountryCommand, CountryTimeZoneEntity>, IRequestHandler <UpdateCountryTimeZonesForCountryCommand, bool>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> _entityFactory;

	protected UpdateCountryTimeZonesForCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<bool> Handle(UpdateCountryTimeZonesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<Cryptocash.Domain.Country>(keys.ToArray(),e => e.CountryTimeZones, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country",  "keyId");				
		List<CountryTimeZoneEntity> entities = new(); // count
		foreach(var entityDto in request.EntitiesDto)
		{
			CountryTimeZoneEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
			}
			else
			{
				var ownedId = Dto.CountryTimeZoneMetadata.CreateId(entityDto.Id.NonNullValue<System.Int64>());
				entity = parentEntity.CountryTimeZones.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
					throw new EntityNotFoundException("CountryTimeZone",  $"ownedId");
				else
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);
			}

			entities.Add(entity);
		}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		_repository.Update(parentEntity);
		//await OnCompletedAsync(request, entity!); // fix
		await _repository.SaveChangesAsync();

		return true;
	}
	
	private async Task<CountryTimeZoneEntity> CreateEntityAsync(CountryTimeZoneUpsertDto upsertDto, CountryEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToCountryTimeZones(entity);
		return entity;
	}
}

public class UpdateCountryTimeZonesForCountryValidator : AbstractValidator<UpdateCountryTimeZonesForCountryCommand>
{
    public UpdateCountryTimeZonesForCountryValidator()
    {
    }
}