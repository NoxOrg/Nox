// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using SecondTestEntityExactlyOne = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record DeleteSecondTestEntityExactlyOneByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteSecondTestEntityExactlyOneByIdCommandHandler:DeleteSecondTestEntityExactlyOneByIdCommandHandlerBase
{
	public DeleteSecondTestEntityExactlyOneByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution): base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityExactlyOneByIdCommandHandlerBase: CommandBase<DeleteSecondTestEntityExactlyOneByIdCommand,SecondTestEntityExactlyOne>, IRequestHandler<DeleteSecondTestEntityExactlyOneByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteSecondTestEntityExactlyOneByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityExactlyOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityExactlyOnes.FindAsync(keyId);
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