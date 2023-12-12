﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using HolidayEntity = Cryptocash.Domain.Holiday;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public partial record UpdateHolidaysForCountryCommand(CountryKeyDto ParentKeyDto, HolidayUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <HolidayKeyDto?>;

internal partial class UpdateHolidaysForCountryCommandHandler : UpdateHolidaysForCountryCommandHandlerBase
{
	public UpdateHolidaysForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateHolidaysForCountryCommandHandlerBase : CommandBase<UpdateHolidaysForCountryCommand, HolidayEntity>, IRequestHandler <UpdateHolidaysForCountryCommand, HolidayKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> _entityFactory;

	protected UpdateHolidaysForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<HolidayKeyDto?> Handle(UpdateHolidaysForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await _dbContext.Entry(parentEntity).Collection(p => p.Holidays).LoadAsync(cancellationToken);
		
		HolidayEntity? entity;
		if(request.EntityDto.Id is null)
		{
			entity = await CreateEntityAsync(request.EntityDto, parentEntity);
		}
		else
		{
			var ownedId = Cryptocash.Domain.HolidayMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.Int64>());
			entity = parentEntity.Holidays.SingleOrDefault(x => x.Id == ownedId);
			if (entity is null)
				return null;
			else
				await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity!);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;


		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new HolidayKeyDto(entity.Id.Value);
	}
	
	private async Task<HolidayEntity> CreateEntityAsync(HolidayUpsertDto upsertDto, CountryEntity parent)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto);
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