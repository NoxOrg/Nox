// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Commands;

public partial record DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand(System.Guid keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandler : DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase
{
	public DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase : CommandBase<DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand, EntityUniqueConstraintsWithForeignKeyEntity>, IRequestHandler<DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(request.keyId);

		var entity = await DbContext.EntityUniqueConstraintsWithForeignKeys.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);DbContext.EntityUniqueConstraintsWithForeignKeys.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}