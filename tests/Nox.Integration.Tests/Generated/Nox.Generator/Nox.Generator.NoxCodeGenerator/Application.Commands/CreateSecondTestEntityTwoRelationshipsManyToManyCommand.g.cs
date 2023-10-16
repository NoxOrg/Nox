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
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityTwoRelationshipsManyToManyCommand(SecondTestEntityTwoRelationshipsManyToManyCreateDto EntityDto) : IRequest<SecondTestEntityTwoRelationshipsManyToManyKeyDto>;

internal partial class CreateSecondTestEntityTwoRelationshipsManyToManyCommandHandler : CreateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public CreateSecondTestEntityTwoRelationshipsManyToManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> testentitytworelationshipsmanytomanyfactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentitytworelationshipsmanytomanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<CreateSecondTestEntityTwoRelationshipsManyToManyCommand,SecondTestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler <CreateSecondTestEntityTwoRelationshipsManyToManyCommand, SecondTestEntityTwoRelationshipsManyToManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> _testentitytworelationshipsmanytomanyfactory;

	public CreateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> testentitytworelationshipsmanytomanyfactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentitytworelationshipsmanytomanyfactory = testentitytworelationshipsmanytomanyfactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsManyToManyKeyDto> Handle(CreateSecondTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestRelationshipOneOnOtherSide)
		{
			var relatedEntity = _testentitytworelationshipsmanytomanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.TestRelationshipTwoOnOtherSide)
		{
			var relatedEntity = _testentitytworelationshipsmanytomanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.SecondTestEntityTwoRelationshipsManyToManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsManyToManyKeyDto(entityToCreate.Id.Value);
	}
}