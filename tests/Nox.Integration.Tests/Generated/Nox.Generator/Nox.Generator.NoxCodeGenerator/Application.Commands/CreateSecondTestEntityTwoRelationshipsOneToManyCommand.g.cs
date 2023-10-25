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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityTwoRelationshipsOneToManyCommand(SecondTestEntityTwoRelationshipsOneToManyCreateDto EntityDto) : IRequest<SecondTestEntityTwoRelationshipsOneToManyKeyDto>;

internal partial class CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandler : CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> TestEntityTwoRelationshipsOneToManyFactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityTwoRelationshipsOneToManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<CreateSecondTestEntityTwoRelationshipsOneToManyCommand,SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler <CreateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> TestEntityTwoRelationshipsOneToManyFactory;

	public CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> TestEntityTwoRelationshipsOneToManyFactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityTwoRelationshipsOneToManyFactory = TestEntityTwoRelationshipsOneToManyFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToManyKeyDto> Handle(CreateSecondTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestRelationshipOneOnOtherSideId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOneOnOtherSide", request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipOneOnOtherSide is not null)
		{
			var relatedEntity = TestEntityTwoRelationshipsOneToManyFactory.CreateEntity(request.EntityDto.TestRelationshipOneOnOtherSide);
			entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
		}
		if(request.EntityDto.TestRelationshipTwoOnOtherSideId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwoOnOtherSide", request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipTwoOnOtherSide is not null)
		{
			var relatedEntity = TestEntityTwoRelationshipsOneToManyFactory.CreateEntity(request.EntityDto.TestRelationshipTwoOnOtherSide);
			entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.SecondTestEntityTwoRelationshipsOneToManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsOneToManyKeyDto(entityToCreate.Id.Value);
	}
}