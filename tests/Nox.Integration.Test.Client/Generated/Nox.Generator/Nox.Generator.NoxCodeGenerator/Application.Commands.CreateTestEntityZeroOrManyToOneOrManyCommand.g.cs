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
using TestEntityZeroOrManyToOneOrMany = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrManyToOneOrManyCommand(TestEntityZeroOrManyToOneOrManyCreateDto EntityDto) : IRequest<TestEntityZeroOrManyToOneOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrManyToOneOrManyCommandHandler: CreateTestEntityZeroOrManyToOneOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrManyToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrMany, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> testentityoneormanytozeroormanyfactory,
		IEntityFactory<TestEntityZeroOrManyToOneOrMany, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,testentityoneormanytozeroormanyfactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyToOneOrManyCommandHandlerBase: CommandBase<CreateTestEntityZeroOrManyToOneOrManyCommand,TestEntityZeroOrManyToOneOrMany>, IRequestHandler <CreateTestEntityZeroOrManyToOneOrManyCommand, TestEntityZeroOrManyToOneOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityZeroOrManyToOneOrMany, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestEntityOneOrManyToZeroOrMany, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> _testentityoneormanytozeroormanyfactory;

	public CreateTestEntityZeroOrManyToOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrMany, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> testentityoneormanytozeroormanyfactory,
		IEntityFactory<TestEntityZeroOrManyToOneOrMany, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityoneormanytozeroormanyfactory = testentityoneormanytozeroormanyfactory;
	}

	public virtual async Task<TestEntityZeroOrManyToOneOrManyKeyDto> Handle(CreateTestEntityZeroOrManyToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestEntityOneOrManyToZeroOrMany)
		{
			var relatedEntity = _testentityoneormanytozeroormanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestEntityOneOrManyToZeroOrMany(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityZeroOrManyToOneOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyToOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}