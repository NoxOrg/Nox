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

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecondTestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne;
using TestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecondTestEntityOwnedRelationshipZeroOrOneForSingleTestEntityOwnedRelationshipZeroOrOneCommand(TestEntityOwnedRelationshipZeroOrOneKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipZeroOrOneKeyDto>;

internal partial class UpdateSecondTestEntityOwnedRelationshipZeroOrOneForSingleTestEntityOwnedRelationshipZeroOrOneCommandHandler : UpdateSecondTestEntityOwnedRelationshipZeroOrOneForSingleTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase
{
	public UpdateSecondTestEntityOwnedRelationshipZeroOrOneForSingleTestEntityOwnedRelationshipZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecondTestEntityOwnedRelationshipZeroOrOneForSingleTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase : CommandBase<UpdateSecondTestEntityOwnedRelationshipZeroOrOneForSingleTestEntityOwnedRelationshipZeroOrOneCommand, SecondTestEntityOwnedRelationshipZeroOrOneEntity>, IRequestHandler <UpdateSecondTestEntityOwnedRelationshipZeroOrOneForSingleTestEntityOwnedRelationshipZeroOrOneCommand, SecondTestEntityOwnedRelationshipZeroOrOneKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> _entityFactory;

	protected UpdateSecondTestEntityOwnedRelationshipZeroOrOneForSingleTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipZeroOrOneKeyDto> Handle(UpdateSecondTestEntityOwnedRelationshipZeroOrOneForSingleTestEntityOwnedRelationshipZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne>(keys.ToArray(),e => e.SecondTestEntityOwnedRelationshipZeroOrOne, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "TestEntityOwnedRelationshipZeroOrOne",  "keyId");		
		var entity = parentEntity.SecondTestEntityOwnedRelationshipZeroOrOne;
		if (entity is null)
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		else
			await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new SecondTestEntityOwnedRelationshipZeroOrOneKeyDto();
	}
	
	private async Task<SecondTestEntityOwnedRelationshipZeroOrOneEntity> CreateEntityAsync(SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto upsertDto, TestEntityOwnedRelationshipZeroOrOneEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateSecondTestEntityOwnedRelationshipZeroOrOne(entity);
		return entity;
	}
}