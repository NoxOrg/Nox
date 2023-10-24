// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandler : DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandlerBase
{
	public DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandlerBase : CommandBase<DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand, TestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler<DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
		if (entity == null || entity.IsDeleted == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}