// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientEntity = ClientApi.Domain.Client;

namespace ClientApi.Application.Commands;

public partial record DeleteClientByIdCommand(System.Guid keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteClientByIdCommandHandler : DeleteClientByIdCommandHandlerBase
{
	public DeleteClientByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteClientByIdCommandHandlerBase : CommandBase<DeleteClientByIdCommand, ClientEntity>, IRequestHandler<DeleteClientByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteClientByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteClientByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.ClientMetadata.CreateId(request.keyId);

		var entity = await DbContext.Clients.FindAsync(keyId);
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