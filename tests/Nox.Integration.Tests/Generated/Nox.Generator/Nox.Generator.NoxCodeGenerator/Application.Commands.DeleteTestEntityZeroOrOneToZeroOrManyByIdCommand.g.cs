// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityZeroOrOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public record DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityZeroOrOneToZeroOrManyByIdCommandHandler : DeleteTestEntityZeroOrOneToZeroOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrOneToZeroOrManyByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrOneToZeroOrManyByIdCommandHandlerBase : CommandBase<DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand, TestEntityZeroOrOneToZeroOrManyEntity>, IRequestHandler<DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteTestEntityZeroOrOneToZeroOrManyByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrOneToZeroOrManies.FindAsync(keyId);
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