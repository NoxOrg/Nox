// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using SecondTestEntityOneOrMany = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record DeleteSecondTestEntityOneOrManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteSecondTestEntityOneOrManyByIdCommandHandler:DeleteSecondTestEntityOneOrManyByIdCommandHandlerBase
{
	public DeleteSecondTestEntityOneOrManyByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution): base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityOneOrManyByIdCommandHandlerBase: CommandBase<DeleteSecondTestEntityOneOrManyByIdCommand,SecondTestEntityOneOrMany>, IRequestHandler<DeleteSecondTestEntityOneOrManyByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteSecondTestEntityOneOrManyByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityOneOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityOneOrManies.FindAsync(keyId);
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