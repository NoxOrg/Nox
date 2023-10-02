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
using TestEntityExactlyOne = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityExactlyOneCommand(TestEntityExactlyOneCreateDto EntityDto) : IRequest<TestEntityExactlyOneKeyDto>;

internal partial class CreateTestEntityExactlyOneCommandHandler: CreateTestEntityExactlyOneCommandHandlerBase
{
	public CreateTestEntityExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> secondtestentityexactlyonefactory,
		IEntityFactory<TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,secondtestentityexactlyonefactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneCommandHandlerBase: CommandBase<CreateTestEntityExactlyOneCommand,TestEntityExactlyOne>, IRequestHandler <CreateTestEntityExactlyOneCommand, TestEntityExactlyOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> _secondtestentityexactlyonefactory;

	public CreateTestEntityExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> secondtestentityexactlyonefactory,
		IEntityFactory<TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_secondtestentityexactlyonefactory = secondtestentityexactlyonefactory;
	}

	public virtual async Task<TestEntityExactlyOneKeyDto> Handle(CreateTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.SecondTestEntityExactlyOneRelationship is not null)
		{
			var relatedEntity = _secondtestentityexactlyonefactory.CreateEntity(request.EntityDto.SecondTestEntityExactlyOneRelationship);
			entityToCreate.CreateRefToSecondTestEntityExactlyOneRelationship(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityExactlyOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}