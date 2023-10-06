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
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityZeroOrOneToExactlyOneCommand(System.String keyId, TestEntityZeroOrOneToExactlyOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityZeroOrOneToExactlyOneKeyDto?>;

internal partial class UpdateTestEntityZeroOrOneToExactlyOneCommandHandler : UpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase
{
	public UpdateTestEntityZeroOrOneToExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneEntity>, IRequestHandler<UpdateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> _entityFactory;

	public UpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToExactlyOneKeyDto?> Handle(UpdateTestEntityZeroOrOneToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrOneToExactlyOnes.FindAsync(keyId);
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

		return new TestEntityZeroOrOneToExactlyOneKeyDto(entity.Id.Value);
	}
}