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

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using TestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityOwnedRelationshipOneOrManyKeyDto>;

internal partial class CreateTestEntityOwnedRelationshipOneOrManyCommandHandler : CreateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public CreateTestEntityOwnedRelationshipOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityOwnedRelationshipOneOrManyCommand,TestEntityOwnedRelationshipOneOrManyEntity>, IRequestHandler <CreateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> EntityFactory;

	protected CreateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipOneOrManyKeyDto> Handle(CreateTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityOwnedRelationshipOneOrMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityOwnedRelationshipOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateTestEntityOwnedRelationshipOneOrManyValidator : AbstractValidator<CreateTestEntityOwnedRelationshipOneOrManyCommand>
{
    public CreateTestEntityOwnedRelationshipOneOrManyValidator()
    {
		RuleFor(x => x.EntityDto.SecEntityOwnedRelOneOrManies)
			.Must(owned => owned.All(x => x.Id != null))
			.WithMessage("SecEntityOwnedRelOneOrManies.Id is required.");
    }
}