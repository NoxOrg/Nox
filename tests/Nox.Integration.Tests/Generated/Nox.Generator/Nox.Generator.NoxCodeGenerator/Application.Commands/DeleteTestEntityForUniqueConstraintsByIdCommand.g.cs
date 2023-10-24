// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityForUniqueConstraintsByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityForUniqueConstraintsByIdCommandHandler : DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase
{
	public DeleteTestEntityForUniqueConstraintsByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase : CommandBase<DeleteTestEntityForUniqueConstraintsByIdCommand, TestEntityForUniqueConstraintsEntity>, IRequestHandler<DeleteTestEntityForUniqueConstraintsByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityForUniqueConstraintsByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityForUniqueConstraints.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);DbContext.TestEntityForUniqueConstraints.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}