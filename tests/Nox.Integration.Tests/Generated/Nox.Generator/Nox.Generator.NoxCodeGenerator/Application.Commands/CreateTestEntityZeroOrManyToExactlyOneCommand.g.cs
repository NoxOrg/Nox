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
using TestEntityZeroOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrManyToExactlyOneCommand(TestEntityZeroOrManyToExactlyOneCreateDto EntityDto) : IRequest<TestEntityZeroOrManyToExactlyOneKeyDto>;

internal partial class CreateTestEntityZeroOrManyToExactlyOneCommandHandler : CreateTestEntityZeroOrManyToExactlyOneCommandHandlerBase
{
	public CreateTestEntityZeroOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> TestEntityExactlyOneToZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityExactlyOneToZeroOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyToExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityZeroOrManyToExactlyOneCommand,TestEntityZeroOrManyToExactlyOneEntity>, IRequestHandler <CreateTestEntityZeroOrManyToExactlyOneCommand, TestEntityZeroOrManyToExactlyOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> TestEntityExactlyOneToZeroOrManyFactory;

	public CreateTestEntityZeroOrManyToExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> TestEntityExactlyOneToZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityExactlyOneToZeroOrManyFactory = TestEntityExactlyOneToZeroOrManyFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToExactlyOneKeyDto> Handle(CreateTestEntityZeroOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.TestEntityExactlyOneToZeroOrMany)
		{
			var relatedEntity = TestEntityExactlyOneToZeroOrManyFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToTestEntityExactlyOneToZeroOrMany(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityZeroOrManyToExactlyOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyToExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}