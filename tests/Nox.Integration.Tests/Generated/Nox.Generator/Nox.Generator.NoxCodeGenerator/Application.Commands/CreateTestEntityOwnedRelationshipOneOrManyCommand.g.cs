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
using TestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyCreateDto EntityDto) : IRequest<TestEntityOwnedRelationshipOneOrManyKeyDto>;

internal partial class CreateTestEntityOwnedRelationshipOneOrManyCommandHandler : CreateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public CreateTestEntityOwnedRelationshipOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityOwnedRelationshipOneOrManyCommand,TestEntityOwnedRelationshipOneOrManyEntity>, IRequestHandler <CreateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> _entityFactory;

	public CreateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipOneOrManyKeyDto> Handle(CreateTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityOwnedRelationshipOneOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityOwnedRelationshipOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}