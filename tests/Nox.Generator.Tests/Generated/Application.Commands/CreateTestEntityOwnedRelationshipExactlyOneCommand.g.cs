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
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityOwnedRelationshipExactlyOneKeyDto>;

internal partial class CreateTestEntityOwnedRelationshipExactlyOneCommandHandler : CreateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public CreateTestEntityOwnedRelationshipExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityOwnedRelationshipExactlyOneCommand,TestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler <CreateTestEntityOwnedRelationshipExactlyOneCommand, TestEntityOwnedRelationshipExactlyOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> EntityFactory;

	public CreateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipExactlyOneKeyDto> Handle(CreateTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityOwnedRelationshipExactlyOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityOwnedRelationshipExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateTestEntityOwnedRelationshipExactlyOneValidator : AbstractValidator<CreateTestEntityOwnedRelationshipExactlyOneCommand>
{
    public CreateTestEntityOwnedRelationshipExactlyOneValidator()
    {
    }
}