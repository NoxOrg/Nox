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
using TestEntityExactlyOneToOneOrMany = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityExactlyOneToOneOrManyCommand(TestEntityExactlyOneToOneOrManyCreateDto EntityDto) : IRequest<TestEntityExactlyOneToOneOrManyKeyDto>;

internal partial class CreateTestEntityExactlyOneToOneOrManyCommandHandler: CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase
{
	public CreateTestEntityExactlyOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> testentityoneormanytoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToOneOrMany, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,testentityoneormanytoexactlyonefactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase: CommandBase<CreateTestEntityExactlyOneToOneOrManyCommand,TestEntityExactlyOneToOneOrMany>, IRequestHandler <CreateTestEntityExactlyOneToOneOrManyCommand, TestEntityExactlyOneToOneOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityExactlyOneToOneOrMany, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> _testentityoneormanytoexactlyonefactory;

	public CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> testentityoneormanytoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToOneOrMany, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityoneormanytoexactlyonefactory = testentityoneormanytoexactlyonefactory;
	}

	public virtual async Task<TestEntityExactlyOneToOneOrManyKeyDto> Handle(CreateTestEntityExactlyOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityOneOrManyToExactlyOne is not null)
		{
			var relatedEntity = _testentityoneormanytoexactlyonefactory.CreateEntity(request.EntityDto.TestEntityOneOrManyToExactlyOne);
			entityToCreate.CreateRefToTestEntityOneOrManyToExactlyOne(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityExactlyOneToOneOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}