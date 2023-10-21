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
using TestEntityZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrManyCommand(TestEntityZeroOrManyCreateDto EntityDto) : IRequest<TestEntityZeroOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrManyCommandHandler : CreateTestEntityZeroOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> SecondTestEntityZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,SecondTestEntityZeroOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityZeroOrManyCommand,TestEntityZeroOrManyEntity>, IRequestHandler <CreateTestEntityZeroOrManyCommand, TestEntityZeroOrManyKeyDto>
{
	protected readonly TestWebAppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> SecondTestEntityZeroOrManyFactory;

	public CreateTestEntityZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> SecondTestEntityZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.SecondTestEntityZeroOrManyFactory = SecondTestEntityZeroOrManyFactory;
	}

	public virtual async Task<TestEntityZeroOrManyKeyDto> Handle(CreateTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.SecondTestEntityZeroOrManyRelationship)
		{
			var relatedEntity = SecondTestEntityZeroOrManyFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToSecondTestEntityZeroOrManyRelationship(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityZeroOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}