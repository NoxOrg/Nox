﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using TestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityOwnedRelationshipZeroOrOneCommand(TestEntityOwnedRelationshipZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityOwnedRelationshipZeroOrOneKeyDto>;

internal partial class CreateTestEntityOwnedRelationshipZeroOrOneCommandHandler : CreateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase
{
	public CreateTestEntityOwnedRelationshipZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityOwnedRelationshipZeroOrOneCommand,TestEntityOwnedRelationshipZeroOrOneEntity>, IRequestHandler <CreateTestEntityOwnedRelationshipZeroOrOneCommand, TestEntityOwnedRelationshipZeroOrOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> EntityFactory;

	protected CreateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipZeroOrOneKeyDto> Handle(CreateTestEntityOwnedRelationshipZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityOwnedRelationshipZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateTestEntityOwnedRelationshipZeroOrOneValidator : AbstractValidator<CreateTestEntityOwnedRelationshipZeroOrOneCommand>
{
    public CreateTestEntityOwnedRelationshipZeroOrOneValidator()
    {
    }
}