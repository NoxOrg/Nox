﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Commands;

public partial record CreateEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsRelatedForeignKeyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<EntityUniqueConstraintsRelatedForeignKeyKeyDto>;

internal partial class CreateEntityUniqueConstraintsRelatedForeignKeyCommandHandler : CreateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase
{
	public CreateEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> EntityUniqueConstraintsWithForeignKeyFactory,
		IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> entityFactory)
		: base(repository, noxSolution,EntityUniqueConstraintsWithForeignKeyFactory, entityFactory)
	{
	}
}


internal abstract class CreateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase : CommandBase<CreateEntityUniqueConstraintsRelatedForeignKeyCommand,EntityUniqueConstraintsRelatedForeignKeyEntity>, IRequestHandler <CreateEntityUniqueConstraintsRelatedForeignKeyCommand, EntityUniqueConstraintsRelatedForeignKeyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> EntityUniqueConstraintsWithForeignKeyFactory;

	protected CreateEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> EntityUniqueConstraintsWithForeignKeyFactory,
		IEntityFactory<EntityUniqueConstraintsRelatedForeignKeyEntity, EntityUniqueConstraintsRelatedForeignKeyCreateDto, EntityUniqueConstraintsRelatedForeignKeyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
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
				var relatedKey = Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<EntityUniqueConstraintsWithForeignKey>(relatedKey);

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
		await Repository.AddAsync<EntityUniqueConstraintsRelatedForeignKey>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new EntityUniqueConstraintsRelatedForeignKeyKeyDto(entityToCreate.Id.Value);
	}
}