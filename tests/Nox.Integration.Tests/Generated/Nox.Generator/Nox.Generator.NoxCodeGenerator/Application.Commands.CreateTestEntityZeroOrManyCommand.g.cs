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
using TestEntityZeroOrMany = TestWebApp.Domain.TestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrManyCommand(TestEntityZeroOrManyCreateDto EntityDto) : IRequest<TestEntityZeroOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrManyCommandHandler: CreateTestEntityZeroOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> secondtestentityzeroormanyfactory,
		IEntityFactory<TestEntityZeroOrMany, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,secondtestentityzeroormanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyCommandHandlerBase: CommandBase<CreateTestEntityZeroOrManyCommand,TestEntityZeroOrMany>, IRequestHandler <CreateTestEntityZeroOrManyCommand, TestEntityZeroOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityZeroOrMany, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> _secondtestentityzeroormanyfactory;

	public CreateTestEntityZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> secondtestentityzeroormanyfactory,
		IEntityFactory<TestEntityZeroOrMany, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_secondtestentityzeroormanyfactory = secondtestentityzeroormanyfactory;
	}

	public virtual async Task<TestEntityZeroOrManyKeyDto> Handle(CreateTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.SecondTestEntityZeroOrManyRelationship)
		{
			var relatedEntity = _secondtestentityzeroormanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToSecondTestEntityZeroOrManyRelationship(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityZeroOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}