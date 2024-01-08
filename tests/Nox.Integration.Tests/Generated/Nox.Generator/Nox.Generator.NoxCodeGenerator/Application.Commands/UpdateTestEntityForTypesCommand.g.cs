﻿﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityForTypesCommand(System.String keyId, TestEntityForTypesUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityForTypesKeyDto>;

internal partial class UpdateTestEntityForTypesCommandHandler : UpdateTestEntityForTypesCommandHandlerBase
{
	public UpdateTestEntityForTypesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityForTypesCommandHandlerBase : CommandBase<UpdateTestEntityForTypesCommand, TestEntityForTypesEntity>, IRequestHandler<UpdateTestEntityForTypesCommand, TestEntityForTypesKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> _entityFactory;
	protected UpdateTestEntityForTypesCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForTypesKeyDto> Handle(UpdateTestEntityForTypesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityForTypesMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityForTypes.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityForTypes",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new TestEntityForTypesKeyDto(entity.Id.Value);
	}
}