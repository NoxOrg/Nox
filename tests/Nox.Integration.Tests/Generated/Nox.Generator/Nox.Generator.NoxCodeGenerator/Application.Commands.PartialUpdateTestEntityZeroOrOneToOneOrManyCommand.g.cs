﻿// Generated

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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityZeroOrOneToOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityZeroOrOneToOneOrManyKeyDto?>;

internal class PartialUpdateTestEntityZeroOrOneToOneOrManyCommandHandler : PartialUpdateTestEntityZeroOrOneToOneOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityZeroOrOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityZeroOrOneToOneOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityZeroOrOneToOneOrManyCommand, TestEntityZeroOrOneToOneOrManyEntity>, IRequestHandler<PartialUpdateTestEntityZeroOrOneToOneOrManyCommand, TestEntityZeroOrOneToOneOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityZeroOrOneToOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToOneOrManyKeyDto?> Handle(PartialUpdateTestEntityZeroOrOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrOneToOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrOneToOneOrManyKeyDto(entity.Id.Value);
	}
}