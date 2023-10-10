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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityOneOrManyToExactlyOneCommand(TestEntityOneOrManyToExactlyOneCreateDto EntityDto) : IRequest<TestEntityOneOrManyToExactlyOneKeyDto>;

internal partial class CreateTestEntityOneOrManyToExactlyOneCommandHandler : CreateTestEntityOneOrManyToExactlyOneCommandHandlerBase
{
	public CreateTestEntityOneOrManyToExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> testentityexactlyonetooneormanyfactory,
		IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityexactlyonetooneormanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOneOrManyToExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityOneOrManyToExactlyOneCommand,TestEntityOneOrManyToExactlyOneEntity>, IRequestHandler <CreateTestEntityOneOrManyToExactlyOneCommand, TestEntityOneOrManyToExactlyOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> _testentityexactlyonetooneormanyfactory;

	public CreateTestEntityOneOrManyToExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> testentityexactlyonetooneormanyfactory,
		IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityexactlyonetooneormanyfactory = testentityexactlyonetooneormanyfactory;
	}

	public virtual async Task<TestEntityOneOrManyToExactlyOneKeyDto> Handle(CreateTestEntityOneOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestEntityExactlyOneToOneOrMany)
		{
			var relatedEntity = _testentityexactlyonetooneormanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestEntityExactlyOneToOneOrMany(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityOneOrManyToExactlyOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityOneOrManyToExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}