// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityTwoRelationshipsOneToOneByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityTwoRelationshipsOneToOneByIdCommandHandler : DeleteTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase
{
	public DeleteTestEntityTwoRelationshipsOneToOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase : CommandBase<DeleteTestEntityTwoRelationshipsOneToOneByIdCommand, TestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler<DeleteTestEntityTwoRelationshipsOneToOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityTwoRelationshipsOneToOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(keyId);
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