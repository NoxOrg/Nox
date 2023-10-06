// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityZeroOrOneToOneOrManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandler : DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandlerBase : CommandBase<DeleteTestEntityZeroOrOneToOneOrManyByIdCommand, TestEntityZeroOrOneToOneOrManyEntity>, IRequestHandler<DeleteTestEntityZeroOrOneToOneOrManyByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrOneToOneOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrOneToOneOrManies.FindAsync(keyId);
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