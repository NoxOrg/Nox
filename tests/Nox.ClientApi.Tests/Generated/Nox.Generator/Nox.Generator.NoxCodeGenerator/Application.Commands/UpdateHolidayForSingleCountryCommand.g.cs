﻿﻿﻿// Generated

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

public partial record UpdateHolidayForSingleCountryCommand(CountryKeyDto ParentKeyDto, HolidayUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <HolidayKeyDto>;

internal partial class UpdateHolidayForSingleCountryCommandHandler : UpdateHolidayForSingleCountryCommandHandlerBase
{
	public UpdateHolidayForSingleCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateHolidayForSingleCountryCommandHandlerBase : CommandBase<UpdateHolidayForSingleCountryCommand, HolidayEntity>, IRequestHandler <UpdateHolidayForSingleCountryCommand, HolidayKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> _entityFactory;

	protected UpdateHolidayForSingleCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<HolidayKeyDto> Handle(UpdateHolidayForSingleCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(),e => e.Holidays, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country",  "keyId");
		var entity = parentEntity.Holidays.Find(e => e.Id == Dto.HolidayMetadata.CreateId(request.EntityDto.Id!.Value )); 
		EntityNotFoundException.ThrowIfNull(entity, "Holiday",  "keyId");
		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new HolidayKeyDto(entity.Id.Value);
	}
}

public class UpdateHolidayForSingleCountryCommandValidator : AbstractValidator<UpdateHolidayForSingleCountryCommand>
{
    public UpdateHolidayForSingleCountryCommandValidator()
    { 
    }
}