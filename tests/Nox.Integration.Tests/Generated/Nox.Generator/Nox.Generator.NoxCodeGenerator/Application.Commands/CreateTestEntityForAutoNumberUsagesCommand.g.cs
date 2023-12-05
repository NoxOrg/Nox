﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityForAutoNumberUsagesCommand(TestEntityForAutoNumberUsagesCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityForAutoNumberUsagesKeyDto>;

internal partial class CreateTestEntityForAutoNumberUsagesCommandHandler : CreateTestEntityForAutoNumberUsagesCommandHandlerBase
{
	public CreateTestEntityForAutoNumberUsagesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityForAutoNumberUsagesCommandHandlerBase : CommandBase<CreateTestEntityForAutoNumberUsagesCommand,TestEntityForAutoNumberUsagesEntity>, IRequestHandler <CreateTestEntityForAutoNumberUsagesCommand, TestEntityForAutoNumberUsagesKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> EntityFactory;

	protected CreateTestEntityForAutoNumberUsagesCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForAutoNumberUsagesKeyDto> Handle(CreateTestEntityForAutoNumberUsagesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityForAutoNumberUsages.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityForAutoNumberUsagesKeyDto(entityToCreate.Id.Value);
	}
}