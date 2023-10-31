﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityTwoRelationshipsOneToManyCommand(TestEntityTwoRelationshipsOneToManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityTwoRelationshipsOneToManyKeyDto>;

internal partial class CreateTestEntityTwoRelationshipsOneToManyCommandHandler : CreateTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public CreateTestEntityTwoRelationshipsOneToManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> SecondTestEntityTwoRelationshipsOneToManyFactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,SecondTestEntityTwoRelationshipsOneToManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<CreateTestEntityTwoRelationshipsOneToManyCommand,TestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler <CreateTestEntityTwoRelationshipsOneToManyCommand, TestEntityTwoRelationshipsOneToManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> SecondTestEntityTwoRelationshipsOneToManyFactory;

	public CreateTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> SecondTestEntityTwoRelationshipsOneToManyFactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.SecondTestEntityTwoRelationshipsOneToManyFactory = SecondTestEntityTwoRelationshipsOneToManyFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToManyKeyDto> Handle(CreateTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestRelationshipOneId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestRelationshipOneId)
			{
				var relatedKey = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestRelationshipOne", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestRelationshipOne)
			{
				var relatedEntity = SecondTestEntityTwoRelationshipsOneToManyFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
			}
		}
		if(request.EntityDto.TestRelationshipTwoId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestRelationshipTwoId)
			{
				var relatedKey = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestRelationshipTwo", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestRelationshipTwo)
			{
				var relatedEntity = SecondTestEntityTwoRelationshipsOneToManyFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityTwoRelationshipsOneToManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityTwoRelationshipsOneToManyKeyDto(entityToCreate.Id.Value);
	}
}