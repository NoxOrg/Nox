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
using TestEntityForTypes = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityForTypesCommand(TestEntityForTypesCreateDto EntityDto) : IRequest<TestEntityForTypesKeyDto>;

internal partial class CreateTestEntityForTypesCommandHandler: CreateTestEntityForTypesCommandHandlerBase
{
	public CreateTestEntityForTypesCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypes, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityForTypesCommandHandlerBase: CommandBase<CreateTestEntityForTypesCommand,TestEntityForTypes>, IRequestHandler <CreateTestEntityForTypesCommand, TestEntityForTypesKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityForTypes, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> _entityFactory;

	public CreateTestEntityForTypesCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypes, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForTypesKeyDto> Handle(CreateTestEntityForTypesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityForTypes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityForTypesKeyDto(entityToCreate.Id.Value);
	}
}