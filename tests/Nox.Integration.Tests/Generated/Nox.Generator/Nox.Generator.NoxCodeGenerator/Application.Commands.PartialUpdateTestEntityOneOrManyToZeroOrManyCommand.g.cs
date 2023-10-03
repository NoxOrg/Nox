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
using TestEntityOneOrManyToZeroOrMany = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityOneOrManyToZeroOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityOneOrManyToZeroOrManyKeyDto?>;

internal class PartialUpdateTestEntityOneOrManyToZeroOrManyCommandHandler: PartialUpdateTestEntityOneOrManyToZeroOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityOneOrManyToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrMany, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityOneOrManyToZeroOrManyCommandHandlerBase: CommandBase<PartialUpdateTestEntityOneOrManyToZeroOrManyCommand, TestEntityOneOrManyToZeroOrMany>, IRequestHandler<PartialUpdateTestEntityOneOrManyToZeroOrManyCommand, TestEntityOneOrManyToZeroOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<TestEntityOneOrManyToZeroOrMany, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityOneOrManyToZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrMany, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrManyKeyDto?> Handle(PartialUpdateTestEntityOneOrManyToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityOneOrManyToZeroOrManyKeyDto(entity.Id.Value);
	}
}