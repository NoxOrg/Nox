﻿﻿// Generated

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
using SecondTestEntityOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityOneOrManyCommand(SecondTestEntityOneOrManyCreateDto EntityDto) : IRequest<SecondTestEntityOneOrManyKeyDto>;

internal partial class CreateSecondTestEntityOneOrManyCommandHandler : CreateSecondTestEntityOneOrManyCommandHandlerBase
{
	public CreateSecondTestEntityOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> TestEntityOneOrManyFactory,
		IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityOneOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityOneOrManyCommandHandlerBase : CommandBase<CreateSecondTestEntityOneOrManyCommand,SecondTestEntityOneOrManyEntity>, IRequestHandler <CreateSecondTestEntityOneOrManyCommand, SecondTestEntityOneOrManyKeyDto>
{
	protected readonly TestWebAppDbContext DbContext;
	protected readonly IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> TestEntityOneOrManyFactory;

	public CreateSecondTestEntityOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrMany, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> TestEntityOneOrManyFactory,
		IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityOneOrManyFactory = TestEntityOneOrManyFactory;
	}

	public virtual async Task<SecondTestEntityOneOrManyKeyDto> Handle(CreateSecondTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestEntityOneOrManyRelationship)
		{
			var relatedEntity = TestEntityOneOrManyFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestEntityOneOrManyRelationship(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.SecondTestEntityOneOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new SecondTestEntityOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}