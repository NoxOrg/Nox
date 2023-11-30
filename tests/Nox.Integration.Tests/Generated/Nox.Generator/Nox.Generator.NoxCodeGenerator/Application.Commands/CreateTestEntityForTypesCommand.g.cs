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
using FluentValidation;
using Microsoft.Extensions.Logging;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityForTypesCommand(TestEntityForTypesCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityForTypesKeyDto>;

internal partial class CreateTestEntityForTypesCommandHandler : CreateTestEntityForTypesCommandHandlerBase
{
	public CreateTestEntityForTypesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityForTypesCommandHandlerBase : CommandBase<CreateTestEntityForTypesCommand,TestEntityForTypesEntity>, IRequestHandler <CreateTestEntityForTypesCommand, TestEntityForTypesKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> EntityFactory;

	public CreateTestEntityForTypesCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForTypesKeyDto> Handle(CreateTestEntityForTypesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityForTypes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityForTypesKeyDto(entityToCreate.Id.Value);
	}
}