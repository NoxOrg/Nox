﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <SecondTestEntityTwoRelationshipsManyToManyKeyDto?>;

internal class PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandler : PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand, SecondTestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand, SecondTestEntityTwoRelationshipsManyToManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> EntityFactory { get; }

	public PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsManyToManyKeyDto?> Handle(PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsManyToManyKeyDto(entity.Id.Value);
	}
}