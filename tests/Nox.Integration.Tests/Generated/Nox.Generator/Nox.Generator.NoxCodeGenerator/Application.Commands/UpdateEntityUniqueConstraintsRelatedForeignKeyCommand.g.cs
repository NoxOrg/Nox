﻿﻿
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
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Commands;

public partial record UpdateEntityUniqueConstraintsRelatedForeignKeyCommand(System.Int32 keyId, EntityUniqueConstraintsRelatedForeignKeyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<EntityUniqueConstraintsRelatedForeignKeyKeyDto>;

internal partial class UpdateEntityUniqueConstraintsRelatedForeignKeyCommandHandler : UpdateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase
{
	public UpdateEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase : CommandBase<UpdateEntityUniqueConstraintsRelatedForeignKeyCommand, EntityUniqueConstraintsRelatedForeignKeyEntity>, IRequestHandler<UpdateEntityUniqueConstraintsRelatedForeignKeyCommand, EntityUniqueConstraintsRelatedForeignKeyKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> _entityFactory;
	protected UpdateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EntityUniqueConstraintsRelatedForeignKeyKeyDto> Handle(UpdateEntityUniqueConstraintsRelatedForeignKeyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(request.keyId);

		var entity = await DbContext.EntityUniqueConstraintsRelatedForeignKeys.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new EntityUniqueConstraintsRelatedForeignKeyKeyDto(entity.Id.Value);
	}
}