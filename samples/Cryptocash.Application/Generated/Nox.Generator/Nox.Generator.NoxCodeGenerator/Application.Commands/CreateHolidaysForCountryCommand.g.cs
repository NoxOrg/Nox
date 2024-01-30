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

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using HolidayEntity = Cryptocash.Domain.Holiday;

namespace Cryptocash.Application.Commands;
public partial record CreateHolidaysForCountryCommand(CountryKeyDto ParentKeyDto, HolidayUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <HolidayKeyDto>;

internal partial class CreateHolidaysForCountryCommandHandler : CreateHolidaysForCountryCommandHandlerBase
{
	public CreateHolidaysForCountryCommandHandler(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateHolidaysForCountryCommandHandlerBase : CommandBase<CreateHolidaysForCountryCommand, HolidayEntity>, IRequestHandler<CreateHolidaysForCountryCommand, HolidayKeyDto?>
{
	protected readonly Nox.Domain.IRepository Repository;
	protected readonly IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> RntityFactory;
	
	protected CreateHolidaysForCountryCommandHandlerBase(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		RntityFactory = entityFactory;
	}

	public virtual  async Task<HolidayKeyDto?> Handle(CreateHolidaysForCountryCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await Repository.FindAsync<Country> (keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Country",  $"{keyId.ToString()}");
		}

		var entity = await RntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToHolidays(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);		
		await Repository.SaveChangesAsync();

		return new HolidayKeyDto(entity.Id.Value);
	}
}

public class CreateHolidaysForCountryValidator : AbstractValidator<CreateHolidaysForCountryCommand>
{
    public CreateHolidaysForCountryValidator()
    {
		RuleFor(x => x.EntityDto.Id).Null().WithMessage("Id must be null as it is auto generated.");
    }
}