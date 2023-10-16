﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityTwoRelationshipsManyToManyCommand(System.String keyId, TestEntityTwoRelationshipsManyToManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityTwoRelationshipsManyToManyKeyDto?>;

internal partial class UpdateTestEntityTwoRelationshipsManyToManyCommandHandler : UpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public UpdateTestEntityTwoRelationshipsManyToManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<UpdateTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<UpdateTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> _entityFactory;

	public UpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsManyToManyKeyDto?> Handle(UpdateTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityTwoRelationshipsManyToManyKeyDto(entity.Id.Value);
	}
}