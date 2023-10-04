﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityTwoRelationshipsManyToManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityTwoRelationshipsManyToManyKeyDto?>;

internal class PartialUpdateTestEntityTwoRelationshipsManyToManyCommandHandler : PartialUpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public PartialUpdateTestEntityTwoRelationshipsManyToManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<PartialUpdateTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsManyToManyKeyDto?> Handle(PartialUpdateTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityTwoRelationshipsManyToManyKeyDto(entity.Id.Value);
	}
}