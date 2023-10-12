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
using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityOneOrManyKeyDto?>;

internal class PartialUpdateTestEntityOneOrManyCommandHandler : PartialUpdateTestEntityOneOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityOneOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityOneOrManyCommand, TestEntityOneOrManyEntity>, IRequestHandler<PartialUpdateTestEntityOneOrManyCommand, TestEntityOneOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyKeyDto?> Handle(PartialUpdateTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}