﻿﻿﻿﻿// Generated

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

public partial record UpdateCountryTimeZoneForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryTimeZoneKeyDto>;

internal partial class UpdateCountryTimeZoneForCountryCommandHandler : UpdateCountryTimeZoneForCountryCommandHandlerBase
{
	public UpdateCountryTimeZoneForCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateCountryTimeZoneForCountryCommandHandlerBase : CommandBase<UpdateCountryTimeZoneForCountryCommand, CountryTimeZoneEntity>, IRequestHandler <UpdateCountryTimeZoneForCountryCommand, CountryTimeZoneKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> _entityFactory;

	protected UpdateCountryTimeZoneForCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryTimeZoneKeyDto> Handle(UpdateCountryTimeZoneForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(),e => e.CountryTimeZones, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country",  "keyId");
		var entity = parentEntity.CountryTimeZones.Find(e => e.Id == Dto.CountryTimeZoneMetadata.CreateId(request.EntityDto.Id! )); 
		EntityNotFoundException.ThrowIfNull(entity, "CountryTimeZone",  "keyId");
		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new CountryTimeZoneKeyDto(entity.Id.Value);
	}
}

public class UpdateCountryTimeZoneForCountryCommandValidator : AbstractValidator<UpdateCountryTimeZoneForCountryCommand>
{
    public UpdateCountryTimeZoneForCountryCommandValidator()
    {		
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}