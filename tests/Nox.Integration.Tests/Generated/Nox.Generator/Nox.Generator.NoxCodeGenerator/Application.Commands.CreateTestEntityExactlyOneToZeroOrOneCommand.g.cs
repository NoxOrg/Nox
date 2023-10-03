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
using TestEntityExactlyOneToZeroOrOne = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityExactlyOneToZeroOrOneCommand(TestEntityExactlyOneToZeroOrOneCreateDto EntityDto) : IRequest<TestEntityExactlyOneToZeroOrOneKeyDto>;

internal partial class CreateTestEntityExactlyOneToZeroOrOneCommandHandler: CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase
{
	public CreateTestEntityExactlyOneToZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> testentityzerooronetoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,testentityzerooronetoexactlyonefactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase: CommandBase<CreateTestEntityExactlyOneToZeroOrOneCommand,TestEntityExactlyOneToZeroOrOne>, IRequestHandler <CreateTestEntityExactlyOneToZeroOrOneCommand, TestEntityExactlyOneToZeroOrOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> _testentityzerooronetoexactlyonefactory;

	public CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> testentityzerooronetoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityzerooronetoexactlyonefactory = testentityzerooronetoexactlyonefactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrOneKeyDto> Handle(CreateTestEntityExactlyOneToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityZeroOrOneToExactlyOne is not null)
		{
			var relatedEntity = _testentityzerooronetoexactlyonefactory.CreateEntity(request.EntityDto.TestEntityZeroOrOneToExactlyOne);
			entityToCreate.CreateRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityExactlyOneToZeroOrOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}