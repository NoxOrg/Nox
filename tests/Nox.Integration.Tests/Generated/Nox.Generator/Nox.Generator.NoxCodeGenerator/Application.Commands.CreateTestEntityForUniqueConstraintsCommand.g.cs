﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityForUniqueConstraints = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityForUniqueConstraintsCommand(TestEntityForUniqueConstraintsCreateDto EntityDto) : IRequest<TestEntityForUniqueConstraintsKeyDto>;

internal partial class CreateTestEntityForUniqueConstraintsCommandHandler: CreateTestEntityForUniqueConstraintsCommandHandlerBase
{
	public CreateTestEntityForUniqueConstraintsCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForUniqueConstraints, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityForUniqueConstraintsCommandHandlerBase: CommandBase<CreateTestEntityForUniqueConstraintsCommand,TestEntityForUniqueConstraints>, IRequestHandler <CreateTestEntityForUniqueConstraintsCommand, TestEntityForUniqueConstraintsKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityForUniqueConstraints, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> _entityFactory;

	public CreateTestEntityForUniqueConstraintsCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForUniqueConstraints, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForUniqueConstraintsKeyDto> Handle(CreateTestEntityForUniqueConstraintsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);

		OnCompleted(request, entityToCreate);
		_dbContext.TestEntityForUniqueConstraints.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityForUniqueConstraintsKeyDto(entityToCreate.Id.Value);
	}
}