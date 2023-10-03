// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityOwnedRelationshipOneOrMany = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityOwnedRelationshipOneOrManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityOwnedRelationshipOneOrManyByIdCommandHandler:DeleteTestEntityOwnedRelationshipOneOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityOwnedRelationshipOneOrManyByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution): base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOwnedRelationshipOneOrManyByIdCommandHandlerBase: CommandBase<DeleteTestEntityOwnedRelationshipOneOrManyByIdCommand,TestEntityOwnedRelationshipOneOrMany>, IRequestHandler<DeleteTestEntityOwnedRelationshipOneOrManyByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteTestEntityOwnedRelationshipOneOrManyByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOwnedRelationshipOneOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOwnedRelationshipOneOrManies.FindAsync(keyId);
		if (entity == null || entity.IsDeleted == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}