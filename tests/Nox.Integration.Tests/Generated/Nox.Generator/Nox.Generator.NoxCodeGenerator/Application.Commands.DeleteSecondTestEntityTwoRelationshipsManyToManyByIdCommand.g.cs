// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public record DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandler : DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase
{
	public DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase : CommandBase<DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand, SecondTestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);DbContext.SecondTestEntityTwoRelationshipsManyToManies.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}