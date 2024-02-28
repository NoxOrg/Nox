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
using HolidayEntity = ClientApi.Domain.Holiday;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public partial record UpdateHolidaysForCountryCommand(CountryKeyDto ParentKeyDto, IEnumerable<HolidayUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<bool>;

internal partial class UpdateHolidaysForCountryCommandHandler : UpdateHolidaysForCountryCommandHandlerBase
{
	public UpdateHolidaysForCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateHolidaysForCountryCommandHandlerBase : CommandBase<UpdateHolidaysForCountryCommand, HolidayEntity>, IRequestHandler <UpdateHolidaysForCountryCommand, bool>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> _entityFactory;

	protected UpdateHolidaysForCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<bool> Handle(UpdateHolidaysForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(),e => e.Holidays, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country",  "keyId");				
		List<HolidayEntity> entities = new(request.EntitiesDto.Count());
		foreach(var entityDto in request.EntitiesDto)
		{
			HolidayEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
			}
			else
			{
				var ownedId = Dto.HolidayMetadata.CreateId(entityDto.Id.NonNullValue<System.Guid>());
				entity = parentEntity.Holidays.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
					entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
				else
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);
			}

			entities.Add(entity);
		}

		parentEntity.UpdateRefToHolidays(entities);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		_repository.Update(parentEntity);
		_repository.DeleteOwned<HolidayEntity>(parentEntity.Holidays.Where(oe => !entities.Exists(e => e.Id == oe.Id)).ToList());
		//await OnCompletedAsync(request, entity!); // second parameter of CommandBase must be a IEntity, but we have a collection of entities
		await _repository.SaveChangesAsync();

		return true; // Should we return bool or list of entity ids or parent id?
	}
	
	private async Task<HolidayEntity> CreateEntityAsync(HolidayUpsertDto upsertDto, CountryEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToHolidays(entity);
		return entity;
	}
}

public class UpdateHolidaysForCountryValidator : AbstractValidator<UpdateHolidaysForCountryCommand>
{
    public UpdateHolidaysForCountryValidator()
    { 
    }
}