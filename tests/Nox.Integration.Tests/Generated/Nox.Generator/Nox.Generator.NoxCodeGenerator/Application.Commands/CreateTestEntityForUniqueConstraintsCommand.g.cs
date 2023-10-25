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

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityForUniqueConstraintsCommand(TestEntityForUniqueConstraintsCreateDto EntityDto) : IRequest<TestEntityForUniqueConstraintsKeyDto>;

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

	public CreateTestEntityForUniqueConstraintsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForUniqueConstraintsKeyDto> Handle(CreateTestEntityForUniqueConstraintsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityForUniqueConstraints.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityForUniqueConstraintsKeyDto(entityToCreate.Id.Value);
	}
}