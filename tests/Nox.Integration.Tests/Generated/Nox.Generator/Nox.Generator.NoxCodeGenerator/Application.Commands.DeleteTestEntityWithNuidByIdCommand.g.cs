// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityWithNuidByIdCommand(System.UInt32 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityWithNuidByIdCommandHandler : DeleteTestEntityWithNuidByIdCommandHandlerBase
{
	public DeleteTestEntityWithNuidByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityWithNuidByIdCommandHandlerBase : CommandBase<DeleteTestEntityWithNuidByIdCommand, TestEntityWithNuidEntity>, IRequestHandler<DeleteTestEntityWithNuidByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteTestEntityWithNuidByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityWithNuidByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityWithNuidMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityWithNuids.FindAsync(keyId);
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