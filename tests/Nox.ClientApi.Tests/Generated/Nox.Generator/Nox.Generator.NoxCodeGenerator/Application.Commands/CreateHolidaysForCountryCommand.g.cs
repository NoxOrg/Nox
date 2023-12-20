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
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using HolidayEntity = ClientApi.Domain.Holiday;

namespace ClientApi.Application.Commands;
public partial record CreateHolidaysForCountryCommand(CountryKeyDto ParentKeyDto, HolidayUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <HolidayKeyDto>;

internal partial class CreateHolidaysForCountryCommandHandler : CreateHolidaysForCountryCommandHandlerBase
{
	public CreateHolidaysForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateHolidaysForCountryCommandHandlerBase : CommandBase<CreateHolidaysForCountryCommand, HolidayEntity>, IRequestHandler<CreateHolidaysForCountryCommand, HolidayKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> _entityFactory;

	protected CreateHolidaysForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<HolidayKeyDto?> Handle(CreateHolidaysForCountryCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Country",  $"{keyId.ToString()}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto);
		parentEntity.CreateRefToHolidays(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;

		var result = await _dbContext.SaveChangesAsync();

		return new HolidayKeyDto(entity.Id.Value);
	}
}

public class CreateHolidaysForCountryValidator : AbstractValidator<CreateHolidaysForCountryCommand>
{
    public CreateHolidaysForCountryValidator()
    { 
    }
}