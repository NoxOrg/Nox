﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityZeroOrManyCommand(System.String keyId, TestEntityZeroOrManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityZeroOrManyKeyDto?>;

internal partial class UpdateTestEntityZeroOrManyCommandHandler : UpdateTestEntityZeroOrManyCommandHandlerBase
{
	public UpdateTestEntityZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrManyCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrManyCommand, TestEntityZeroOrManyEntity>, IRequestHandler<UpdateTestEntityZeroOrManyCommand, TestEntityZeroOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> _entityFactory;

	public UpdateTestEntityZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrManyKeyDto?> Handle(UpdateTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityZeroOrManyKeyDto(entity.Id.Value);
	}
}