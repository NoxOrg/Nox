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
using SecondTestEntityOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateSecondTestEntityOneOrManyCommand(System.String keyId, SecondTestEntityOneOrManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<SecondTestEntityOneOrManyKeyDto?>;

internal partial class UpdateSecondTestEntityOneOrManyCommandHandler : UpdateSecondTestEntityOneOrManyCommandHandlerBase
{
	public UpdateSecondTestEntityOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityOneOrManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityOneOrManyCommand, SecondTestEntityOneOrManyEntity>, IRequestHandler<UpdateSecondTestEntityOneOrManyCommand, SecondTestEntityOneOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> _entityFactory;

	public UpdateSecondTestEntityOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOneOrManyKeyDto?> Handle(UpdateSecondTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}