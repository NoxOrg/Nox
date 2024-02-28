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
using HolidayEntity = Cryptocash.Domain.Holiday;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

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

		var parentEntity = await _repository.FindAndIncludeAsync<Cryptocash.Domain.Country>(keys.ToArray(),e => e.Holidays, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country",  "keyId");				
		List<HolidayEntity> entities = new(); // count
		foreach(var entityDto in request.EntitiesDto)
		{
			HolidayEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
			}
			else
			{
				var ownedId = Dto.HolidayMetadata.CreateId(entityDto.Id.NonNullValue<System.Int64>());
				entity = parentEntity.Holidays.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
					throw new EntityNotFoundException("Holiday",  $"ownedId");
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