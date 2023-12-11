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
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityForTypesCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityForTypesKeyDto?>;

internal partial class PartialUpdateTestEntityForTypesCommandHandler : PartialUpdateTestEntityForTypesCommandHandlerBase
{
	public PartialUpdateTestEntityForTypesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityForTypesCommandHandlerBase : CommandBase<PartialUpdateTestEntityForTypesCommand, TestEntityForTypesEntity>, IRequestHandler<PartialUpdateTestEntityForTypesCommand, TestEntityForTypesKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityForTypesCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForTypesKeyDto?> Handle(PartialUpdateTestEntityForTypesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityForTypesMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityForTypes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityForTypesKeyDto(entity.Id.Value);
	}
}