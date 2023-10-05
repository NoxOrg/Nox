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
using TestEntityZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityZeroOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityZeroOrManyKeyDto?>;

internal class PartialUpdateTestEntityZeroOrManyCommandHandler : PartialUpdateTestEntityZeroOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityZeroOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityZeroOrManyCommand, TestEntityZeroOrManyEntity>, IRequestHandler<PartialUpdateTestEntityZeroOrManyCommand, TestEntityZeroOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrManyKeyDto?> Handle(PartialUpdateTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyKeyDto(entity.Id.Value);
	}
}