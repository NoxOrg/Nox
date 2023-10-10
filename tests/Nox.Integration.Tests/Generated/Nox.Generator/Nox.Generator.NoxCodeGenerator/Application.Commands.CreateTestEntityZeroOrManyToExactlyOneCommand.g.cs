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
using TestEntityZeroOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrManyToExactlyOneCommand(TestEntityZeroOrManyToExactlyOneCreateDto EntityDto) : IRequest<TestEntityZeroOrManyToExactlyOneKeyDto>;

internal partial class CreateTestEntityZeroOrManyToExactlyOneCommandHandler : CreateTestEntityZeroOrManyToExactlyOneCommandHandlerBase
{
	public CreateTestEntityZeroOrManyToExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> testentityexactlyonetozeroormanyfactory,
		IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityexactlyonetozeroormanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyToExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityZeroOrManyToExactlyOneCommand,TestEntityZeroOrManyToExactlyOneEntity>, IRequestHandler <CreateTestEntityZeroOrManyToExactlyOneCommand, TestEntityZeroOrManyToExactlyOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> _testentityexactlyonetozeroormanyfactory;

	public CreateTestEntityZeroOrManyToExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> testentityexactlyonetozeroormanyfactory,
		IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityexactlyonetozeroormanyfactory = testentityexactlyonetozeroormanyfactory;
	}

	public virtual async Task<TestEntityZeroOrManyToExactlyOneKeyDto> Handle(CreateTestEntityZeroOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestEntityExactlyOneToZeroOrMany)
		{
			var relatedEntity = _testentityexactlyonetozeroormanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestEntityExactlyOneToZeroOrMany(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityZeroOrManyToExactlyOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyToExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}