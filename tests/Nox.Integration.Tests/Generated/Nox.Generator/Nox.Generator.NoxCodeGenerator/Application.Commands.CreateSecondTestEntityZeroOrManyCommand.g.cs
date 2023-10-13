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
using Nox.Application.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityZeroOrManyCommand(SecondTestEntityZeroOrManyCreateDto EntityDto) : IRequest<SecondTestEntityZeroOrManyKeyDto>;

internal partial class CreateSecondTestEntityZeroOrManyCommandHandler : CreateSecondTestEntityZeroOrManyCommandHandlerBase
{
	public CreateSecondTestEntityZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrMany, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> testentityzeroormanyfactory,
		IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityzeroormanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityZeroOrManyCommandHandlerBase : CommandBase<CreateSecondTestEntityZeroOrManyCommand,SecondTestEntityZeroOrManyEntity>, IRequestHandler <CreateSecondTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrMany, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> _testentityzeroormanyfactory;

	public CreateSecondTestEntityZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrMany, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> testentityzeroormanyfactory,
		IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityzeroormanyfactory = testentityzeroormanyfactory;
	}

	public virtual async Task<SecondTestEntityZeroOrManyKeyDto> Handle(CreateSecondTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestEntityZeroOrManyRelationship)
		{
			var relatedEntity = _testentityzeroormanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestEntityZeroOrManyRelationship(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.SecondTestEntityZeroOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new SecondTestEntityZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}