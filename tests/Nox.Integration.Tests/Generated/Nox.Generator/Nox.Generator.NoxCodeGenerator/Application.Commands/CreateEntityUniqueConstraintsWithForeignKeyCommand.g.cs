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

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Commands;

public partial record CreateEntityUniqueConstraintsWithForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<EntityUniqueConstraintsWithForeignKeyKeyDto>;

internal partial class CreateEntityUniqueConstraintsWithForeignKeyCommandHandler : CreateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase
{
	public CreateEntityUniqueConstraintsWithForeignKeyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> EntityUniqueConstraintsRelatedForeignKeyFactory,
		IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,EntityUniqueConstraintsRelatedForeignKeyFactory, entityFactory)
	{
	}
}


internal abstract class CreateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase : CommandBase<CreateEntityUniqueConstraintsWithForeignKeyCommand,EntityUniqueConstraintsWithForeignKeyEntity>, IRequestHandler <CreateEntityUniqueConstraintsWithForeignKeyCommand, EntityUniqueConstraintsWithForeignKeyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> EntityUniqueConstraintsRelatedForeignKeyFactory;

	public CreateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> EntityUniqueConstraintsRelatedForeignKeyFactory,
		IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.EntityUniqueConstraintsRelatedForeignKeyFactory = EntityUniqueConstraintsRelatedForeignKeyFactory;
	}

	public virtual async Task<EntityUniqueConstraintsWithForeignKeyKeyDto> Handle(CreateEntityUniqueConstraintsWithForeignKeyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.EntityUniqueConstraintsRelatedForeignKeyId is not null)
		{
			var relatedKey = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(request.EntityDto.EntityUniqueConstraintsRelatedForeignKeyId.NonNullValue<System.Int32>());
			var relatedEntity = await DbContext.EntityUniqueConstraintsRelatedForeignKeys.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToEntityUniqueConstraintsRelatedForeignKey(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey", request.EntityDto.EntityUniqueConstraintsRelatedForeignKeyId.NonNullValue<System.Int32>().ToString());
		}
		else if(request.EntityDto.EntityUniqueConstraintsRelatedForeignKey is not null)
		{
			var relatedEntity = EntityUniqueConstraintsRelatedForeignKeyFactory.CreateEntity(request.EntityDto.EntityUniqueConstraintsRelatedForeignKey);
			entityToCreate.CreateRefToEntityUniqueConstraintsRelatedForeignKey(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.EntityUniqueConstraintsWithForeignKeys.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new EntityUniqueConstraintsWithForeignKeyKeyDto(entityToCreate.Id.Value);
	}
}