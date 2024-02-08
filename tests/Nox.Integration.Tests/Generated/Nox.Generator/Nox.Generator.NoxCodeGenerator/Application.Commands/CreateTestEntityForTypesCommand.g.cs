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
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityForTypesCommand(TestEntityForTypesCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityForTypesKeyDto>;

internal partial class CreateTestEntityForTypesCommandHandler : CreateTestEntityForTypesCommandHandlerBase
{
	public CreateTestEntityForTypesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityForTypesCommandHandlerBase : CommandBase<CreateTestEntityForTypesCommand,TestEntityForTypesEntity>, IRequestHandler <CreateTestEntityForTypesCommand, TestEntityForTypesKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> EntityFactory;

	protected CreateTestEntityForTypesCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForTypesKeyDto> Handle(CreateTestEntityForTypesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestWebApp.Domain.TestEntityForTypes>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityForTypesKeyDto(entityToCreate.Id.Value);
	}
}