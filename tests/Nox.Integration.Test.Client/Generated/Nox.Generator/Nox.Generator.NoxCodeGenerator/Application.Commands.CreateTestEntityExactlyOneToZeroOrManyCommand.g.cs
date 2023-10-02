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
using TestEntityExactlyOneToZeroOrMany = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityExactlyOneToZeroOrManyCommand(TestEntityExactlyOneToZeroOrManyCreateDto EntityDto) : IRequest<TestEntityExactlyOneToZeroOrManyKeyDto>;

internal partial class CreateTestEntityExactlyOneToZeroOrManyCommandHandler: CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase
{
	public CreateTestEntityExactlyOneToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> testentityzeroormanytoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,testentityzeroormanytoexactlyonefactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase: CommandBase<CreateTestEntityExactlyOneToZeroOrManyCommand,TestEntityExactlyOneToZeroOrMany>, IRequestHandler <CreateTestEntityExactlyOneToZeroOrManyCommand, TestEntityExactlyOneToZeroOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> _testentityzeroormanytoexactlyonefactory;

	public CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> testentityzeroormanytoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityzeroormanytoexactlyonefactory = testentityzeroormanytoexactlyonefactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrManyKeyDto> Handle(CreateTestEntityExactlyOneToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityZeroOrManyToExactlyOne is not null)
		{
			var relatedEntity = _testentityzeroormanytoexactlyonefactory.CreateEntity(request.EntityDto.TestEntityZeroOrManyToExactlyOne);
			entityToCreate.CreateRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityExactlyOneToZeroOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}