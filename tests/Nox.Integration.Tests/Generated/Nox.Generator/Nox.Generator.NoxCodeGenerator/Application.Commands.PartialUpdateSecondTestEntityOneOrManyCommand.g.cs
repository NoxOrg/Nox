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
using SecondTestEntityOneOrMany = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record PartialUpdateSecondTestEntityOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <SecondTestEntityOneOrManyKeyDto?>;

internal class PartialUpdateSecondTestEntityOneOrManyCommandHandler: PartialUpdateSecondTestEntityOneOrManyCommandHandlerBase
{
	public PartialUpdateSecondTestEntityOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateSecondTestEntityOneOrManyCommandHandlerBase: CommandBase<PartialUpdateSecondTestEntityOneOrManyCommand, SecondTestEntityOneOrMany>, IRequestHandler<PartialUpdateSecondTestEntityOneOrManyCommand, SecondTestEntityOneOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateSecondTestEntityOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOneOrManyKeyDto?> Handle(PartialUpdateSecondTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new SecondTestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}