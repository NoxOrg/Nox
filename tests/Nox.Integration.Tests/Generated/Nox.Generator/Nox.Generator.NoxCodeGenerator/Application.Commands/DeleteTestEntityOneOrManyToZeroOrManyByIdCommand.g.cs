// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOneOrManyToZeroOrManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandler : DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandlerBase : CommandBase<DeleteTestEntityOneOrManyToZeroOrManyByIdCommand, TestEntityOneOrManyToZeroOrManyEntity>, IRequestHandler<DeleteTestEntityOneOrManyToZeroOrManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOneOrManyToZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(keyId);
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