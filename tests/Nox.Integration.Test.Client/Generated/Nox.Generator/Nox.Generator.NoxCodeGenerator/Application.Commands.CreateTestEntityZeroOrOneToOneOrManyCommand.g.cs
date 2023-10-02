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
using TestEntityZeroOrOneToOneOrMany = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrOneToOneOrManyCommand(TestEntityZeroOrOneToOneOrManyCreateDto EntityDto) : IRequest<TestEntityZeroOrOneToOneOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrOneToOneOrManyCommandHandler: CreateTestEntityZeroOrOneToOneOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrOne, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> testentityoneormanytozerooronefactory,
		IEntityFactory<TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,testentityoneormanytozerooronefactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneToOneOrManyCommandHandlerBase: CommandBase<CreateTestEntityZeroOrOneToOneOrManyCommand,TestEntityZeroOrOneToOneOrMany>, IRequestHandler <CreateTestEntityZeroOrOneToOneOrManyCommand, TestEntityZeroOrOneToOneOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestEntityOneOrManyToZeroOrOne, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> _testentityoneormanytozerooronefactory;

	public CreateTestEntityZeroOrOneToOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrOne, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> testentityoneormanytozerooronefactory,
		IEntityFactory<TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityoneormanytozerooronefactory = testentityoneormanytozerooronefactory;
	}

	public virtual async Task<TestEntityZeroOrOneToOneOrManyKeyDto> Handle(CreateTestEntityZeroOrOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityOneOrManyToZeroOrOne is not null)
		{
			var relatedEntity = _testentityoneormanytozerooronefactory.CreateEntity(request.EntityDto.TestEntityOneOrManyToZeroOrOne);
			entityToCreate.CreateRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityZeroOrOneToOneOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityZeroOrOneToOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}