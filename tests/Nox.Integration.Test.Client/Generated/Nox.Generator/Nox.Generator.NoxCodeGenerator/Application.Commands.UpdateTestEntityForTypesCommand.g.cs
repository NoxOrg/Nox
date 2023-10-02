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
using TestEntityForTypes = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityForTypesCommand(System.String keyId, TestEntityForTypesUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityForTypesKeyDto?>;

internal partial class UpdateTestEntityForTypesCommandHandler: UpdateTestEntityForTypesCommandHandlerBase
{
	public UpdateTestEntityForTypesCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<TestEntityForTypes, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityForTypesCommandHandlerBase: CommandBase<UpdateTestEntityForTypesCommand, TestEntityForTypes>, IRequestHandler<UpdateTestEntityForTypesCommand, TestEntityForTypesKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityForTypes, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> _entityFactory;

	public UpdateTestEntityForTypesCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<TestEntityForTypes, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForTypesKeyDto?> Handle(UpdateTestEntityForTypesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<TestEntityForTypes,Nox.Types.Text>("Id", request.keyId);

		var entity = await DbContext.TestEntityForTypes.FindAsync(keyId);
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

		return new TestEntityForTypesKeyDto(entity.Id.Value);
	}
}