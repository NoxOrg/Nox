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
using ThirdTestEntityZeroOrManyEntity = TestWebApp.Domain.ThirdTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public record CreateThirdTestEntityZeroOrManyCommand(ThirdTestEntityZeroOrManyCreateDto EntityDto) : IRequest<ThirdTestEntityZeroOrManyKeyDto>;

internal partial class CreateThirdTestEntityZeroOrManyCommandHandler : CreateThirdTestEntityZeroOrManyCommandHandlerBase
{
	public CreateThirdTestEntityZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityOneOrMany, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> thirdtestentityoneormanyfactory,
		IEntityFactory<ThirdTestEntityZeroOrManyEntity, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,thirdtestentityoneormanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateThirdTestEntityZeroOrManyCommandHandlerBase : CommandBase<CreateThirdTestEntityZeroOrManyCommand,ThirdTestEntityZeroOrManyEntity>, IRequestHandler <CreateThirdTestEntityZeroOrManyCommand, ThirdTestEntityZeroOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<ThirdTestEntityZeroOrManyEntity, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.ThirdTestEntityOneOrMany, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> _thirdtestentityoneormanyfactory;

	public CreateThirdTestEntityZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityOneOrMany, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> thirdtestentityoneormanyfactory,
		IEntityFactory<ThirdTestEntityZeroOrManyEntity, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_thirdtestentityoneormanyfactory = thirdtestentityoneormanyfactory;
	}

	public virtual async Task<ThirdTestEntityZeroOrManyKeyDto> Handle(CreateThirdTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.ThirdTestEntityOneOrManyRelationship)
		{
			var relatedEntity = _thirdtestentityoneormanyfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToThirdTestEntityOneOrManyRelationship(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.ThirdTestEntityZeroOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new ThirdTestEntityZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}