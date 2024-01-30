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
using TestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityTwoRelationshipsOneToManyCommand(TestEntityTwoRelationshipsOneToManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityTwoRelationshipsOneToManyKeyDto>;

internal partial class CreateTestEntityTwoRelationshipsOneToManyCommandHandler : CreateTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public CreateTestEntityTwoRelationshipsOneToManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> SecondTestEntityTwoRelationshipsOneToManyFactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(repository, noxSolution,SecondTestEntityTwoRelationshipsOneToManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<CreateTestEntityTwoRelationshipsOneToManyCommand,TestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler <CreateTestEntityTwoRelationshipsOneToManyCommand, TestEntityTwoRelationshipsOneToManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> SecondTestEntityTwoRelationshipsOneToManyFactory;

	protected CreateTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> SecondTestEntityTwoRelationshipsOneToManyFactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.SecondTestEntityTwoRelationshipsOneToManyFactory = SecondTestEntityTwoRelationshipsOneToManyFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToManyKeyDto> Handle(CreateTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestRelationshipOneId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestRelationshipOneId)
			{
				var relatedKey = Dto.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<SecondTestEntityTwoRelationshipsOneToMany>(relatedKey);

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
				var relatedEntity = await SecondTestEntityTwoRelationshipsOneToManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
			}
		}
		if(request.EntityDto.TestRelationshipTwoId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestRelationshipTwoId)
			{
				var relatedKey = Dto.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<SecondTestEntityTwoRelationshipsOneToMany>(relatedKey);

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
				var relatedEntity = await SecondTestEntityTwoRelationshipsOneToManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityTwoRelationshipsOneToMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityTwoRelationshipsOneToManyKeyDto(entityToCreate.Id.Value);
	}
}