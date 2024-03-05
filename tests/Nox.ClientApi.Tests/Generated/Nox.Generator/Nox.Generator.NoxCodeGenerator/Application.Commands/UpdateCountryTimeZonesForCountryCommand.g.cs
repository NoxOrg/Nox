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

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryTimeZoneEntity = ClientApi.Domain.CountryTimeZone;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public partial record UpdateCountryTimeZonesForCountryCommand(CountryKeyDto ParentKeyDto, IEnumerable<CountryTimeZoneUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<IEnumerable<CountryTimeZoneKeyDto>>;

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

internal partial class UpdateCountryTimeZonesForCountryCommandHandlerBase : CommandCollectionBase<UpdateCountryTimeZonesForCountryCommand, CountryTimeZoneEntity>, IRequestHandler <UpdateCountryTimeZonesForCountryCommand, IEnumerable<CountryTimeZoneKeyDto>>
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

	public virtual async Task<IEnumerable<CountryTimeZoneKeyDto>> Handle(UpdateCountryTimeZonesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(),e => e.CountryTimeZones, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country",  "keyId");				
		List<CountryTimeZoneEntity> entities = new(request.EntitiesDto.Count());
		foreach(var entityDto in request.EntitiesDto)
		{
			CountryTimeZoneEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
			}
			else
			{
				var ownedId = Dto.CountryTimeZoneMetadata.CreateId(entityDto.Id.NonNullValue<System.String>());
				entity = parentEntity.CountryTimeZones.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
					entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
				else
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);

				parentEntity.DeleteRefToCountryTimeZones(entity);
			}

			parentEntity.CreateRefToCountryTimeZones(entity);
			entities.Add(entity);
		}

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entities!);
		await _repository.SaveChangesAsync();

		return entities.Select(entity => new CountryTimeZoneKeyDto(entity.Id.Value));
	}
	
	private async Task<CountryTimeZoneEntity> CreateEntityAsync(CountryTimeZoneUpsertDto upsertDto, CountryEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToCountryTimeZones(entity);
		return entity;
	}
}

public class UpdateCountryTimeZonesForCountryCommandValidator : AbstractValidator<UpdateCountryTimeZonesForCountryCommand>
{
    public UpdateCountryTimeZonesForCountryCommandValidator()
    {		
		RuleForEach(x => x.EntitiesDto).Must(x => x.Id is not null).WithMessage("Id is required.");
    }
}