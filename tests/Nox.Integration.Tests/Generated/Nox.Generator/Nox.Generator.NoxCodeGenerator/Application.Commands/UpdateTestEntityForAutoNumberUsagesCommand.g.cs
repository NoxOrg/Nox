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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityForAutoNumberUsagesCommand(System.Int64 keyId, TestEntityForAutoNumberUsagesUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityForAutoNumberUsagesKeyDto?>;

internal partial class UpdateTestEntityForAutoNumberUsagesCommandHandler : UpdateTestEntityForAutoNumberUsagesCommandHandlerBase
{
	public UpdateTestEntityForAutoNumberUsagesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityForAutoNumberUsagesCommandHandlerBase : CommandBase<UpdateTestEntityForAutoNumberUsagesCommand, TestEntityForAutoNumberUsagesEntity>, IRequestHandler<UpdateTestEntityForAutoNumberUsagesCommand, TestEntityForAutoNumberUsagesKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> _entityFactory;

	public UpdateTestEntityForAutoNumberUsagesCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForAutoNumberUsagesKeyDto?> Handle(UpdateTestEntityForAutoNumberUsagesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityForAutoNumberUsages.FindAsync(keyId);
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

		return new TestEntityForAutoNumberUsagesKeyDto(entity.Id.Value);
	}
}