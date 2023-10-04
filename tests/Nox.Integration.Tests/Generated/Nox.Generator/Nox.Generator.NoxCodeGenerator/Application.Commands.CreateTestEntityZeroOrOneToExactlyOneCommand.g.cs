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
using TestEntityZeroOrOneToExactlyOne = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrOneToExactlyOneCommand(TestEntityZeroOrOneToExactlyOneCreateDto EntityDto) : IRequest<TestEntityZeroOrOneToExactlyOneKeyDto>;

internal partial class CreateTestEntityZeroOrOneToExactlyOneCommandHandler: CreateTestEntityZeroOrOneToExactlyOneCommandHandlerBase
{
	public CreateTestEntityZeroOrOneToExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> testentityexactlyonetozerooronefactory,
		IEntityFactory<TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityexactlyonetozerooronefactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneToExactlyOneCommandHandlerBase: CommandBase<CreateTestEntityZeroOrOneToExactlyOneCommand,TestEntityZeroOrOneToExactlyOne>, IRequestHandler <CreateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> _testentityexactlyonetozerooronefactory;

	public CreateTestEntityZeroOrOneToExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> testentityexactlyonetozerooronefactory,
		IEntityFactory<TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityexactlyonetozerooronefactory = testentityexactlyonetozerooronefactory;
	}

	public virtual async Task<TestEntityZeroOrOneToExactlyOneKeyDto> Handle(CreateTestEntityZeroOrOneToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityExactlyOneToZeroOrOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityExactlyOneToZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityExactlyOneToZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityExactlyOneToZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrOne", request.EntityDto.TestEntityExactlyOneToZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityExactlyOneToZeroOrOne is not null)
		{
			var relatedEntity = _testentityexactlyonetozerooronefactory.CreateEntity(request.EntityDto.TestEntityExactlyOneToZeroOrOne);
			entityToCreate.CreateRefToTestEntityExactlyOneToZeroOrOne(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityZeroOrOneToExactlyOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityZeroOrOneToExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}