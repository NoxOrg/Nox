// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using ThirdTestEntityZeroOrManyEntity = TestWebApp.Domain.ThirdTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public record DeleteThirdTestEntityZeroOrManyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteThirdTestEntityZeroOrManyByIdCommandHandler : DeleteThirdTestEntityZeroOrManyByIdCommandHandlerBase
{
	public DeleteThirdTestEntityZeroOrManyByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteThirdTestEntityZeroOrManyByIdCommandHandlerBase : CommandBase<DeleteThirdTestEntityZeroOrManyByIdCommand, ThirdTestEntityZeroOrManyEntity>, IRequestHandler<DeleteThirdTestEntityZeroOrManyByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteThirdTestEntityZeroOrManyByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteThirdTestEntityZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.ThirdTestEntityZeroOrManies.FindAsync(keyId);
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