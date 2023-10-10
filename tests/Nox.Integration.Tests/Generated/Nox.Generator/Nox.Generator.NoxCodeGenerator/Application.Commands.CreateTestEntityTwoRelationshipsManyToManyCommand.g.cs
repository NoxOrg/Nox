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
using Nox.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityTwoRelationshipsManyToManyCommand(TestEntityTwoRelationshipsManyToManyCreateDto EntityDto) : IRequest<TestEntityTwoRelationshipsManyToManyKeyDto>;

internal partial class CreateTestEntityTwoRelationshipsManyToManyCommandHandler : CreateTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public CreateTestEntityTwoRelationshipsManyToManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> secondtestentitytworelationshipsmanytomanyfactory,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,secondtestentitytworelationshipsmanytomanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<CreateTestEntityTwoRelationshipsManyToManyCommand,TestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler <CreateTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> _secondtestentitytworelationshipsmanytomanyfactory;

	public CreateTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> secondtestentitytworelationshipsmanytomanyfactory,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_secondtestentitytworelationshipsmanytomanyfactory = secondtestentitytworelationshipsmanytomanyfactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsManyToManyKeyDto> Handle(CreateTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestRelationshipOne)
		{
			var relatedEntity = _secondtestentitytworelationshipsmanytomanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.TestRelationshipTwo)
		{
			var relatedEntity = _secondtestentitytworelationshipsmanytomanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityTwoRelationshipsManyToManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityTwoRelationshipsManyToManyKeyDto(entityToCreate.Id.Value);
	}
}