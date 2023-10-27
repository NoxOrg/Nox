﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityForUniqueConstraintsCommand(System.String keyId, TestEntityForUniqueConstraintsUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityForUniqueConstraintsKeyDto?>;

internal partial class UpdateTestEntityForUniqueConstraintsCommandHandler : UpdateTestEntityForUniqueConstraintsCommandHandlerBase
{
	public UpdateTestEntityForUniqueConstraintsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityForUniqueConstraintsCommandHandlerBase : CommandBase<UpdateTestEntityForUniqueConstraintsCommand, TestEntityForUniqueConstraintsEntity>, IRequestHandler<UpdateTestEntityForUniqueConstraintsCommand, TestEntityForUniqueConstraintsKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> _entityFactory;

	public UpdateTestEntityForUniqueConstraintsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForUniqueConstraintsKeyDto?> Handle(UpdateTestEntityForUniqueConstraintsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityForUniqueConstraints.FindAsync(keyId);
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

		return new TestEntityForUniqueConstraintsKeyDto(entity.Id.Value);
	}
}