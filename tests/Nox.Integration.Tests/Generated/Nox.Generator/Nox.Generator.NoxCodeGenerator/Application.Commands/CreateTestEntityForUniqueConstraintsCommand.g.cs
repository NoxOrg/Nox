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
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityForUniqueConstraintsCommand(TestEntityForUniqueConstraintsCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityForUniqueConstraintsKeyDto>;

internal partial class CreateTestEntityForUniqueConstraintsCommandHandler : CreateTestEntityForUniqueConstraintsCommandHandlerBase
{
	public CreateTestEntityForUniqueConstraintsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityForUniqueConstraintsCommandHandlerBase : CommandBase<CreateTestEntityForUniqueConstraintsCommand,TestEntityForUniqueConstraintsEntity>, IRequestHandler <CreateTestEntityForUniqueConstraintsCommand, TestEntityForUniqueConstraintsKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> EntityFactory;

	protected CreateTestEntityForUniqueConstraintsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForUniqueConstraintsKeyDto> Handle(CreateTestEntityForUniqueConstraintsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityForUniqueConstraints.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityForUniqueConstraintsKeyDto(entityToCreate.Id.Value);
	}
}