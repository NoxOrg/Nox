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
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneCreateDto EntityDto) : IRequest<TestEntityOwnedRelationshipExactlyOneKeyDto>;

internal partial class CreateTestEntityOwnedRelationshipExactlyOneCommandHandler : CreateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public CreateTestEntityOwnedRelationshipExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityOwnedRelationshipExactlyOneCommand,TestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler <CreateTestEntityOwnedRelationshipExactlyOneCommand, TestEntityOwnedRelationshipExactlyOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> _entityFactory;

	public CreateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipExactlyOneKeyDto> Handle(CreateTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityOwnedRelationshipExactlyOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityOwnedRelationshipExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}