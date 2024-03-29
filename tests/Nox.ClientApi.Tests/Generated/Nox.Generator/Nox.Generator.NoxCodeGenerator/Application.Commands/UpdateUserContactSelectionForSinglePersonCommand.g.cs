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
using UserContactSelectionEntity = ClientApi.Domain.UserContactSelection;
using PersonEntity = ClientApi.Domain.Person;

namespace ClientApi.Application.Commands;

public partial record UpdateUserContactSelectionForSinglePersonCommand(PersonKeyDto ParentKeyDto, UserContactSelectionUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <UserContactSelectionKeyDto>;

internal partial class UpdateUserContactSelectionForSinglePersonCommandHandler : UpdateUserContactSelectionForSinglePersonCommandHandlerBase
{
	public UpdateUserContactSelectionForSinglePersonCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateUserContactSelectionForSinglePersonCommandHandlerBase : CommandBase<UpdateUserContactSelectionForSinglePersonCommand, UserContactSelectionEntity>, IRequestHandler <UpdateUserContactSelectionForSinglePersonCommand, UserContactSelectionKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> _entityFactory;

	protected UpdateUserContactSelectionForSinglePersonCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<UserContactSelectionKeyDto> Handle(UpdateUserContactSelectionForSinglePersonCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.PersonMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Person>(keys.ToArray(),e => e.UserContactSelection, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Person",  "keyId");		
		var entity = parentEntity.UserContactSelection;
		if (entity is null)
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		else
			await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new UserContactSelectionKeyDto();
	}
	
	private async Task<UserContactSelectionEntity> CreateEntityAsync(UserContactSelectionUpsertDto upsertDto, PersonEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateUserContactSelection(entity);
		return entity;
	}
}