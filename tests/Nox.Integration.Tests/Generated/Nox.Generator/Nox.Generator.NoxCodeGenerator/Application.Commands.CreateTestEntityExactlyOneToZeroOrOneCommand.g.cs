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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityExactlyOneToZeroOrOneCommand(TestEntityExactlyOneToZeroOrOneCreateDto EntityDto) : IRequest<TestEntityExactlyOneToZeroOrOneKeyDto>;

internal partial class CreateTestEntityExactlyOneToZeroOrOneCommandHandler : CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase
{
	public CreateTestEntityExactlyOneToZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> testentityzerooronetoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityzerooronetoexactlyonefactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneToZeroOrOneCommand,TestEntityExactlyOneToZeroOrOneEntity>, IRequestHandler <CreateTestEntityExactlyOneToZeroOrOneCommand, TestEntityExactlyOneToZeroOrOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> _testentityzerooronetoexactlyonefactory;

	public CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> testentityzerooronetoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
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
		if(request.EntityDto.TestEntityZeroOrOneToExactlyOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrOneToExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityZeroOrOneToExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToExactlyOne", request.EntityDto.TestEntityZeroOrOneToExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrOneToExactlyOne is not null)
		{
			var relatedEntity = _testentityzerooronetoexactlyonefactory.CreateEntity(request.EntityDto.TestEntityZeroOrOneToExactlyOne);
			entityToCreate.CreateRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityExactlyOneToZeroOrOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}