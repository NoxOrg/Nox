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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityOneOrManyToZeroOrOneCommand(TestEntityOneOrManyToZeroOrOneCreateDto EntityDto) : IRequest<TestEntityOneOrManyToZeroOrOneKeyDto>;

internal partial class CreateTestEntityOneOrManyToZeroOrOneCommandHandler : CreateTestEntityOneOrManyToZeroOrOneCommandHandlerBase
{
	public CreateTestEntityOneOrManyToZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> testentityzerooronetooneormanyfactory,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityzerooronetooneormanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOneOrManyToZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityOneOrManyToZeroOrOneCommand,TestEntityOneOrManyToZeroOrOneEntity>, IRequestHandler <CreateTestEntityOneOrManyToZeroOrOneCommand, TestEntityOneOrManyToZeroOrOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> _testentityzerooronetooneormanyfactory;

	public CreateTestEntityOneOrManyToZeroOrOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> testentityzerooronetooneormanyfactory,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityzerooronetooneormanyfactory = testentityzerooronetooneormanyfactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrOneKeyDto> Handle(CreateTestEntityOneOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestEntityZeroOrOneToOneOrMany)
		{
			var relatedEntity = _testentityzerooronetooneormanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestEntityZeroOrOneToOneOrMany(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityOneOrManyToZeroOrOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityOneOrManyToZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}