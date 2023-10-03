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
using TestEntityExactlyOneToZeroOrMany = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityExactlyOneToZeroOrManyCommand(System.String keyId, TestEntityExactlyOneToZeroOrManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityExactlyOneToZeroOrManyKeyDto?>;

internal partial class UpdateTestEntityExactlyOneToZeroOrManyCommandHandler: UpdateTestEntityExactlyOneToZeroOrManyCommandHandlerBase
{
	public UpdateTestEntityExactlyOneToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory): base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityExactlyOneToZeroOrManyCommandHandlerBase: CommandBase<UpdateTestEntityExactlyOneToZeroOrManyCommand, TestEntityExactlyOneToZeroOrMany>, IRequestHandler<UpdateTestEntityExactlyOneToZeroOrManyCommand, TestEntityExactlyOneToZeroOrManyKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> _entityFactory;

	public UpdateTestEntityExactlyOneToZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrManyKeyDto?> Handle(UpdateTestEntityExactlyOneToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityExactlyOneToZeroOrManies.FindAsync(keyId);
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

		return new TestEntityExactlyOneToZeroOrManyKeyDto(entity.Id.Value);
	}
}