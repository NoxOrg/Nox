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
using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityWithNuidCommand(TestEntityWithNuidCreateDto EntityDto) : IRequest<TestEntityWithNuidKeyDto>;

internal partial class CreateTestEntityWithNuidCommandHandler : CreateTestEntityWithNuidCommandHandlerBase
{
	public CreateTestEntityWithNuidCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityWithNuidCommandHandlerBase : CommandBase<CreateTestEntityWithNuidCommand,TestEntityWithNuidEntity>, IRequestHandler <CreateTestEntityWithNuidCommand, TestEntityWithNuidKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> _entityFactory;

	public CreateTestEntityWithNuidCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityWithNuidKeyDto> Handle(CreateTestEntityWithNuidCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityWithNuids.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityWithNuidKeyDto(entityToCreate.Id.Value);
	}
}