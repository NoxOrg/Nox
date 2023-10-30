// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityZeroOrOneByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityZeroOrOneByIdCommandHandler : DeleteTestEntityZeroOrOneByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrOneByIdCommandHandlerBase : CommandBase<DeleteTestEntityZeroOrOneByIdCommand, TestEntityZeroOrOneEntity>, IRequestHandler<DeleteTestEntityZeroOrOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityZeroOrOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrOnes.FindAsync(keyId);
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