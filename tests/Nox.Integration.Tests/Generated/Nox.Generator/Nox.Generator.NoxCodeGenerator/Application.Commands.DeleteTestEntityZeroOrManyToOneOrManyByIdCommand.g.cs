// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityZeroOrManyToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityZeroOrManyToOneOrManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityZeroOrManyToOneOrManyByIdCommandHandler : DeleteTestEntityZeroOrManyToOneOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrManyToOneOrManyByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrManyToOneOrManyByIdCommandHandlerBase : CommandBase<DeleteTestEntityZeroOrManyToOneOrManyByIdCommand, TestEntityZeroOrManyToOneOrManyEntity>, IRequestHandler<DeleteTestEntityZeroOrManyToOneOrManyByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteTestEntityZeroOrManyToOneOrManyByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrManyToOneOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrManyToOneOrManies.FindAsync(keyId);
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