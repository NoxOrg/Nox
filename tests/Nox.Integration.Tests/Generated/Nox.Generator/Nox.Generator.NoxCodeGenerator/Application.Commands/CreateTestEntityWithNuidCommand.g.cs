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
using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityWithNuidCommand(TestEntityWithNuidCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityWithNuidKeyDto>;

internal partial class CreateTestEntityWithNuidCommandHandler : CreateTestEntityWithNuidCommandHandlerBase
{
	public CreateTestEntityWithNuidCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityWithNuidCommandHandlerBase : CommandBase<CreateTestEntityWithNuidCommand,TestEntityWithNuidEntity>, IRequestHandler <CreateTestEntityWithNuidCommand, TestEntityWithNuidKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> EntityFactory;

	protected CreateTestEntityWithNuidCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityWithNuidKeyDto> Handle(CreateTestEntityWithNuidCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityWithNuid>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityWithNuidKeyDto(entityToCreate.Id.Value);
	}
}