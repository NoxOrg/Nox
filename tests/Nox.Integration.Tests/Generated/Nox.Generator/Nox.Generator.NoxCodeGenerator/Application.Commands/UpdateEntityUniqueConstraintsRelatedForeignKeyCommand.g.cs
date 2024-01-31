﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Commands;

public partial record UpdateEntityUniqueConstraintsRelatedForeignKeyCommand(System.Int32 keyId, EntityUniqueConstraintsRelatedForeignKeyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<EntityUniqueConstraintsRelatedForeignKeyKeyDto>;

internal partial class UpdateEntityUniqueConstraintsRelatedForeignKeyCommandHandler : UpdateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase
{
	public UpdateEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase : CommandBase<UpdateEntityUniqueConstraintsRelatedForeignKeyCommand, EntityUniqueConstraintsRelatedForeignKeyEntity>, IRequestHandler<UpdateEntityUniqueConstraintsRelatedForeignKeyCommand, EntityUniqueConstraintsRelatedForeignKeyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> EntityFactory { get; }
	protected UpdateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<EntityUniqueConstraintsRelatedForeignKeyKeyDto> Handle(UpdateEntityUniqueConstraintsRelatedForeignKeyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<EntityUniqueConstraintsRelatedForeignKey>()
            .Where(x => x.Id == Dto.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new EntityUniqueConstraintsRelatedForeignKeyKeyDto(entity.Id.Value);
	}
}