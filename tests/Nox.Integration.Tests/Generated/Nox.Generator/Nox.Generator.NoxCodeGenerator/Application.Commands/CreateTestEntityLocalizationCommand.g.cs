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
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityLocalizationCommand(TestEntityLocalizationCreateDto EntityDto) : IRequest<TestEntityLocalizationKeyDto>;

internal partial class CreateTestEntityLocalizationCommandHandler : CreateTestEntityLocalizationCommandHandlerBase
{
	public CreateTestEntityLocalizationCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityLocalizationCommandHandlerBase : CommandBase<CreateTestEntityLocalizationCommand,TestEntityLocalizationEntity>, IRequestHandler <CreateTestEntityLocalizationCommand, TestEntityLocalizationKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> _entityFactory;

	public CreateTestEntityLocalizationCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityLocalizationKeyDto> Handle(CreateTestEntityLocalizationCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityLocalizations.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityLocalizationKeyDto(entityToCreate.Id.Value);
	}
}