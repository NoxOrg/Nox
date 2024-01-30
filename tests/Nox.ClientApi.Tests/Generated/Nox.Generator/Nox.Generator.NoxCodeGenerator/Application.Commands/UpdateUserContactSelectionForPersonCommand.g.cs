﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using UserContactSelectionEntity = ClientApi.Domain.UserContactSelection;
using PersonEntity = ClientApi.Domain.Person;

namespace ClientApi.Application.Commands;

public partial record UpdateUserContactSelectionForPersonCommand(PersonKeyDto ParentKeyDto, UserContactSelectionUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <UserContactSelectionKeyDto>;

internal partial class UpdateUserContactSelectionForPersonCommandHandler : UpdateUserContactSelectionForPersonCommandHandlerBase
{
	public UpdateUserContactSelectionForPersonCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateUserContactSelectionForPersonCommandHandlerBase : CommandBase<UpdateUserContactSelectionForPersonCommand, UserContactSelectionEntity>, IRequestHandler <UpdateUserContactSelectionForPersonCommand, UserContactSelectionKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> _entityFactory;

	protected UpdateUserContactSelectionForPersonCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<UserContactSelectionKeyDto> Handle(UpdateUserContactSelectionForPersonCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.PersonMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await _dbContext.People.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Person",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Reference(e => e.UserContactSelection).LoadAsync(cancellationToken);
		var entity = parentEntity.UserContactSelection;
		if (entity is null)
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		else
			await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity!);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

		return new UserContactSelectionKeyDto();
	}
	
	private async Task<UserContactSelectionEntity> CreateEntityAsync(UserContactSelectionUpsertDto upsertDto, PersonEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToUserContactSelection(entity);
		return entity;
	}
}