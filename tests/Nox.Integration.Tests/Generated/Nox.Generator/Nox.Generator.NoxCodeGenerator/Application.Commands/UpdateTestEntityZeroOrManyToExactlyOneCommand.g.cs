﻿// Generated

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
using TestEntityZeroOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityZeroOrManyToExactlyOneCommand(System.String keyId, TestEntityZeroOrManyToExactlyOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityZeroOrManyToExactlyOneKeyDto?>;

internal partial class UpdateTestEntityZeroOrManyToExactlyOneCommandHandler : UpdateTestEntityZeroOrManyToExactlyOneCommandHandlerBase
{
	public UpdateTestEntityZeroOrManyToExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrManyToExactlyOneCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrManyToExactlyOneCommand, TestEntityZeroOrManyToExactlyOneEntity>, IRequestHandler<UpdateTestEntityZeroOrManyToExactlyOneCommand, TestEntityZeroOrManyToExactlyOneKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> _entityFactory;

	public UpdateTestEntityZeroOrManyToExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToExactlyOneKeyDto?> Handle(UpdateTestEntityZeroOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrManyToExactlyOnes.FindAsync(keyId);
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

		return new TestEntityZeroOrManyToExactlyOneKeyDto(entity.Id.Value);
	}
}