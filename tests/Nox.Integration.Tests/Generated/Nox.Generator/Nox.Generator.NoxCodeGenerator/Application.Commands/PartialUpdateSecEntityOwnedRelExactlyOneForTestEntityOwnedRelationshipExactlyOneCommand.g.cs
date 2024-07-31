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

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecEntityOwnedRelExactlyOneEntity = TestWebApp.Domain.SecEntityOwnedRelExactlyOne;

namespace TestWebApp.Application.Commands;
public partial record PartialUpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecEntityOwnedRelExactlyOneKeyDto>;

internal partial class PartialUpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler: PartialUpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public PartialUpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelExactlyOneEntity, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase: CommandBase<PartialUpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecEntityOwnedRelExactlyOneEntity>, IRequestHandler <PartialUpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecEntityOwnedRelExactlyOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<SecEntityOwnedRelExactlyOneEntity, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> EntityFactory;
	
	protected PartialUpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelExactlyOneEntity, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecEntityOwnedRelExactlyOneKeyDto> Handle(PartialUpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await Repository.FindAndIncludeAsync<TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne>(keys.ToArray(),e => e.SecEntityOwnedRelExactlyOne, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipExactlyOne",  "keyId");
		}
		var entity = parentEntity.SecEntityOwnedRelExactlyOne;
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipExactlyOne.SecEntityOwnedRelExactlyOne", String.Empty);
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new SecEntityOwnedRelExactlyOneKeyDto();
	}
}