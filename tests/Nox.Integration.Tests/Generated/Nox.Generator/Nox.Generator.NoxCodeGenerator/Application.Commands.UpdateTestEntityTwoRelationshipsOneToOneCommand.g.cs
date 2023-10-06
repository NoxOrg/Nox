﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityTwoRelationshipsOneToOneCommand(System.String keyId, TestEntityTwoRelationshipsOneToOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityTwoRelationshipsOneToOneKeyDto?>;

internal partial class UpdateTestEntityTwoRelationshipsOneToOneCommandHandler : UpdateTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public UpdateTestEntityTwoRelationshipsOneToOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<UpdateTestEntityTwoRelationshipsOneToOneCommand, TestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler<UpdateTestEntityTwoRelationshipsOneToOneCommand, TestEntityTwoRelationshipsOneToOneKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> _entityFactory;

	public UpdateTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToOneKeyDto?> Handle(UpdateTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(keyId);
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

		return new TestEntityTwoRelationshipsOneToOneKeyDto(entity.Id.Value);
	}
}