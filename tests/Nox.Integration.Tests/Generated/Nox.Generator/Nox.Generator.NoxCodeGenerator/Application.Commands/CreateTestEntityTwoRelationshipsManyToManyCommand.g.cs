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

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityTwoRelationshipsManyToManyCommand(TestEntityTwoRelationshipsManyToManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityTwoRelationshipsManyToManyKeyDto>;

internal partial class CreateTestEntityTwoRelationshipsManyToManyCommandHandler : CreateTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public CreateTestEntityTwoRelationshipsManyToManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> SecondTestEntityTwoRelationshipsManyToManyFactory,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
		: base(repository, noxSolution,SecondTestEntityTwoRelationshipsManyToManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<CreateTestEntityTwoRelationshipsManyToManyCommand,TestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler <CreateTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> SecondTestEntityTwoRelationshipsManyToManyFactory;

	protected CreateTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> SecondTestEntityTwoRelationshipsManyToManyFactory,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.SecondTestEntityTwoRelationshipsManyToManyFactory = SecondTestEntityTwoRelationshipsManyToManyFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsManyToManyKeyDto> Handle(CreateTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestRelationshipOneId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestRelationshipOneId)
			{
				var relatedKey = Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<SecondTestEntityTwoRelationshipsManyToMany>(relatedKey);

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
				var relatedEntity = await SecondTestEntityTwoRelationshipsManyToManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
			}
		}
		if(request.EntityDto.TestRelationshipTwoId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestRelationshipTwoId)
			{
				var relatedKey = Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<SecondTestEntityTwoRelationshipsManyToMany>(relatedKey);

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
				var relatedEntity = await SecondTestEntityTwoRelationshipsManyToManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityTwoRelationshipsManyToMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityTwoRelationshipsManyToManyKeyDto(entityToCreate.Id.Value);
	}
}