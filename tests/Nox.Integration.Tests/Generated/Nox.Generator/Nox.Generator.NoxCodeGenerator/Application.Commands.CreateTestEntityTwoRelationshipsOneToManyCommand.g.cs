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

public record CreateTestEntityTwoRelationshipsOneToManyCommand(TestEntityTwoRelationshipsOneToManyCreateDto EntityDto) : IRequest<TestEntityTwoRelationshipsOneToManyKeyDto>;

internal partial class CreateTestEntityTwoRelationshipsOneToManyCommandHandler : CreateTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public CreateTestEntityTwoRelationshipsOneToManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> secondtestentitytworelationshipsonetomanyfactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,secondtestentitytworelationshipsonetomanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<CreateTestEntityTwoRelationshipsOneToManyCommand,TestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler <CreateTestEntityTwoRelationshipsOneToManyCommand, TestEntityTwoRelationshipsOneToManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> _secondtestentitytworelationshipsonetomanyfactory;

	public CreateTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> secondtestentitytworelationshipsonetomanyfactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_secondtestentitytworelationshipsonetomanyfactory = secondtestentitytworelationshipsonetomanyfactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToManyKeyDto> Handle(CreateTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestRelationshipOne)
		{
			var relatedEntity = _secondtestentitytworelationshipsonetomanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.TestRelationshipTwo)
		{
			var relatedEntity = _secondtestentitytworelationshipsonetomanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityTwoRelationshipsOneToManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityTwoRelationshipsOneToManyKeyDto(entityToCreate.Id.Value);
	}
}