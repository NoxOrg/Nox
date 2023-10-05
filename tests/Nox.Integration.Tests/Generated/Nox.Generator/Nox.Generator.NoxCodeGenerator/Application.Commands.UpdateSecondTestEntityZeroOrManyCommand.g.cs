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
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateSecondTestEntityZeroOrManyCommand(System.String keyId, SecondTestEntityZeroOrManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<SecondTestEntityZeroOrManyKeyDto?>;

internal partial class UpdateSecondTestEntityZeroOrManyCommandHandler : UpdateSecondTestEntityZeroOrManyCommandHandlerBase
{
	public UpdateSecondTestEntityZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityZeroOrManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyEntity>, IRequestHandler<UpdateSecondTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> _entityFactory;

	public UpdateSecondTestEntityZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityZeroOrManyKeyDto?> Handle(UpdateSecondTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityZeroOrManies.FindAsync(keyId);
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

		return new SecondTestEntityZeroOrManyKeyDto(entity.Id.Value);
	}
}