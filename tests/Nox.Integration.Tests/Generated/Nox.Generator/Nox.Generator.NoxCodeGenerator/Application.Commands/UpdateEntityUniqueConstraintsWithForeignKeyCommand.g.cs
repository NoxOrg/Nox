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
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Commands;

public partial record UpdateEntityUniqueConstraintsWithForeignKeyCommand(System.Guid keyId, EntityUniqueConstraintsWithForeignKeyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<EntityUniqueConstraintsWithForeignKeyKeyDto>;

internal partial class UpdateEntityUniqueConstraintsWithForeignKeyCommandHandler : UpdateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase
{
	public UpdateEntityUniqueConstraintsWithForeignKeyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase : CommandBase<UpdateEntityUniqueConstraintsWithForeignKeyCommand, EntityUniqueConstraintsWithForeignKeyEntity>, IRequestHandler<UpdateEntityUniqueConstraintsWithForeignKeyCommand, EntityUniqueConstraintsWithForeignKeyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> EntityFactory { get; }
	protected UpdateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<EntityUniqueConstraintsWithForeignKeyKeyDto> Handle(UpdateEntityUniqueConstraintsWithForeignKeyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey>()
            .Where(x => x.Id == Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new EntityUniqueConstraintsWithForeignKeyKeyDto(entity.Id.Value);
	}
}