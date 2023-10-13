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
using TestEntityZeroOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityZeroOrManyToZeroOrOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityZeroOrManyToZeroOrOneKeyDto?>;

internal class PartialUpdateTestEntityZeroOrManyToZeroOrOneCommandHandler : PartialUpdateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase
{
	public PartialUpdateTestEntityZeroOrManyToZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase : CommandBase<PartialUpdateTestEntityZeroOrManyToZeroOrOneCommand, TestEntityZeroOrManyToZeroOrOneEntity>, IRequestHandler<PartialUpdateTestEntityZeroOrManyToZeroOrOneCommand, TestEntityZeroOrManyToZeroOrOneKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToZeroOrOneKeyDto?> Handle(PartialUpdateTestEntityZeroOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrManyToZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyToZeroOrOneKeyDto(entity.Id.Value);
	}
}