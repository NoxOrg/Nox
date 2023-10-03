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
using TestEntityZeroOrManyToZeroOrOne = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrManyToZeroOrOneCreateDto EntityDto) : IRequest<TestEntityZeroOrManyToZeroOrOneKeyDto>;

internal partial class CreateTestEntityZeroOrManyToZeroOrOneCommandHandler: CreateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase
{
	public CreateTestEntityZeroOrManyToZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToZeroOrMany, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> testentityzerooronetozeroormanyfactory,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOne, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityzerooronetozeroormanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase: CommandBase<CreateTestEntityZeroOrManyToZeroOrOneCommand,TestEntityZeroOrManyToZeroOrOne>, IRequestHandler <CreateTestEntityZeroOrManyToZeroOrOneCommand, TestEntityZeroOrManyToZeroOrOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityZeroOrManyToZeroOrOne, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestEntityZeroOrOneToZeroOrMany, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> _testentityzerooronetozeroormanyfactory;

	public CreateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToZeroOrMany, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> testentityzerooronetozeroormanyfactory,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOne, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityzerooronetozeroormanyfactory = testentityzerooronetozeroormanyfactory;
	}

	public virtual async Task<TestEntityZeroOrManyToZeroOrOneKeyDto> Handle(CreateTestEntityZeroOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestEntityZeroOrOneToZeroOrMany)
		{
			var relatedEntity = _testentityzerooronetozeroormanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestEntityZeroOrOneToZeroOrMany(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityZeroOrManyToZeroOrOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyToZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}