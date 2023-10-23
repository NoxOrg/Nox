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
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateSecondTestEntityZeroOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <SecondTestEntityZeroOrManyKeyDto?>;

internal class PartialUpdateSecondTestEntityZeroOrManyCommandHandler : PartialUpdateSecondTestEntityZeroOrManyCommandHandlerBase
{
	public PartialUpdateSecondTestEntityZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateSecondTestEntityZeroOrManyCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyEntity>, IRequestHandler<PartialUpdateSecondTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateSecondTestEntityZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityZeroOrManyKeyDto?> Handle(PartialUpdateSecondTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new SecondTestEntityZeroOrManyKeyDto(entity.Id.Value);
	}
}