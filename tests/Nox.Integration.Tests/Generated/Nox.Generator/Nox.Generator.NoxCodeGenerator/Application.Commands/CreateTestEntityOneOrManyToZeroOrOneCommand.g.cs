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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityOneOrManyToZeroOrOneCommand(TestEntityOneOrManyToZeroOrOneCreateDto EntityDto) : IRequest<TestEntityOneOrManyToZeroOrOneKeyDto>;

internal partial class CreateTestEntityOneOrManyToZeroOrOneCommandHandler : CreateTestEntityOneOrManyToZeroOrOneCommandHandlerBase
{
	public CreateTestEntityOneOrManyToZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> TestEntityZeroOrOneToOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityZeroOrOneToOneOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOneOrManyToZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityOneOrManyToZeroOrOneCommand,TestEntityOneOrManyToZeroOrOneEntity>, IRequestHandler <CreateTestEntityOneOrManyToZeroOrOneCommand, TestEntityOneOrManyToZeroOrOneKeyDto>
{
	protected readonly TestWebAppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> TestEntityZeroOrOneToOneOrManyFactory;

	public CreateTestEntityOneOrManyToZeroOrOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> TestEntityZeroOrOneToOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrOneToOneOrManyFactory = TestEntityZeroOrOneToOneOrManyFactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrOneKeyDto> Handle(CreateTestEntityOneOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestEntityZeroOrOneToOneOrMany)
		{
			var relatedEntity = TestEntityZeroOrOneToOneOrManyFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestEntityZeroOrOneToOneOrMany(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityOneOrManyToZeroOrOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityOneOrManyToZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}