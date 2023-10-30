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
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityLocalizationCommand(System.String keyId, TestEntityLocalizationUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityLocalizationKeyDto?>;

internal partial class UpdateTestEntityLocalizationCommandHandler : UpdateTestEntityLocalizationCommandHandlerBase
{
	public UpdateTestEntityLocalizationCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityLocalizationCommandHandlerBase : CommandBase<UpdateTestEntityLocalizationCommand, TestEntityLocalizationEntity>, IRequestHandler<UpdateTestEntityLocalizationCommand, TestEntityLocalizationKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> _entityFactory;

	public UpdateTestEntityLocalizationCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityLocalizationKeyDto?> Handle(UpdateTestEntityLocalizationCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityLocalizations.FindAsync(keyId);
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

		return new TestEntityLocalizationKeyDto(entity.Id.Value);
	}
}