// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public record DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandler : DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase
{
	public DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase : CommandBase<DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand, SecondTestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler<DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityTwoRelationshipsOneToOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);DbContext.SecondTestEntityTwoRelationshipsOneToOnes.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}