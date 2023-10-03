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
using TestEntityForTypes = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityForTypesCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TestEntityForTypesKeyDto?>;

internal class PartialUpdateTestEntityForTypesCommandHandler: PartialUpdateTestEntityForTypesCommandHandlerBase
{
	public PartialUpdateTestEntityForTypesCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypes, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityForTypesCommandHandlerBase: CommandBase<PartialUpdateTestEntityForTypesCommand, TestEntityForTypes>, IRequestHandler<PartialUpdateTestEntityForTypesCommand, TestEntityForTypesKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	public IEntityFactory<TestEntityForTypes, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityForTypesCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypes, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForTypesKeyDto?> Handle(PartialUpdateTestEntityForTypesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityForTypesMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityForTypes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityForTypesKeyDto(entity.Id.Value);
	}
}