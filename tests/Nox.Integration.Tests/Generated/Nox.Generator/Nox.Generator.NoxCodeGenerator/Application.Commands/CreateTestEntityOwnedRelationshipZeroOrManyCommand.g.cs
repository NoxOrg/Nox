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
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityOwnedRelationshipZeroOrManyKeyDto>;

internal partial class CreateTestEntityOwnedRelationshipZeroOrManyCommandHandler : CreateTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public CreateTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityOwnedRelationshipZeroOrManyCommand,TestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler <CreateTestEntityOwnedRelationshipZeroOrManyCommand, TestEntityOwnedRelationshipZeroOrManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto> EntityFactory;

	protected CreateTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipZeroOrManyKeyDto> Handle(CreateTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityOwnedRelationshipZeroOrMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityOwnedRelationshipZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateTestEntityOwnedRelationshipZeroOrManyValidator : AbstractValidator<CreateTestEntityOwnedRelationshipZeroOrManyCommand>
{
    public CreateTestEntityOwnedRelationshipZeroOrManyValidator()
    {
		RuleFor(x => x.EntityDto.SecEntityOwnedRelZeroOrManies)
			.Must(owned => owned.All(x => x.Id != null))
			.WithMessage("SecEntityOwnedRelZeroOrManies.Id is required.");
    }
}