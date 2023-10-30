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
using TestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityOwnedRelationshipZeroOrOneCommand(TestEntityOwnedRelationshipZeroOrOneCreateDto EntityDto) : IRequest<TestEntityOwnedRelationshipZeroOrOneKeyDto>;

internal partial class CreateTestEntityOwnedRelationshipZeroOrOneCommandHandler : CreateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase
{
	public CreateTestEntityOwnedRelationshipZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityOwnedRelationshipZeroOrOneCommand,TestEntityOwnedRelationshipZeroOrOneEntity>, IRequestHandler <CreateTestEntityOwnedRelationshipZeroOrOneCommand, TestEntityOwnedRelationshipZeroOrOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> EntityFactory;

	public CreateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipZeroOrOneKeyDto> Handle(CreateTestEntityOwnedRelationshipZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityOwnedRelationshipZeroOrOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityOwnedRelationshipZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}