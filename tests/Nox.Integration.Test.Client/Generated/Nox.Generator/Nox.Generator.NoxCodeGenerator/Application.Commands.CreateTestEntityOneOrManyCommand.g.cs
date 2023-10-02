﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityOneOrMany = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityOneOrManyCommand(TestEntityOneOrManyCreateDto EntityDto) : IRequest<TestEntityOneOrManyKeyDto>;

internal partial class CreateTestEntityOneOrManyCommandHandler: CreateTestEntityOneOrManyCommandHandlerBase
{
	public CreateTestEntityOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> secondtestentityoneormanyfactory,
		IEntityFactory<TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,secondtestentityoneormanyfactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateTestEntityOneOrManyCommandHandlerBase: CommandBase<CreateTestEntityOneOrManyCommand,TestEntityOneOrMany>, IRequestHandler <CreateTestEntityOneOrManyCommand, TestEntityOneOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> _secondtestentityoneormanyfactory;

	public CreateTestEntityOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> secondtestentityoneormanyfactory,
		IEntityFactory<TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_secondtestentityoneormanyfactory = secondtestentityoneormanyfactory;
	}

	public virtual async Task<TestEntityOneOrManyKeyDto> Handle(CreateTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.SecondTestEntityOneOrManyRelationship)
		{
			var relatedEntity = _secondtestentityoneormanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToSecondTestEntityOneOrManyRelationship(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityOneOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}