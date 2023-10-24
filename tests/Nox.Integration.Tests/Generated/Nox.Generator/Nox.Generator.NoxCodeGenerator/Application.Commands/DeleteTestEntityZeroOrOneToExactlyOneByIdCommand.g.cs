// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityZeroOrOneToExactlyOneByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityZeroOrOneToExactlyOneByIdCommandHandler : DeleteTestEntityZeroOrOneToExactlyOneByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrOneToExactlyOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrOneToExactlyOneByIdCommandHandlerBase : CommandBase<DeleteTestEntityZeroOrOneToExactlyOneByIdCommand, TestEntityZeroOrOneToExactlyOneEntity>, IRequestHandler<DeleteTestEntityZeroOrOneToExactlyOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityZeroOrOneToExactlyOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrOneToExactlyOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrOneToExactlyOnes.FindAsync(keyId);
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