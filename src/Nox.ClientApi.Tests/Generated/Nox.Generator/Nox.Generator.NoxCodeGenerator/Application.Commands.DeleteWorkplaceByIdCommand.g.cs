// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using Workplace = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public record DeleteWorkplaceByIdCommand(System.UInt32 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteWorkplaceByIdCommandHandler:DeleteWorkplaceByIdCommandHandlerBase
{
	public DeleteWorkplaceByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(dbContext, noxSolution, serviceProvider)
	{
	}
}
internal abstract class DeleteWorkplaceByIdCommandHandlerBase: CommandBase<DeleteWorkplaceByIdCommand,Workplace>, IRequestHandler<DeleteWorkplaceByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteWorkplaceByIdCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteWorkplaceByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Workplace,Nox.Types.Nuid>("Id", request.keyId);

		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);DbContext.Workplaces.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}