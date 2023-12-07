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
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityLocalizationCommand(TestEntityLocalizationCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityLocalizationKeyDto>;

internal partial class CreateTestEntityLocalizationCommandHandler : CreateTestEntityLocalizationCommandHandlerBase
{
	public CreateTestEntityLocalizationCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> entityFactory,
		IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto> entityLocalizedFactory)
		: base(dbContext, noxSolution,entityFactory, entityLocalizedFactory)
	{
	}
}


internal abstract class CreateTestEntityLocalizationCommandHandlerBase : CommandBase<CreateTestEntityLocalizationCommand,TestEntityLocalizationEntity>, IRequestHandler <CreateTestEntityLocalizationCommand, TestEntityLocalizationKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> EntityFactory;
	protected readonly IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto> EntityLocalizedFactory;

	protected CreateTestEntityLocalizationCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> entityFactory,
		IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory; 
		EntityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<TestEntityLocalizationKeyDto> Handle(CreateTestEntityLocalizationCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityLocalizations.Add(entityToCreate);
        CreateLocalizations(entityToCreate, request.CultureCode);
		await DbContext.SaveChangesAsync();
		return new TestEntityLocalizationKeyDto(entityToCreate.Id.Value);
	}

	private void CreateLocalizations(TestEntityLocalizationEntity entity, Nox.Types.CultureCode cultureCode)
	{
		CreateTestEntityLocalizationLocalization(entity, cultureCode);
	}

	private void CreateTestEntityLocalizationLocalization(TestEntityLocalizationEntity entity, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = EntityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
		DbContext.TestEntityLocalizationsLocalized.Add(entityLocalized);
	}
}