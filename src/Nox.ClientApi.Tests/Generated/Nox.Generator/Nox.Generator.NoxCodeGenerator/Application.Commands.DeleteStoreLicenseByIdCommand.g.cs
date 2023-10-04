// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public record DeleteStoreLicenseByIdCommand(System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteStoreLicenseByIdCommandHandler : DeleteStoreLicenseByIdCommandHandlerBase
{
	public DeleteStoreLicenseByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution): base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteStoreLicenseByIdCommandHandlerBase : CommandBase<DeleteStoreLicenseByIdCommand, StoreLicenseEntity>, IRequestHandler<DeleteStoreLicenseByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteStoreLicenseByIdCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteStoreLicenseByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.keyId);

		var entity = await DbContext.StoreLicenses.FindAsync(keyId);
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