﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityWithNuid = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityWithNuidCommand(System.UInt32 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityWithNuidKeyDto?>;

internal class PartialUpdateTestEntityWithNuidCommandHandler: PartialUpdateTestEntityWithNuidCommandHandlerBase
{
	public PartialUpdateTestEntityWithNuidCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<TestEntityWithNuid, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityWithNuidCommandHandlerBase: CommandBase<PartialUpdateTestEntityWithNuidCommand, TestEntityWithNuid>, IRequestHandler<PartialUpdateTestEntityWithNuidCommand, TestEntityWithNuidKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<TestEntityWithNuid, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityWithNuidCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<TestEntityWithNuid, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityWithNuidKeyDto?> Handle(PartialUpdateTestEntityWithNuidCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<TestEntityWithNuid,Nox.Types.Nuid>("Id", request.keyId);

		var entity = await DbContext.TestEntityWithNuids.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityWithNuidKeyDto(entity.Id.Value);
	}
}