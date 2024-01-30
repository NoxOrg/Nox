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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityForAutoNumberUsagesCommand(TestEntityForAutoNumberUsagesCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityForAutoNumberUsagesKeyDto>;

internal partial class CreateTestEntityForAutoNumberUsagesCommandHandler : CreateTestEntityForAutoNumberUsagesCommandHandlerBase
{
	public CreateTestEntityForAutoNumberUsagesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityForAutoNumberUsagesCommandHandlerBase : CommandBase<CreateTestEntityForAutoNumberUsagesCommand,TestEntityForAutoNumberUsagesEntity>, IRequestHandler <CreateTestEntityForAutoNumberUsagesCommand, TestEntityForAutoNumberUsagesKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> EntityFactory;

	protected CreateTestEntityForAutoNumberUsagesCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForAutoNumberUsagesKeyDto> Handle(CreateTestEntityForAutoNumberUsagesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityForAutoNumberUsages>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityForAutoNumberUsagesKeyDto(entityToCreate.Id.Value);
	}
}