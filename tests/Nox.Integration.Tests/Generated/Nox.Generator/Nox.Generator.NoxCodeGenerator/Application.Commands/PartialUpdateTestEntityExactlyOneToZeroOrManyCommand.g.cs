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
using TestEntityExactlyOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityExactlyOneToZeroOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityExactlyOneToZeroOrManyKeyDto?>;

internal class PartialUpdateTestEntityExactlyOneToZeroOrManyCommandHandler : PartialUpdateTestEntityExactlyOneToZeroOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityExactlyOneToZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityExactlyOneToZeroOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityExactlyOneToZeroOrManyCommand, TestEntityExactlyOneToZeroOrManyEntity>, IRequestHandler<PartialUpdateTestEntityExactlyOneToZeroOrManyCommand, TestEntityExactlyOneToZeroOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityExactlyOneToZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrManyKeyDto?> Handle(PartialUpdateTestEntityExactlyOneToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityExactlyOneToZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToZeroOrManyKeyDto(entity.Id.Value);
	}
}