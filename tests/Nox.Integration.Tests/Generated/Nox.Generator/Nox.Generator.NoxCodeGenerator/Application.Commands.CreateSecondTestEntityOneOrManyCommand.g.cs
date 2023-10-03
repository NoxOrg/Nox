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
using SecondTestEntityOneOrMany = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityOneOrManyCommand(SecondTestEntityOneOrManyCreateDto EntityDto) : IRequest<SecondTestEntityOneOrManyKeyDto>;

internal partial class CreateSecondTestEntityOneOrManyCommandHandler: CreateSecondTestEntityOneOrManyCommandHandlerBase
{
	public CreateSecondTestEntityOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> testentityoneormanyfactory,
		IEntityFactory<SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,testentityoneormanyfactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateSecondTestEntityOneOrManyCommandHandlerBase: CommandBase<CreateSecondTestEntityOneOrManyCommand,SecondTestEntityOneOrMany>, IRequestHandler <CreateSecondTestEntityOneOrManyCommand, SecondTestEntityOneOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> _testentityoneormanyfactory;

	public CreateSecondTestEntityOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> testentityoneormanyfactory,
		IEntityFactory<SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityoneormanyfactory = testentityoneormanyfactory;
	}

	public virtual async Task<SecondTestEntityOneOrManyKeyDto> Handle(CreateSecondTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestEntityOneOrManyRelationship)
		{
			var relatedEntity = _testentityoneormanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestEntityOneOrManyRelationship(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.SecondTestEntityOneOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new SecondTestEntityOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}