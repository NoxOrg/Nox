// Generated

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
using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityWithNuidCommand(TestEntityWithNuidCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityWithNuidKeyDto>;

internal partial class CreateTestEntityWithNuidCommandHandler : CreateTestEntityWithNuidCommandHandlerBase
{
	public CreateTestEntityWithNuidCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityWithNuidCommandHandlerBase : CommandBase<CreateTestEntityWithNuidCommand,TestEntityWithNuidEntity>, IRequestHandler <CreateTestEntityWithNuidCommand, TestEntityWithNuidKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> EntityFactory;

	public CreateTestEntityWithNuidCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityWithNuidKeyDto> Handle(CreateTestEntityWithNuidCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityWithNuids.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityWithNuidKeyDto(entityToCreate.Id.Value);
	}
}