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
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyCreateDto EntityDto) : IRequest<TestEntityOwnedRelationshipZeroOrManyKeyDto>;

internal partial class CreateTestEntityOwnedRelationshipZeroOrManyCommandHandler : CreateTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public CreateTestEntityOwnedRelationshipZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityOwnedRelationshipZeroOrManyCommand,TestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler <CreateTestEntityOwnedRelationshipZeroOrManyCommand, TestEntityOwnedRelationshipZeroOrManyKeyDto>
{
	protected readonly TestWebAppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto> EntityFactory;

	public CreateTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipZeroOrManyKeyDto> Handle(CreateTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityOwnedRelationshipZeroOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityOwnedRelationshipZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}