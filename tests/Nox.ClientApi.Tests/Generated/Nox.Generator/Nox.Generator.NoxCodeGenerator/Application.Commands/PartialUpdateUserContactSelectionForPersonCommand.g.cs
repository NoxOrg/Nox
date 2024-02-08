﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Domain;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using UserContactSelectionEntity = ClientApi.Domain.UserContactSelection;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateUserContactSelectionForPersonCommand(PersonKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <UserContactSelectionKeyDto>;

internal partial class PartialUpdateUserContactSelectionForPersonCommandHandler: PartialUpdateUserContactSelectionForPersonCommandHandlerBase
{
	public PartialUpdateUserContactSelectionForPersonCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateUserContactSelectionForPersonCommandHandlerBase: CommandBase<PartialUpdateUserContactSelectionForPersonCommand, UserContactSelectionEntity>, IRequestHandler <PartialUpdateUserContactSelectionForPersonCommand, UserContactSelectionKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> EntityFactory;
	
	protected PartialUpdateUserContactSelectionForPersonCommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<UserContactSelectionKeyDto> Handle(PartialUpdateUserContactSelectionForPersonCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.PersonMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Person>(keys.ToArray(),e => e.UserContactSelection, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Person",  "keyId");
		}
		var entity = parentEntity.UserContactSelection;
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Person.UserContactSelection", String.Empty);
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new UserContactSelectionKeyDto();
	}
}