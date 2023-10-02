// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using LandLord = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public record DeleteLandLordByIdCommand(System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteLandLordByIdCommandHandler:DeleteLandLordByIdCommandHandlerBase
{
	public DeleteLandLordByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution): base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteLandLordByIdCommandHandlerBase: CommandBase<DeleteLandLordByIdCommand,LandLord>, IRequestHandler<DeleteLandLordByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteLandLordByIdCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteLandLordByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.LandLordMetadata.CreateId(request.keyId);

		var entity = await DbContext.LandLords.FindAsync(keyId);
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