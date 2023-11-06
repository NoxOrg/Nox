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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityForAutoNumberUsagesCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityForAutoNumberUsagesKeyDto?>;

internal class PartialUpdateTestEntityForAutoNumberUsagesCommandHandler : PartialUpdateTestEntityForAutoNumberUsagesCommandHandlerBase
{
	public PartialUpdateTestEntityForAutoNumberUsagesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityForAutoNumberUsagesCommandHandlerBase : CommandBase<PartialUpdateTestEntityForAutoNumberUsagesCommand, TestEntityForAutoNumberUsagesEntity>, IRequestHandler<PartialUpdateTestEntityForAutoNumberUsagesCommand, TestEntityForAutoNumberUsagesKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityForAutoNumberUsagesCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForAutoNumberUsagesKeyDto?> Handle(PartialUpdateTestEntityForAutoNumberUsagesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityForAutoNumberUsages.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityForAutoNumberUsagesKeyDto(entity.Id.Value);
	}
}