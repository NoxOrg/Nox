// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityExactlyOneToZeroOrOneByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandler : DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandlerBase
{
	public DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandlerBase : CommandBase<DeleteTestEntityExactlyOneToZeroOrOneByIdCommand, TestEntityExactlyOneToZeroOrOneEntity>, IRequestHandler<DeleteTestEntityExactlyOneToZeroOrOneByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityExactlyOneToZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityExactlyOneToZeroOrOnes.FindAsync(keyId);
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