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
using TestEntityOneOrMany = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityOneOrManyCommand(System.String keyId, TestEntityOneOrManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityOneOrManyKeyDto?>;

internal partial class UpdateTestEntityOneOrManyCommandHandler: UpdateTestEntityOneOrManyCommandHandlerBase
{
	public UpdateTestEntityOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory): base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOneOrManyCommandHandlerBase: CommandBase<UpdateTestEntityOneOrManyCommand, TestEntityOneOrMany>, IRequestHandler<UpdateTestEntityOneOrManyCommand, TestEntityOneOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> _entityFactory;

	public UpdateTestEntityOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyKeyDto?> Handle(UpdateTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOneOrManies.FindAsync(keyId);
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

		return new TestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}