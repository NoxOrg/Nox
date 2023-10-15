// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public record DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandler : DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase
{
	public DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase : CommandBase<DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand, SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);DbContext.SecondTestEntityTwoRelationshipsOneToManies.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}