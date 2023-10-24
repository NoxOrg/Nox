// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record DeleteThirdTestEntityOneOrManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteThirdTestEntityOneOrManyByIdCommandHandler : DeleteThirdTestEntityOneOrManyByIdCommandHandlerBase
{
	public DeleteThirdTestEntityOneOrManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteThirdTestEntityOneOrManyByIdCommandHandlerBase : CommandBase<DeleteThirdTestEntityOneOrManyByIdCommand, ThirdTestEntityOneOrManyEntity>, IRequestHandler<DeleteThirdTestEntityOneOrManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteThirdTestEntityOneOrManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteThirdTestEntityOneOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.ThirdTestEntityOneOrManies.FindAsync(keyId);
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