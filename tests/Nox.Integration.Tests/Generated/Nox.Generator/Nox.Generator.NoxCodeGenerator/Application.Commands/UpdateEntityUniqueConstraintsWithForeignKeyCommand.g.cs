﻿﻿// Generated

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
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Commands;

public partial record UpdateEntityUniqueConstraintsWithForeignKeyCommand(System.Guid keyId, EntityUniqueConstraintsWithForeignKeyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<EntityUniqueConstraintsWithForeignKeyKeyDto?>;

internal partial class UpdateEntityUniqueConstraintsWithForeignKeyCommandHandler : UpdateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase
{
	public UpdateEntityUniqueConstraintsWithForeignKeyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}

internal abstract class UpdateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase : CommandBase<UpdateEntityUniqueConstraintsWithForeignKeyCommand, EntityUniqueConstraintsWithForeignKeyEntity>, IRequestHandler<UpdateEntityUniqueConstraintsWithForeignKeyCommand, EntityUniqueConstraintsWithForeignKeyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> _entityFactory;

	protected UpdateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EntityUniqueConstraintsWithForeignKeyKeyDto?> Handle(UpdateEntityUniqueConstraintsWithForeignKeyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(request.keyId);

		var entity = await DbContext.EntityUniqueConstraintsWithForeignKeys.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EntityUniqueConstraintsWithForeignKeyKeyDto(entity.Id.Value);
	}
}