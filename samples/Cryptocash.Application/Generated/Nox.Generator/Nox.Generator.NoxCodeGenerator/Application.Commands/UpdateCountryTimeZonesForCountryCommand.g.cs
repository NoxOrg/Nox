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

public partial record UpdateCountryTimeZonesForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryTimeZoneKeyDto>;

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

internal partial class UpdateCountryTimeZonesForCountryCommandHandlerBase : CommandBase<UpdateCountryTimeZonesForCountryCommand, CountryTimeZoneEntity>, IRequestHandler <UpdateCountryTimeZonesForCountryCommand, CountryTimeZoneKeyDto>
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

	public virtual async Task<CountryTimeZoneKeyDto> Handle(UpdateCountryTimeZonesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<Country>(keys.ToArray(),e => e.CountryTimeZones, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country",  "keyId");				
		CountryTimeZoneEntity? entity;
		if(request.EntityDto.Id is null)
		{
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		}
		else
		{
			var ownedId =Dto.CountryTimeZoneMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.Int64>());
			entity = parentEntity.CountryTimeZones.SingleOrDefault(x => x.Id == ownedId);
			if (entity is null)
				throw new EntityNotFoundException("CountryTimeZone",  $"ownedId");
			else
				await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new CountryTimeZoneKeyDto(entity.Id.Value);
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