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
using TestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyCreateDto EntityDto) : IRequest<TestEntityOwnedRelationshipOneOrManyKeyDto>;

internal partial class CreateTestEntityOwnedRelationshipOneOrManyCommandHandler : CreateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public CreateTestEntityOwnedRelationshipOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityOwnedRelationshipOneOrManyCommand,TestEntityOwnedRelationshipOneOrManyEntity>, IRequestHandler <CreateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> EntityFactory;

	public CreateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipOneOrManyKeyDto> Handle(CreateTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityOwnedRelationshipOneOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityOwnedRelationshipOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}