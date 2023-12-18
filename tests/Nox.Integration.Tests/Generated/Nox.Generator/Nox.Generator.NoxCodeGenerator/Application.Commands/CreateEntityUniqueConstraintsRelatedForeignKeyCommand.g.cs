﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using FluentValidation;
using Microsoft.Extensions.Logging;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Commands;

public partial record CreateEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsRelatedForeignKeyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<EntityUniqueConstraintsRelatedForeignKeyKeyDto>;

internal partial class CreateEntityUniqueConstraintsRelatedForeignKeyCommandHandler : CreateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase
{
	public CreateEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> EntityUniqueConstraintsWithForeignKeyFactory,
		IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,EntityUniqueConstraintsWithForeignKeyFactory, entityFactory)
	{
	}
}


internal abstract class CreateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase : CommandBase<CreateEntityUniqueConstraintsRelatedForeignKeyCommand,EntityUniqueConstraintsRelatedForeignKeyEntity>, IRequestHandler <CreateEntityUniqueConstraintsRelatedForeignKeyCommand, EntityUniqueConstraintsRelatedForeignKeyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> EntityUniqueConstraintsWithForeignKeyFactory;

	protected CreateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> EntityUniqueConstraintsWithForeignKeyFactory,
		IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.EntityUniqueConstraintsWithForeignKeyFactory = EntityUniqueConstraintsWithForeignKeyFactory;
	}

	public virtual async Task<EntityUniqueConstraintsRelatedForeignKeyKeyDto> Handle(CreateEntityUniqueConstraintsRelatedForeignKeyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.EntityUniqueConstraintsWithForeignKeysId.Any())
		{
			foreach(var relatedId in request.EntityDto.EntityUniqueConstraintsWithForeignKeysId)
			{
				var relatedKey = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.EntityUniqueConstraintsWithForeignKeys.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToEntityUniqueConstraintsWithForeignKeys(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("EntityUniqueConstraintsWithForeignKeys", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.EntityUniqueConstraintsWithForeignKeys)
			{
				var relatedEntity = await EntityUniqueConstraintsWithForeignKeyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToEntityUniqueConstraintsWithForeignKeys(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.EntityUniqueConstraintsRelatedForeignKeys.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new EntityUniqueConstraintsRelatedForeignKeyKeyDto(entityToCreate.Id.Value);
	}
}