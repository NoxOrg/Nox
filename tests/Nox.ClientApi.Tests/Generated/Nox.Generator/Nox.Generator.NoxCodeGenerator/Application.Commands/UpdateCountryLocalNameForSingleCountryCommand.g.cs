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
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public partial record UpdateCountryLocalNameForSingleCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryLocalNameKeyDto>;

internal partial class UpdateCountryLocalNameForSingleCountryCommandHandler : UpdateCountryLocalNameForSingleCountryCommandHandlerBase
{
	public UpdateCountryLocalNameForSingleCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateCountryLocalNameForSingleCountryCommandHandlerBase : CommandBase<UpdateCountryLocalNameForSingleCountryCommand, CountryLocalNameEntity>, IRequestHandler <UpdateCountryLocalNameForSingleCountryCommand, CountryLocalNameKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> _entityFactory;

	protected UpdateCountryLocalNameForSingleCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryLocalNameKeyDto> Handle(UpdateCountryLocalNameForSingleCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(),e => e.CountryLocalNames, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country",  "keyId");
		var entity = parentEntity.CountryLocalNames.Find(e => e.Id == Dto.CountryLocalNameMetadata.CreateId(request.EntityDto.Id!.Value )); 
		EntityNotFoundException.ThrowIfNull(entity, "CountryLocalName",  "keyId");
		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}

public class UpdateCountryLocalNameForSingleCountryCommandValidator : AbstractValidator<UpdateCountryLocalNameForSingleCountryCommand>
{
    public UpdateCountryLocalNameForSingleCountryCommandValidator()
    {
    }
}