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
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityExactlyOneToOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityExactlyOneToOneOrManyKeyDto?>;

internal class PartialUpdateTestEntityExactlyOneToOneOrManyCommandHandler : PartialUpdateTestEntityExactlyOneToOneOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityExactlyOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityExactlyOneToOneOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityExactlyOneToOneOrManyCommand, TestEntityExactlyOneToOneOrManyEntity>, IRequestHandler<PartialUpdateTestEntityExactlyOneToOneOrManyCommand, TestEntityExactlyOneToOneOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityExactlyOneToOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneToOneOrManyKeyDto?> Handle(PartialUpdateTestEntityExactlyOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityExactlyOneToOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToOneOrManyKeyDto(entity.Id.Value);
	}
}