// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityTwoRelationshipsOneToManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandler : DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase
{
	public DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase : CommandBase<DeleteTestEntityTwoRelationshipsOneToManyByIdCommand, TestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<DeleteTestEntityTwoRelationshipsOneToManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityTwoRelationshipsOneToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
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