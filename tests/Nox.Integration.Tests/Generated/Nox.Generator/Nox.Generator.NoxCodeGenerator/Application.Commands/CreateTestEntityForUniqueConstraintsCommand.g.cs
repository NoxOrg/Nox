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
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityForUniqueConstraintsCommand(TestEntityForUniqueConstraintsCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityForUniqueConstraintsKeyDto>;

internal partial class CreateTestEntityForUniqueConstraintsCommandHandler : CreateTestEntityForUniqueConstraintsCommandHandlerBase
{
	public CreateTestEntityForUniqueConstraintsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityForUniqueConstraintsCommandHandlerBase : CommandBase<CreateTestEntityForUniqueConstraintsCommand,TestEntityForUniqueConstraintsEntity>, IRequestHandler <CreateTestEntityForUniqueConstraintsCommand, TestEntityForUniqueConstraintsKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> EntityFactory;

	protected CreateTestEntityForUniqueConstraintsCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForUniqueConstraintsKeyDto> Handle(CreateTestEntityForUniqueConstraintsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityForUniqueConstraints>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityForUniqueConstraintsKeyDto(entityToCreate.Id.Value);
	}
}